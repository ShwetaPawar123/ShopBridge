using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.InventoryData
{
  public interface IInventoryData
  {
    Task<IEnumerable<Inventory>> GetInventoriesAsync();
    Task<Inventory> GetInventoryAsync(Guid InventoryID);
    Task<Inventory> AddInventoryAsync(Inventory inventory);
    Task<Inventory> EditInventoryAsync(Inventory inventory);
    Task DeleteInventoryAsync(Inventory inventory);

  }
}
