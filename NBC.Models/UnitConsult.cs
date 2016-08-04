using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class UnitConsult : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Unit")]
        public virtual int Unit_Id { get; set; }
        public virtual Unit Unit { get; set; }
        [ForeignKey("Consultant")]
        public virtual int Consultant_Id { get; set; }
        public virtual Consultant Consultant { get; set; }
        public Boolean IsEnable { get; set; }

        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
