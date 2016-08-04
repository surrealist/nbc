using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class User : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }   

        [StringLength(13)]
        public string CardId { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(15)]
        public string Tel { get; set; }
        [StringLength(15)]
        public string Mobile { get; set; }
        [StringLength(15)]
        public string Fax { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }      
        public bool isEnable { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }

        public User()
        {
            UserInRoles = new HashSet<UserInRole>();
        }
    }
}
