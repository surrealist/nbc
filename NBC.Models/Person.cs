using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(255)]
        public String Title { get; set; }
        [StringLength(255)]
        public  String FirstName { get; set; }
        [StringLength(255)]
        public String SurName { get; set; }

        public int? CitizenId { get; set; }

        public Address Address { get; set; }
        [StringLength(255)]
        public String Mobile { get; set; }

        [StringLength(255)]
        public String Email { get; set; }

        public Boolean isMainPerson { get; set; }


        [StringLength(255)]
        public String CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public String ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
