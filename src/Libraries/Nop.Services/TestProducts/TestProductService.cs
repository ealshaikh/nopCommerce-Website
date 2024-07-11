using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Domain.TestProduct;
using Nop.Data;

namespace Nop.Services.TestProducts;
public class TestProductService : ITestProductService
{
    #region Fields

    private readonly IRepository<TestProduct> _testProductRepository;

    #endregion

    #region Ctor
    public TestProductService(IRepository<TestProduct> testProductRepository)
    {

        _testProductRepository = testProductRepository;
    }

    #endregion

    #region Methods

    public virtual async Task CreateTestProduct(TestProduct testProduct)
    {
        await _testProductRepository.InsertAsync(testProduct);
    }

    public virtual async Task UpdateTestProduct(TestProduct testProduct)
    {
        await _testProductRepository.UpdateAsync(testProduct);
    }

    public virtual async Task DeleteTestProduct(TestProduct testProduct)
    {
        await _testProductRepository.DeleteAsync(testProduct);
    }

    public virtual async Task<IList<TestProduct>> GetAllTestProducts()
    {
        var query = await _testProductRepository.GetAllAsync(
            query => query.OrderBy(tp => tp.Id),
            //not specifying any specific caching mechanism or key for this operation
            cache => default,
            // include items that are marked as deleted in the database, if applicable.
            includeDeleted: true
        );

        return query.ToList();
    }

    public virtual async Task<TestProduct> GetByIdAsync(int id)
    {
        return await _testProductRepository.GetByIdAsync(id);
    }

      #endregion
}

