using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository testimonialRepository;
        private readonly IUnitOfWork unitOfWork;
        public TestimonialService(ITestimonialRepository testimonialRepository, IUnitOfWork unitOfWork)
        {
            this.testimonialRepository = testimonialRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Testimonial entity)
        {
            try
            {
                bool isAdded = await testimonialRepository.AddAsync(entity);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Testimonial entity)
        {
            try
            {
                bool isDeleted = await testimonialRepository.DeleteAsync(entity);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Testimonial entity)
        {
            try
            {
                bool isUpdated = await testimonialRepository.UpdateAsync(entity);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Testimonial> GetFirstOrDefaultAsync(Expression<Func<Testimonial, bool>> expression)
        {
            try
            {
                return await testimonialRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Testimonial>> GetAllWhereAsync(Expression<Func<Testimonial, bool>> expression)
        {
            try
            {
                return await testimonialRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Testimonial>> GetAllAsync()
        {
            try
            {
                return await testimonialRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
