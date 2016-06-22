using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models {
  public class Unit {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        public String Name { get; set; }
        [StringLength(255)]
        public String Alias { get; set; }
        [StringLength(255)]
        public Address Adress { get; set; }
        [StringLength(255)]
        public String Tel { get; set; }
        [StringLength(255)]
        public String Email { get; set; }
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
        [StringLength(2048)]
        public String Notes { get; set; }

        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }




    }
}
