using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nefis413Assignment3.Models;

namespace Nefis413Assignment3.Controllers
{
    public class Movie1Controller : Controller
    {
        private readonly MovieDbContext _context;

        public Movie1Controller(MovieDbContext context)
        {
            _context = context;
        }

        // GET: Movie1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movie1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addMovie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (addMovie == null)
            {
                return NotFound();
            }

            return View(addMovie);
        }

        // GET: Movie1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] AddMovie addMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addMovie);
        }

        // GET: Movie1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addMovie = await _context.Movie.FindAsync(id);
            if (addMovie == null)
            {
                return NotFound();
            }
            return View(addMovie);
        }

        // POST: Movie1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] AddMovie addMovie)
        {
            if (id != addMovie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddMovieExists(addMovie.MovieId))
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
            return View(addMovie);
        }

        // GET: Movie1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addMovie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (addMovie == null)
            {
                return NotFound();
            }

            return View(addMovie);
        }

        // POST: Movie1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addMovie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(addMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddMovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }
    }
}
