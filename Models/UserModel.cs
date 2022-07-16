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
       
        public UserModel()
        {
        }

        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;           
        }
    }
}
