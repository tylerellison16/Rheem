using Rheem.Inventory.Api.Data;
using Rheem.Inventory.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rheem.Inventory.Api.ControllersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryContext _context;

        public InventoryController(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<IActionResult> GetInventoryItems([FromQuery] string filter = null)
        {
            try
            {
                var query = _context.InventoryItems.AsQueryable();

                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(item => item.Name.Contains(filter) ||
                                                item.ProductCategory.Contains(filter));
                }

                var items = await query.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                // Log exception as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");
            return Ok(item);
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.InventoryItems.Add(item);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetInventoryItem), new { id = item.InventoryID }, item);
            }
            catch (Exception ex)
            {
                // Log exception as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryItem(int id, [FromBody] InventoryItem updatedItem)
        {
            if (id != updatedItem.InventoryID)
                return BadRequest("Inventory ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingItem = await _context.InventoryItems.FindAsync(id);
            if (existingItem == null)
                return NotFound($"Item with ID {id} not found.");

            try
            {
                // Update properties
                existingItem.Name = updatedItem.Name;
                existingItem.Description = updatedItem.Description;
                existingItem.Quantity = updatedItem.Quantity;
                existingItem.Price = updatedItem.Price;
                existingItem.ProductCategory = updatedItem.ProductCategory;

                _context.InventoryItems.Update(existingItem);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");

            try
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log exception as needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}