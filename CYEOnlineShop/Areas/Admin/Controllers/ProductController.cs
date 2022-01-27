using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CYEOnlineShop.Models;
using CYEOnlineShop.DataAccess.Repository.IRepository;
using CYEOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace CYEOnlineShop.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
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
            Product  = new(),
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
            productViewModel.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            return View(productViewModel);
        }
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ProductViewModel obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"img\prod");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Product.ImageUrl = @"\img\prod\" + fileName + extension;
                if (obj.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }
            }
            _unitOfWork.Save();
            TempData["success"] = "Product Added successfully";
            return RedirectToAction("Index");
        }
        return View(obj);

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