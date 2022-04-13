using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;

namespace MovieStoreBackend.Services.Infrastructure.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();

        Task<IEnumerable<MoviesByCustomerDTO>> GetListOfMoviesByCustomer(string diskStatus, string docType);
    }
}
