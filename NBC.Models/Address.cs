using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBC.Models {

  [ComplexType]
  public class Address {
    public string No { get; set; }
    public string Tumbon { get; set; }
    public string Amphur { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
  }
}
