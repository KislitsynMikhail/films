using Films.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Films.Services
{
    public class FilmService : BaseService, IFilmService
    {
        public FilmService(IDatabaseContext databaseContext) : base(databaseContext) { }

        public void Delete(Film film)
        {
            databaseContext.Films.Remove(film);
            databaseContext.SaveChanges();
        }

        public Film Get(int id)
        {
            var film = databaseContext.Films.FirstOrDefault(f => f.Id == id);
            CheckExistence(film, new Exception("Film not found"));

            return film;
        }

        public List<Film> GetList(int count, int page)
        {
            return databaseContext.Films
                .OrderBy(f => f.Name)
                .Skip(count * page)
                .Take(count)
                .ToList();
        }

        public void Insert(Film film)
        {
            databaseContext.Films.Add(film);
            databaseContext.SaveChanges();
        }

        public void Update(Film film)
        {
            databaseContext.Films.Update(film);
            databaseContext.SaveChanges();
        }
    }
}
