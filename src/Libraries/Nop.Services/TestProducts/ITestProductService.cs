using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.TestProduct;

namespace Nop.Services.TestProducts;
public interface ITestProductService
{

    Task<IList<TestProduct>> GetAllTestProducts();

    Task CreateTestProduct(TestProduct testProduct);

    Task DeleteTestProduct(TestProduct testProduct);

    Task UpdateTestProduct(TestProduct testProduct);
    
    Task<TestProduct> GetByIdAsync(int id);

}
