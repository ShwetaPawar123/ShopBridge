using Microsoft.EntityFrameworkCore;

namespace ShopBridge.Models
{
  public class InventoryContext : DbContext
  {
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {

    }

    public DbSet<Inventory> Inventories  { get; set;}
  }
}
