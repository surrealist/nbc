using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBC.Web.Areas.Admin.ViewModels
{
    public class SVActivityYearsIndexVM
    {
        public int SV_ID { get; set; }
        public int Year_ID { get; set; }
        public string SVName { get; set; }
        //public int NBCSVACT_ID { get; set; }
        public int NBCTarget { get; set; }
        //public string INCUSVACT_ID { get; set; }
        public int INCUTarget { get; set; }

        
    }
}