using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.TestProduct;
using Nop.Services.Security;
using Nop.Services.TestProducts;
using Nop.Web.Framework.Menu;

namespace Nop.Web.Areas.Admin.Controllers;

public class TestProductController : BaseAdminController
{
    protected readonly ITestProductService _testProductRepository;
    protected readonly IPermissionService _permissionService;

    public TestProductController(ITestProductService testProductService, IPermissionService permissionService)
    {
        _testProductRepository = testProductService;
        _permissionService = permissionService;
    }

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

        ViewBag.TestProductCount = testProducts.Count();

        return View(testProducts);
    }


    [HttpPost]
    [ActionName("Create")]
    public virtual async Task<IActionResult> Create(TestProduct testProduct)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
            return AccessDeniedView();

        await _testProductRepository.CreateTestProduct(testProduct);
        return RedirectToAction("List");
    }

    [HttpPut]
    [ActionName("Update")]
    public virtual async Task<IActionResult> Update(TestProduct testProduct)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
            return AccessDeniedView();

        await _testProductRepository.UpdateTestProduct(testProduct);
        return RedirectToAction("List");
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> Delete(int id)
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageTestProducts))
            return AccessDeniedView();

        var testProduct = await _testProductRepository.GetByIdAsync(id);
        if (testProduct == null)
            return NotFound();

        await _testProductRepository.DeleteTestProduct(testProduct);
        return RedirectToAction("List");
    }
}
