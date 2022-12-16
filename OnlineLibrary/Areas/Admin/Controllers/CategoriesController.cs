using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DataAccess.Repository.IRepository;
using OnlineLibrary.Models;

namespace OnlineLibrary.Areas.Admin
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _UniteOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _UniteOfWork = unitOfWork;
        }

        // GET: Admin/Categories
        public IActionResult Index( )
        {
            var onlineLibraryContext = _UniteOfWork.Category.GetAll(includeProperties: "CategoryType");

            //var onlineLibraryContext = _UniteOfWork.Category.Include(c => c.CategoryType);
            return View(onlineLibraryContext.ToList());
        }

        // GET: Admin/Categories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var category = _UniteOfWork.Category.GetFirstOrDefault(u => u.Id == id, includeProperties: "CategoryType");
            //var category = _UniteOfWork.Category
            //    .Include(c => c.CategoryType)
            //                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create( )
        {

            ViewData["CategoryTypeId"] = _UniteOfWork.CategoryType.GetAll().Select(u => new
                 SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            //ViewData["CategoryTypeId"] = new SelectList(_UniteOfWork.Set<CategoryType>(), "Id", "Name");
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CategoryTypeId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _UniteOfWork.Category.Add(category);
                _UniteOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryTypeId"] = _UniteOfWork.CategoryType.GetAll().Select(u =>
             new SelectListItem
             {
                 Text = u.Name,
                 Value=u.Id.ToString()
             });
            //ViewData["CategoryTypeId"] = new SelectList(_UniteOfWork.Set<CategoryType>(), "Id", "Name", category.CategoryTypeId);
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _UniteOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["CategoryTypeId"] = _UniteOfWork.CategoryType.GetAll().Select(u =>
             new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()
             });
            //ViewData["CategoryTypeId"] = new SelectList(_UniteOfWork.Set<CategoryType>(), "Id", "Name", category.CategoryTypeId);
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CategoryTypeId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _UniteOfWork.Category.Update(category);
                     _UniteOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryTypeId"] = _UniteOfWork.CategoryType.GetAll().Select(u =>
             new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()
             });
            //ViewData["CategoryTypeId"] = new SelectList(_UniteOfWork.Set<CategoryType>(), "Id", "Name", category.CategoryTypeId);
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _UniteOfWork.Category.GetFirstOrDefault(u => u.Id == id, includeProperties: "CategoryType");
            //var category = await _UniteOfWork.Category
            //    .Include(c => c.CategoryType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var category = _UniteOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
            _UniteOfWork.Category.Remove(category);
            _UniteOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return Convert.ToBoolean(_UniteOfWork.Category.GetFirstOrDefault(e => e.Id == id));
        }
    }
}
