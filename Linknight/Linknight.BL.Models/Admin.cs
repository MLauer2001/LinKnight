using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Linknight.BL.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("User ID")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        // Delete
        public Admin(Guid id)
        {
            Id = id;
        }

        // Empty
        public Admin()
        {

        }

        // Insert
        public Admin(string userName, string firstName, string lastName, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        // Update
        public Admin(Guid id, string userName, string firstName, string lastName, string password)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        // Login
        public Admin(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
