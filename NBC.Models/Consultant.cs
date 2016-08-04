using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class Consultant : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(13)]
        [Required]
        [Index("IX_ConsultantCitizenid", IsUnique = true)]
        public string Citizenid { get; set; }
        [StringLength(255)]
        public String Title { get; set; }
        [StringLength(255)]
        [Required]
        public String FirstName { get; set; }
        [StringLength(255)]
        [Required]
        public String SurName { get; set; }
        public Address Address { get; set; }
        
        [StringLength(255)]
        public String Tel { get; set; }
        [StringLength(255)]
        public String Email { get; set; }
        [StringLength(2048)]
        public String Notes { get; set; }
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<UnitConsult> UnitConsults { get; set; }

        public Consultant()
        {
            UnitConsults = new HashSet<UnitConsult>();
        }
    }
}
