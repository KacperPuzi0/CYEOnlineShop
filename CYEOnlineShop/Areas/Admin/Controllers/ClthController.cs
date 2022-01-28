using Microsoft.AspNetCore.Mvc;

using CYEOnlineShop.Models;
using CYEOnlineShop.DataAccess;
using CYEOnlineShop.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using CYEOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace CYEOnlineShop.Controllers;
[Area("Admin")]
public class ClthController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ClthController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        ClthVM clthVM = new()
        {
            Clth = new(),
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

            return View(clthVM);
        }
        else
        {
            clthVM.Clth = _unitOfWork.Clth.GetFirstOrDefault(u => u.Id == id);
            return View(clthVM);
        }

    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(ClthVM obj, IFormFile file)
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
                obj.Clth.ImageUrl = @"\img\prod" + file.FileName + extension;
            }
            if (obj.Clth.Id == 0)
            {
                _unitOfWork.Clth.Add(obj.Clth);
            }
            else
            {
                _unitOfWork.Clth.Update(obj.Clth);
            }

            _unitOfWork.Save();
            TempData["success"] = "Clth added successfully";
            return RedirectToAction("Index");
        }
        return View(obj);

    }


    //public IActionResult Delete(int? id)
    //{
    //    if (id == null || id == 0)
    //    {
    //        return NotFound();
    //    }

    //    var sexFromDbFirst = _unitOfWork.Sex.GetFirstOrDefault(u => u.Id == id);

    //    if (sexFromDbFirst == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(sexFromDbFirst);
    //}

    ////POST
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public IActionResult DeletePOST(int? id)
    //{
    //    var obj = _unitOfWork.Sex.GetFirstOrDefault(u => u.Id == id);
    //    if (obj == null)
    //    {
    //        return NotFound();
    //    }
    //    _unitOfWork.Sex.Remove(obj);
    //    _unitOfWork.Save();
    //    TempData["success"] = "Sex deleted successfully";
    //    return RedirectToAction("Index");
    //}

}