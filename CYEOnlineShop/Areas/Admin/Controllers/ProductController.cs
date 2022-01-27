using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CYEOnlineShop.Models;
using CYEOnlineShop.DataAccess.Repository.IRepository;
using CYEOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace CYEOnlineShop.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Sex> objSexList = _unitOfWork.Sex.GetAll();
        return View(objSexList);
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        ProductViewModel productViewModel = new()
        {
            Product = new(),
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            SexList = _unitOfWork.Sex.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            })
        };

        if (id == null || id == 0)
        {
            //Create 
            return View(productViewModel);
        }
        else
        {
            //Update
        }
        return View(productViewModel);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductViewModel obj, IFormFile file )
    {
        if (!ModelState.IsValid)
        {
            return View(obj);
        }
        //_unitOfWork.Sex.Update(obj);
        _unitOfWork.Save();
        TempData["success"] = "Sex updated successfully";
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var sexFromDbFirst = _unitOfWork.Sex.GetFirstOrDefault(u => u.Id == id);

        if (sexFromDbFirst == null)
        {
            return NotFound();
        }

        return View(sexFromDbFirst);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Sex.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Sex.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Sex deleted successfully";
        return RedirectToAction("Index");
    }
}