using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBC.Models
{
    public class Consultant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Citizenid { get; set; }
        [StringLength(255)]
        public String Title { get; set; }
        [StringLength(255)]
        public String FirstName { get; set; }
        [StringLength(255)]
        public String SurName { get; set; }

        public Address Address { get; set; }
        //Change to Adress type later
        [StringLength(255)]
        public String Tel { get; set; }
        [StringLength(255)]
        public String Email { get; set; }
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
