using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linknight.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        // Delete
        public User(Guid id)
        {
            Id = id;
        }

        // Empty
        public User()
        {

        }

        // Insert
        public User(string username, string firstName, string lastName, string password)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        // Update
        public User(Guid id, string username, string firstName, string lastName, string password)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        // Login
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
