using AutoMapper;
using BrandApplication.Business.DTOs;
using BrandApplication.DataAccess.Models;
using BrandApplication.DataAccess.Repositories;

namespace BrandApplication.Business.Services
{
    public class BrandService : ReadServiceAsync<Brand, BrandDto>, IBrandService
    {
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
