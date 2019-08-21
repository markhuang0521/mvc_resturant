using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Models;
using Resturant.Utility;

namespace Resturant.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class MenuItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public MenuItemVm MenuItemVm { get; set; }


        public MenuItemController(ApplicationDbContext context, HostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            MenuItemVm = new MenuItemVm
            {
                Category = _context.categories,
                MenuItem = new MenuItem()
            };
        }

        // GET: Customer/MenuItems
        public async Task<IActionResult> Index()
        {
            var menuItems = await _context.MenuItems.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync();
            return View( menuItems);
        }

        // GET: Customer/MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: Customer/MenuItems/Create
        public IActionResult Create()
        {
            //getting all cateorgy item
            //ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name");

            return View(MenuItemVm);
        }

        // POST: Customer/MenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            MenuItemVm.MenuItem.SubCateId = Convert.ToInt32(Request.Form["SubCategoryId"].ToString());
            if (!ModelState.IsValid)
            {
                return View(MenuItemVm);

            }
            _context.MenuItems.Add(MenuItemVm.MenuItem);
            await _context.SaveChangesAsync();


            //image upload
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var menuItemFromDb = await _context.MenuItems.FindAsync(MenuItemVm.MenuItem.Id);

            if (files.Count()>0)
            {
                var upload = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                //upload image
                using (var filesStream = new FileStream(Path.Combine(upload, MenuItemVm.MenuItem.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);

                }
                menuItemFromDb.Image = @"\images\" + MenuItemVm.MenuItem.Id + extension;

            }
            else
            {
                var upload = Path.Combine(webRootPath, @"images/"+SD.DefaultFoodImage);

                System.IO.File.Copy(upload, webRootPath + @"/images/" + MenuItemVm.MenuItem.Id+".png");
                menuItemFromDb.Image = @"\images\" + MenuItemVm.MenuItem.Id + "png";
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", menuItem.CategoryId);
            ViewData["SubCateId"] = new SelectList(_context.SubCategories, "Id", "Name", menuItem.SubCateId);
            return View(menuItem);
        }

        // POST: Customer/MenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image,Price,CategoryId,SubCateId")] MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.categories, "Id", "Name", menuItem.CategoryId);
            ViewData["SubCateId"] = new SelectList(_context.SubCategories, "Id", "Name", menuItem.SubCateId);
            return View(menuItem);
        }

        // GET: Customer/MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .Include(m => m.Category)
                .Include(m => m.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: Customer/MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
