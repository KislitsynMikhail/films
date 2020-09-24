using Films.Models;
using System.ComponentModel.DataAnnotations;

namespace Films.Data
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Director { get; set; }
        public int DurationInSeconds { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        public Film() { }

        public Film(FilmModel filmModel)
        {
            ChangeValues(filmModel);
        }

        public void ChangeValues(FilmModel filmModel)
        {
            Name = filmModel.Name;
            Director = filmModel.Director;
            DurationInSeconds = filmModel.DurationInSeconds;
            Description = filmModel.Description;
        }
    }
}
