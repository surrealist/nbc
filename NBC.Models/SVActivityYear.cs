using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class SVActivityYear : IRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Target { get; set; }
        public virtual Year Year { get; set; }
        public virtual SV SV { get; set; }      
        public virtual ActionType ActionType { get; set; }       
        [StringLength(255)]
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
