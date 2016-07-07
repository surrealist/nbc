using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class ActivityType:IRecord
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [StringLength(255)]
        public String Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }

        [StringLength(255)]
        public String ModifiedBy { get; set; }
    }
}
