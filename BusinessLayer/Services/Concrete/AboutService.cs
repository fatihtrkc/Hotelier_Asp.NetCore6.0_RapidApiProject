using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.AboutDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository aboutRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AboutService(IAboutRepository aboutRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.aboutRepository = aboutRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(AboutAddDto aboutAddDto)
        {
            try
            {
                var about = mapper.Map<About>(aboutAddDto);
                bool isAdded = await aboutRepository.AddAsync(about);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(About about)
        {
            try
            {
                bool isDeleted = await aboutRepository.DeleteAsync(about);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(AboutUpdateDto aboutUpdateDto)
        {
            try
            {
                var about = mapper.Map<About>(aboutUpdateDto);
                bool isUpdated = await aboutRepository.UpdateAsync(about);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<About> GetFirstOrDefaultAsync(Expression<Func<About, bool>> expression)
        {
            try
            {
                return await aboutRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<About>> GetAllWhereAsync(Expression<Func<About, bool>> expression)
        {
            try
            {
                return await aboutRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            try
            {
                return await aboutRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
