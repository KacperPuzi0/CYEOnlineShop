using Microsoft.AspNetCore.Mvc;

using CYEOnlineShop.Models;
using CYEOnlineShop.DataAccess;
using CYEOnlineShop.DataAccess.Repository.IRepository;

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
            Product product = new();
            if(id == null || id == 0)
            {
                //Create 
                return View(product);
            }
            else
            {
                //Update
            }
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Sex obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            _unitOfWork.Sex.Update(obj);
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

            var sexFromDbFirst = _unitOfWork.Sex.GetFirstOrDefault(u=>u.Id==id);

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

