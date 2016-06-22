using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class SV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        public String Name { get; set; }
        [StringLength(255)]
        public String Alias { get; set; }
        [StringLength(255)]
        public String Tel { get; set; }
        [StringLength(255)]
        public String Email { get; set; }


        public List<SVUnitYear> SVUnitYears { get; set; }

        public List<SVActivityYear> SVActivityYears { get; set; }


        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }


    }
}
