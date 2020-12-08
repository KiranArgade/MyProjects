using ProductReview.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        void Commit();
    }
}
