using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.ReferenceDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class ReferenceService : IReferenceService
    {
        private readonly IReferenceRepository referenceRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ReferenceService(IReferenceRepository referenceRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.referenceRepository = referenceRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(ReferenceAddDto referenceAddDto)
        {
            try
            {
                var reference = mapper.Map<Reference>(referenceAddDto);
                bool isAdded = await referenceRepository.AddAsync(reference);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Reference reference)
        {
            try
            {
                bool isDeleted = await referenceRepository.DeleteAsync(reference);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ReferenceUpdateDto referenceUpdateDto)
        {
            try
            {
                var reference = mapper.Map<Reference>(referenceUpdateDto);
                bool isUpdated = await referenceRepository.UpdateAsync(reference);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Reference> GetFirstOrDefaultAsync(Expression<Func<Reference, bool>> expression)
        {
            try
            {
                return await referenceRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Reference>> GetAllWhereAsync(Expression<Func<Reference, bool>> expression)
        {
            try
            {
                return await referenceRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Reference>> GetAllAsync()
        {
            try
            {
                return await referenceRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
