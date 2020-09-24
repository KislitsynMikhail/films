using Films.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Films.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Название")]
        public string Name { get; set; }
        [MaxLength(200)]
        [DisplayName("Режиссер")]
        public string Director { get; set; }
        [Range(1, 200000)]
        [DisplayName("Продолжительность в секундах")]
        public int DurationInSeconds { get; set; }
        [MaxLength(1000)]
        [DisplayName("Описание")]
        public string Description { get; set; }

        public FilmModel() { }

        public FilmModel(Film film)
        {
            Id = film.Id;
            Name = film.Name;
            Director = film.Director;
            DurationInSeconds = film.DurationInSeconds;
            Description = film.Description;
        }
    }
}
