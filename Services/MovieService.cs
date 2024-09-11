class Movie
{
  private static int _id = 0;
  public int Id { get; set; }
  public string Title { get; set; }

  public string? Description {get; set;}

  public Movie(string title, string? description)
  {
    Title = title;
    Id = _id++;

    // Gjør at Movie-klassen har en valgfri Description-egenskap,
    // slik at man også kan legge til en beskrivelse.
    Description = description;
  }
}

interface IMovieService
{
  public IEnumerable<Movie> GetAllMovies();
  public Movie CreateMovie(Movie movie);
  public Movie? UpdateMovieWithId(int id, Movie updateMovieInfo);
  public void DeleteMovieWithId(int id);
}

class MovieService : IMovieService
{
  private List<Movie> movies;

  public MovieService()
  {
    movies = new List<Movie>();
  }

  public IEnumerable<Movie> GetAllMovies()
  {
    return movies;
  }

  public Movie CreateMovie(Movie movie)
  {
    movies.Add(movie);

    return movie;
  }

  public Movie? UpdateMovieWithId(int id, Movie updateMovieInfo)
  {
    // Find the correct movie to update
    var movie = movies.Find((movie) => movie.Id == id);

    if (movie == null)
    {
      return null;
    }

    movie.Title = updateMovieInfo.Title;

    // Update
    return movie;
  }

  public void DeleteMovieWithId(int id)
  {
    var movie = movies.Find((movie) => movie.Id == id);

    if (movie == null)
    {
      return;
    }

    movies.Remove(movie);
  }
}