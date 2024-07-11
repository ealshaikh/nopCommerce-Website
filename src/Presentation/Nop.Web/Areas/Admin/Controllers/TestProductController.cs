using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.TestProduct;
using Nop.Services.Security;
using Nop.Services.TestProducts;
using Nop.Web.Framework.Menu;

namespace Nop.Web.Areas.Admin.Controllers;
public class TestProductController : BaseAdminController
{

    #region Fields

    protected readonly ITestProductService _testProductRepository;
    protected readonly IPermissionService _permissionService;
    #endregion

    #region Ctor

    public TestProductController(ITestProductService testProductService, IPermissionService permissionService)
    {
        _testProductRepository = testProductService;
        _permissionService = permissionService;
    }

    #endregion

    #region Actions


    public virtual IActionResult Index()
    {
        return RedirectToAction("List");
    }

    [HttpGet]
    [ActionName("List")]
    public virtual async Task<IActionResult> List()
    {

        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
            return AccessDeniedView();

        var testProducts = await _testProductRepository.GetAllTestProducts();

        if (testProducts == null || testProducts.Count == 0)
        {
            return NotFound();
        }

        return View(testProducts);
    }

    [HttpPost]
    [ActionName("Create")]

    public virtual async Task<IActionResult> Create(TestProduct testProduct)
    {
        try
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
                return AccessDeniedView();

            await  _testProductRepository.CreateTestProduct(testProduct);
            return RedirectToAction("List");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
      

    }

    [HttpPut]
    [ActionName("Update")]
    public virtual async Task<IActionResult> Update(TestProduct testProduct)
    {
        try
        {

            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
                return AccessDeniedView();

            await _testProductRepository.UpdateTestProduct(testProduct);
            return RedirectToAction("List");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }


    }
    //[HttpPost]
    //[ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public virtual async Task<IActionResult> Delete(int id)
    //{
    //    try
    //    {
    //        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
    //            return AccessDeniedView();

    //        var testProduct = await _testProductRepository.GetByIdAsync(id);
    //        if (testProduct == null)
    //        {
    //            return NotFound();
    //        }

    //        await _testProductRepository.DeleteTestProduct(testProduct);
    //        return RedirectToAction("List");
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, $"Internal server error: {ex.Message}");
    //    }
    //}


    #endregion
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
                return AccessDeniedView();

            var testProduct = await _testProductRepository.GetByIdAsync(id);
            if (testProduct == null)
            {
                return NotFound();
            }

            await _testProductRepository.DeleteTestProduct(testProduct); // Assuming Delete method is appropriately implemented

            //return NoContent(); 
            return RedirectToAction("List");

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }




}
