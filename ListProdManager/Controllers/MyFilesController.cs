using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListProdManager.Data;
using ListProdManager.Models;

namespace ListProdManager.Controllers
{
    public class MyFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyFile.ToListAsync());
        }

        // GET: MyFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFile = await _context.MyFile
                .FirstOrDefaultAsync(m => m.MyFileId == id);
            if (myFile == null)
            {
                return NotFound();
            }

            return View(myFile);
        }

        // GET: MyFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyFileId,FileContent,Size,Type")] MyFile myFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myFile);
        }

        // GET: MyFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFile = await _context.MyFile.FindAsync(id);
            if (myFile == null)
            {
                return NotFound();
            }
            return View(myFile);
        }

        // POST: MyFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyFileId,FileContent,Size,Type")] MyFile myFile)
        {
            if (id != myFile.MyFileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyFileExists(myFile.MyFileId))
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
            return View(myFile);
        }

        // GET: MyFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFile = await _context.MyFile
                .FirstOrDefaultAsync(m => m.MyFileId == id);
            if (myFile == null)
            {
                return NotFound();
            }

            return View(myFile);
        }

        // POST: MyFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myFile = await _context.MyFile.FindAsync(id);
            _context.MyFile.Remove(myFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyFileExists(int id)
        {
            return _context.MyFile.Any(e => e.MyFileId == id);
        }
    }
}
