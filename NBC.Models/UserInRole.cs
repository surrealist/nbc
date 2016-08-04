using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
  public  class UserInRole : IRecord
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public virtual int User_Id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Role")]
        public virtual int Role_Id { get; set; }
        public virtual Role Role { get; set; }             
        public virtual WorkPlace WorkAt { get; set; }
        public bool isEnable { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
