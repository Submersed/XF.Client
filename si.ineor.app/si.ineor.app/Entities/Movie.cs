using si.ineor.app.Models.Movie;
using System;
using Xamarin.Forms;

namespace si.ineor.app.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Movie(CreateRequest movie)
        {
            Title = movie.Title;
            Description = movie.Description;
            ReleaseDate = movie.ReleaseDate;
        }
        public Movie()
        {

        }
    }
}
