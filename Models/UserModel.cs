using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneCST_350.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("Input Username")]
        [StringLength(20, MinimumLength = 4)]    
        public string username { get; set; }
        [Required]
        [DisplayName("Choose a Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4)]
        public string password { get; set; }
        [Required]
        [DisplayName("What is your email address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20, MinimumLength = 4)]
        public string emailAddress { get; set; }
        [Required]
        [DisplayName("What is your first name?")]
        [StringLength(20, MinimumLength = 1)]
        public string firstName { get; set; }
        [Required]
        [DisplayName("What is your last name?")]
        [StringLength(20, MinimumLength = 1)]
        public string lastName { get; set; }
        [Required]
        [DisplayName("What is your gender identity?")]
        [StringLength(5)]
        public string sex { get; set; }
        [Required]
        [DisplayName("What is your age?")]       
        public int age { get; set; }
        [Required]
        [DisplayName("What state do you live in?")]
        public string state { get; set; }
       
        public UserModel()
        {
        }

        public UserModel(string username, string password, string firstName, string lastName, string sex, int age, string state, string emailAddress)
        {
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.age = age;
            this.state = state;
            this.emailAddress = emailAddress;
        }
    }
}
