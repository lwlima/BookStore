#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Domain;
using BookStore.Data;
using System.Collections.Generic;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.Book.Get());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
         {
            if (id == null)
                return NotFound();

            var book = await _unitOfWork.Book.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_unitOfWork.Category.Get().Result, "Id", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditorBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book(
                    id: model.Id,
                    title: model.Title,
                    isbn: model.Isbn,
                    price: model.Price,
                    author: model.Author,
                    releaseDate: model.ReleaseDate,
                    categoryId: model.CategoryId
                );
                await _unitOfWork.Book.Create(book);
                await _unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _unitOfWork.Book.GetById(id);

            if (book == null)
                return NotFound();

            var model = new EditorBookViewModel
            {
                Title = book.Title,
                Isbn = book.Isbn,
                Price = book.Price,
                Author = book.Author,
                ReleaseDate = book.ReleaseDate,
                CategoryId = book.CategoryId
            };

            ViewData["CategoryId"] = new SelectList(await _unitOfWork.Category.Get(), "Id", "Name", book.Category);
            return View(model);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditorBookViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var book = new Book(
                        id: model.Id,
                        title: model.Title,
                        isbn: model.Isbn,
                        price: model.Price,
                        author: model.Author,
                        releaseDate: model.ReleaseDate,
                        categoryId: model.CategoryId
                    );
                    await _unitOfWork.Book.Update(book);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(model.Id))
                       return NotFound();
                    else
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var book = await _unitOfWork.Book.GetById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Book.Delete(id);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            var books = _unitOfWork.Book.GetById(id);
            if (books == null)
                return false;
            else
                return true;
        }
    }
}
