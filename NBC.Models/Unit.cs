using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models {
  public class Unit {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public String Name { get; set; }

        public String Alias { get; set; }

        public String Adress { get; set; }
        [StringLength(15)]
        public String Tel { get; set; }
        [StringLength(30)]
        public String Email { get; set; }
        [StringLength(100)]
        public String ContactPersonName { get; set; }
        [StringLength(15)]
        public String ConactPersonTel { get; set; }
        [StringLength(30)]
        public String ContactPersonEmail { get; set; }
        [StringLength(100)]
        public String HeadPersonName { get; set; }
        [StringLength(15)]
        public String HeadPersonTel { get; set; }
        [StringLength(30)]
        public String HeadPersonEmail { get; set; }

        public String Notes { get; set; }



    }
}
