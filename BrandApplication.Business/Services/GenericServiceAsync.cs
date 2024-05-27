using AutoMapper;
using BrandApplication.DataAccess.Repositories;

namespace BrandApplication.Business.Services
{
    public class GenericServiceAsync<TEntity, TDto> : ReadServiceAsync<TEntity, TDto>, IGenericServiceAsync<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericServiceAsync(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto dto)
        {
            await _unitOfWork.Repository<TEntity>().AddAsync(_mapper.Map<TEntity>(dto));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Repository<TEntity>().DeleteByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TDto dto)
        {
            await _unitOfWork.Repository<TEntity>().UpdateAsync(_mapper.Map<TEntity>(dto));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
