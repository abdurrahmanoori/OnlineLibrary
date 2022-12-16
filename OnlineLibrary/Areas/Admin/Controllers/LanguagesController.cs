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

namespace OnlineLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LanguagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/Languages
        public IActionResult Index( )
        {
            return View(_unitOfWork.Language.GetAll());
        }

        // GET: Admin/Languages/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var language = _unitOfWork.Language.GetFirstOrDefault(u => u.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // GET: Admin/Languages/Create
        public IActionResult Create( )
        {
            return View();
        }

        // POST: Admin/Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Language.Add(language);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Admin/Languages/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = _unitOfWork.Language.GetFirstOrDefault(u => u.Id == id);
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: Admin/Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Language language)
        {
            if (id != language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Language.Update(language);
                    _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageExists(language.Id))
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
            return View(language);
        }

        // GET: Admin/Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = _unitOfWork.Language.GetFirstOrDefault(u => u.Id == id);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }
        // POST: Admin/Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var language = _unitOfWork.Language.GetFirstOrDefault(u=>u.Id==id);
            _unitOfWork.Language.Remove(language);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageExists(int id)
        {
            return Convert.ToBoolean( _unitOfWork.Language.GetFirstOrDefault(e => e.Id == id));
        }
    }
}
