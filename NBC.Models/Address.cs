using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models {

  [ComplexType]
  public class Address {

        [StringLength(255)]
        public String No { get; set; }
        [StringLength(255)]
        public String Moo { get; set; }
        [StringLength(255)]
        public String MooBan { get; set; }
        [StringLength(255)]
        public String Building { get; set; }
        [StringLength(255)]
        public String Floor { get; set; }
        [StringLength(255)]
        public String Soi { get; set; }
        [StringLength(255)]
        public String Road { get; set; }

        public int Tambol_Id { get; set; }
        [StringLength(255)]
        public String Tambol { get; set; }

        public int Amphoe_Id { get; set; }

        [StringLength(255)]
        public String Amphoe { get; set; }

        public int ProvinceCode { get; set; }
        [StringLength(5)]
        public String ZipCode { get; set; }

        public float Latitude { get; set; }

        public float Longtitude { get; set; }



        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
