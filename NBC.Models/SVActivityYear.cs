using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class SVActivityYear
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int Target { get; set; }


        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
