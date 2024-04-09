using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;


namespace MoviesWiki.Models
{
    class Home
    {
        public ObservableCollection<Movie>? trending {  get; set; }
        public ObservableCollection<Movie>? allMovies { get; set; }

        public Home()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream("MoviesWiki.movies.json");
            if (stream == null)
            {
                // Handle missing resource gracefully
                trending = new ObservableCollection<Movie>();
                return;
            }

            try
            {
                using var streamReader = new StreamReader(stream);
                string jsonContent = streamReader.ReadToEnd();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ignore case when matching properties
                };
                var moviesWrapper = JsonSerializer.Deserialize<MoviesWrapper>(jsonContent, options);
                allMovies = new ObservableCollection<Movie>(moviesWrapper.Movies);
                trending = new ObservableCollection<Movie>(allMovies.Where(movie => movie.Trending).ToList());
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                trending = new ObservableCollection<Movie>();
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                Console.WriteLine($"Error: {ex.Message}");
                trending = new ObservableCollection<Movie>();
            }
        }

        public class MoviesWrapper
        {
            public List<Movie> Movies { get; set; }
        }
    }
}
