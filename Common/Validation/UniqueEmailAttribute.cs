using DataAccessLayer.IRepositories;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Common.Validation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        private readonly IBaseRepository<Client> _clientRepository;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var existingEmail = _clientRepository.Find(u => u.Email == (string)value);

            if (existingEmail != null)
            {
                return new ValidationResult("Email address is already in use.");
            }

            return ValidationResult.Success;
        }
    }
}
