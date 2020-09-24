using System;
using System.Linq;
using Films.Data;
using Films.Models;
using Films.Services;
using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService filmService;

        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                FilmModels = filmService.GetList(10, 0).Select(f => new FilmModel(f)).ToList()
            };

            return View(indexViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var filmModel = new FilmModel(filmService.Get(id.Value));

            return View(filmModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Director, DurationInSeconds, Description")] FilmModel filmModel)
        {
            if (ModelState.IsValid)
            {
                var film = new Film(filmModel);
                filmService.Insert(film);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var filmModel = new FilmModel(filmService.Get(id.Value));

            return View(filmModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name, Director, DurationInSeconds, Description")] FilmModel filmModel)
        {
            if (id != filmModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var film = filmService.Get(id);
                    film.ChangeValues(filmModel);
                    filmService.Update(film);
                }
                catch(Exception)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(filmModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            try
            {
                var film = filmService.Get(id.Value);
                filmService.Delete(film);
            } 
            catch(Exception)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
