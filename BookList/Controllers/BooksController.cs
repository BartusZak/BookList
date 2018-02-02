using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {

        //Taking care about database connection @bartuszak
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        //MainActions @bartuszak
        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        //Get : Book/Create @bartuszak
        public IActionResult Create()
        {
            return View();
        }

        //Post : Book/Create @bartuszak
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(Book book)
        {
            if(ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        //Disposing Database @bartuszak
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}