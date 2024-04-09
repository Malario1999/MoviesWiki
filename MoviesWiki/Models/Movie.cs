using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesWiki.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ReleaseYear { get; set; }
        public List<string> PlatformIcons { get; set;}
        public bool Trending { get; set; }
    }
}
