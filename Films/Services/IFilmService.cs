using Films.Data;
using System.Collections.Generic;

namespace Films.Services
{
    public interface IFilmService
    {
        Film Get(int id);

        List<Film> GetList(int count, int page);

        void Insert(Film film);

        void Update(Film film);

        void Delete(Film film);
    }
}
