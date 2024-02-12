using AutoMapper;
using BusinessLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.UnitOfWork.Abstract;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Services.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(ContactAddDto contactAddDto)
        {
            try
            {
                var contact = mapper.Map<Contact>(contactAddDto);
                bool isAdded = await contactRepository.AddAsync(contact);
                if (isAdded) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Contact contact)
        {
            try
            {
                bool isDeleted = await contactRepository.DeleteAsync(contact);
                if (isDeleted) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(ContactUpdateDto contactUpdateDto)
        {
            try
            {
                var contact = mapper.Map<Contact>(contactUpdateDto);
                bool isUpdated = await contactRepository.UpdateAsync(contact);
                if (isUpdated) return await unitOfWork.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Contact> GetFirstOrDefaultAsync(Expression<Func<Contact, bool>> expression)
        {
            try
            {
                return await contactRepository.GetFirstOrDefaultAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> GetAllWhereAsync(Expression<Func<Contact, bool>> expression)
        {
            try
            {
                return await contactRepository.GetAllWhereAsync(expression);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            try
            {
                return await contactRepository.GetAllAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
