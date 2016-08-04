using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models {
  public class Unit: WorkPlace {       
        
        [StringLength(255)]
        public String ContactPersonName { get; set; }
        [StringLength(255)]
        public String ConactPersonTel {get; set;}
        [StringLength(255)]
        public String ContactPersonEmail { get; set; }
        [StringLength(255)]
        public String HeadPersonName { get; set; }
        [StringLength(255)]
        public String HeadPersonTel { get; set; }
        [StringLength(255)]
        public String HeadPersonEmail { get; set; }        

        public virtual ICollection<UnitConsult> UnitConsults { get; set; }

        public Unit()
        {
            UnitConsults = new HashSet<UnitConsult>();
        }
    }
}
