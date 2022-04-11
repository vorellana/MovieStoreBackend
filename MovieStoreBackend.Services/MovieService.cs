using MovieStoreBackend.DTO;
using MovieStoreBackend.Entities;
using MovieStoreBackend.Services.Infrastructure.Repositories;
using MovieStoreBackend.Services.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreBackend.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository) { 
            this.movieRepository = movieRepository;
        }

        public Task<IEnumerable<Movie>> GetAllMovies()
        {
            return movieRepository.GetAllMovies();
        }

        public Task<IEnumerable<MoviesByCustomerDTO>> GetListOfMoviesByCustomer(string diskStatus, string docType)
        {
            return movieRepository.GetListOfMoviesByCustomer(diskStatus, docType);
        }
    }
}
