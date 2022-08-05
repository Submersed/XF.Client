
using System;
namespace si.ineor.app.Models.Movie
{
    public class CreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //validacija...
        public DateTime ReleaseDate { get; set; }
    }
}
