using System.ComponentModel.DataAnnotations;

namespace Api.Models.Authentication
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public User()
        {
        }

        public User(int id, string userName, string firstName, string lastName, string email)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
