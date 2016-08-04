using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBC.Web.Areas.SV.ViewModels
{
    public class UnitActivityViewModel
    {
        public int SV_ID { get; set; }
        public int Unit_ID { get; set; }
        public int Year_ID { get; set; }
        public string SVName { get; set; }
        public string UnitName { get; set; }
        public int SVActivityYear_Id { get; set; }
        public int NBCTarget { get; set; }
       
        public int INCUTarget { get; set; }
    }
}