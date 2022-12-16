using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data;
using OnlineLibrary.DataAccess.Repository.IRepository;
using OnlineLibrary.Models;

namespace OnlineLibrary.Areas.Admin
{
    [Area("Admin")]
    public class CategoryTypesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/CategoryTypes
        public async Task<IActionResult> Index( )
        {
            return View(_unitOfWork.CategoryType.GetAll());
        }

        // GET: Admin/CategoryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryType = _unitOfWork.CategoryType.GetFirstOrDefault(m => m.Id == id);
            if (categoryType == null)
            {
                return NotFound();
            }
            return View(categoryType);
        }

        // GET: Admin/CategoryTypes/Create
        public IActionResult Create( )
        {
            return View();
        }

        // POST: Admin/CategoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryType categoryType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryType.Add(categoryType);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryType);
        }

        // GET: Admin/CategoryTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryType = _unitOfWork.CategoryType.GetFirstOrDefault(m=>m.Id==id);
            if (categoryType == null)
            {
                return NotFound();
            }
            return View(categoryType);
        }

        // POST: Admin/CategoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] CategoryType categoryType)
        {
            if (id != categoryType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.CategoryType.Update(categoryType);
                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTypeExists(categoryType.Id))
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
            return View(categoryType);
        }

        // GET: Admin/CategoryTypes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryType = _unitOfWork.CategoryType
                .GetFirstOrDefault(m => m.Id == id);
            if (categoryType == null)
            {
                return NotFound();
            }

            return View(categoryType);
        }

        // POST: Admin/CategoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoryType =_unitOfWork.CategoryType.GetFirstOrDefault(u=>u.Id==id);

            _unitOfWork.CategoryType.Remove(categoryType);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTypeExists(int id)
        {
            return Convert.ToBoolean(_unitOfWork.CategoryType.GetFirstOrDefault(e => e.Id == id));
        }
    }
}
