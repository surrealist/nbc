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

        public int? Tambol_Id { get; set; }
        [StringLength(255)]
        public String TambolName { get; set; }

        public int? Amphur_Id { get; set; }

        [StringLength(255)]
        public String AmphurName { get; set; }

        public int? Province_Id { get; set; }
        [StringLength(255)]
        public String ProvinceName { get; set; }

        [StringLength(5)]
        public String ZipCode { get; set; }
        public float? Latitude { get; set; }
        public float? Longtitude { get; set; }
     
    }
}
