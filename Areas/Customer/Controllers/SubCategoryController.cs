using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Models;

namespace Resturant.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        [TempData]
        public string StatusMessage { get; set; }

        public SubCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer/SubCategory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubCategories.Include(s => s.Category);
            return View(await applicationDbContext.ToListAsync());
        }
        //get subcategory list
        [ActionName("GetSubcategory")]
        public async Task<IActionResult> GetSubCategory(int Id)
        {
            List<SubCategory> subCategories = new List<SubCategory>();

            subCategories = await _context.SubCategories.Where(c => c.CategoryId == Id).ToListAsync();

            return Json(new SelectList(subCategories, "Id", "Name"));

        }



        // GET: Customer/SubCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }



        // GET: Customer/SubCategory/Create
        public async Task<IActionResult> Create()
        {
            var model = new CategoryViewModel()
            {
                CategoryList = await _context.categories.ToListAsync(),
                SubCategory = new SubCategory(),
                SubCategoryList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);
        }

        // POST: Customer/SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();

            }

            var doesSubCategoryExists = _context.SubCategories.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);

            if (doesSubCategoryExists.Count() > 0)
            {
                var viewModel = new CategoryViewModel()
                {
                    CategoryList = await _context.categories.ToListAsync(),
                    SubCategory = new SubCategory(),
                    SubCategoryList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
                };
                ModelState.AddModelError("", $"subcategory name already exist");
                return View(viewModel);

            }
            else
            {
                _context.Add(model.SubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



        }

        // GET: Customer/SubCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            var viewModel = new CategoryViewModel()
            {
                CategoryList = await _context.categories.ToListAsync(),
                SubCategory = subCategory,
                SubCategoryList = await _context.SubCategories.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };
            return View(viewModel);

        }

        // POST: Customer/SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existSubcategory = _context.SubCategories
               .Include(s => s.Category)
               .Where(s => s.Name == model.SubCategory.Name && s.Category.Id == model.SubCategory.CategoryId);
                if (existSubcategory.Count() > 0)
                {
                    //Error
                    StatusMessage = "Error : Sub Category exists under " + existSubcategory.First().Category.Name+"please use another name";
                }
                else
                {
                    _context.SubCategories.Update(model.SubCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            var viewModel = new CategoryViewModel()
            {
                CategoryList = await _context.categories.ToListAsync(),
                SubCategory = new SubCategory(),
                SubCategoryList = await _context.SubCategories.OrderBy(p => p.Name)
                .Select(p => p.Name).Distinct().ToListAsync(),
                StatusMessage = StatusMessage

            };
            return View(viewModel);


        }

        // GET: Customer/SubCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: Customer/SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
