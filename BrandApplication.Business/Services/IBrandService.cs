using BrandApplication.Business.DTOs;
using BrandApplication.DataAccess.Models;

namespace BrandApplication.Business.Services
{
    public interface IBrandService : IReadServiceAsync<Brand, BrandDto>
    {
    }
}
