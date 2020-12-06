using Inventory.Data;
using System;

namespace ProductReview.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        InventoryEntities Init();
    }
}