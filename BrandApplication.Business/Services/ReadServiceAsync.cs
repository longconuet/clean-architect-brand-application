using AutoMapper;
using BrandApplication.DataAccess.Repositories;

namespace BrandApplication.Business.Services
{
    public class ReadServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        //private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReadServiceAsync(IUnitOfWork unitOfWork, IMapper mapper) : base()
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity>().GetAllAsync();

                if (result.Any())
                {
                    return _mapper.Map<IEnumerable<TDto>>(result);
                }

                return new List<TDto>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            try
            {
                var result = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);

                if (result is not null)
                {
                    return _mapper.Map<TDto>(result);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
