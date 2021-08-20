using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.InventoryData
{
  public class SQLInventoryData : IInventoryData
  {
    private InventoryContext _inventoryContext;
    public SQLInventoryData(InventoryContext inventoryContext)
    {
      _inventoryContext = inventoryContext;
    }

    /// <summary>
    /// A basic Retrive example - List all inventories
    /// </summary>
    public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
    {
      return await _inventoryContext.Inventories.ToListAsync();
    }

    /// <summary>
    /// A basic Retrive example
    /// </summary>
    /// <param name="InventoryID">inventory retrive with InventoryID</param>
    public async Task<Inventory> GetInventoryAsync(Guid InventoryID)
    {
      return await _inventoryContext.Inventories.FindAsync(InventoryID);
    }

    /// <summary>
    /// A basic add example
    /// </summary>
    /// <param name="inventory">inventory with basic required details</param>
    public async Task<Inventory> AddInventoryAsync(Inventory inventory)
    {
      inventory.InventoryID = Guid.NewGuid();
      await _inventoryContext.Inventories.AddAsync(inventory);
      await _inventoryContext.SaveChangesAsync();
      return inventory;
    }

    /// <summary>
    /// A basic Edit example
    /// </summary>
    /// <param name="InventoryID"> InventoryID </param>
    public async Task<Inventory> EditInventoryAsync(Inventory inventory)
    {
      var existingInventory = _inventoryContext.Inventories.Find(inventory.InventoryID);
      if (existingInventory != null)
      {
        existingInventory.Name = inventory.Name;
        _inventoryContext.Inventories.Update(existingInventory);
        await _inventoryContext.SaveChangesAsync();
      }
      return inventory;
    }


    /// <summary>
    /// A basic Delete example
    /// </summary>
    /// <param name="InventoryID"> InventoryID </param>
    public async Task DeleteInventoryAsync(Inventory inventory)
    {
      _inventoryContext.Inventories.Remove(inventory);
      await _inventoryContext.SaveChangesAsync();
    }


  }
}
