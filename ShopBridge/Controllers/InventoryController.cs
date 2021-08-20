using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.InventoryData;
using ShopBridge.Models;
using System;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{

  [ApiController]
  public class InventoryController : ControllerBase
  {
    private IInventoryData _inventorydata;

    public InventoryController(IInventoryData inventorydata)
    {
      _inventorydata = inventorydata;
    }

    [HttpGet]
    [Route("api/[controller]")]
    public async Task<IActionResult> GetInventoriesAsync()
    {
      return Ok(await _inventorydata.GetInventoriesAsync());
    }


    [HttpGet]
    [Route("api/[controller]/(InventoryID)")]
    public async Task<IActionResult> GetInventoryAsync(Guid InventoryID)
    {
      var inventory = await _inventorydata.GetInventoryAsync(InventoryID);

      if (inventory != null)
      {
        return Ok(inventory);
      }

      return NotFound($"Inventory with id {InventoryID} was not found");

    }


    [HttpPost]
    [Route("api/[controller]/(InventoryID)")]
    public async Task<IActionResult> AddInventory(Inventory inventory)
    {
      await _inventorydata.AddInventoryAsync(inventory);
      return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + inventory.InventoryID, inventory);
    }

    [HttpDelete]
    [Route("api/[controller]/(InventoryID)")]
    public async Task<IActionResult> DeleteInventory(Guid InventoryID)
    {
      var inventory = await _inventorydata.GetInventoryAsync(InventoryID);

      if (inventory != null)
      {
        await _inventorydata.DeleteInventoryAsync(inventory);
        return Ok();
      }

      return NotFound($"Inventory with id {InventoryID} was not found");

    }

    [HttpPatch]
    [Route("api/[controller]/(InventoryID)")]
    public async Task<IActionResult> EditInventory(Guid InventoryID, Inventory inventory)
    {
      var existinginventory = await _inventorydata.GetInventoryAsync(InventoryID);

      if (existinginventory != null)
      {
        inventory.InventoryID = existinginventory.InventoryID;
        await _inventorydata.EditInventoryAsync(existinginventory);
      }

      return Ok(inventory);
    }

  }
}
