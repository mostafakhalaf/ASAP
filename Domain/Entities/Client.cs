using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string FirstName { get; set; }
        [Required, MaxLength(150)]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


    }
}