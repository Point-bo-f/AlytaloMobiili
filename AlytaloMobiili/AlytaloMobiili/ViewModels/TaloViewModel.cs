using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlytaloMobiili.ViewModels
{
    public class TaloViewModel
    {
        public int TaloId { get; set; }
        public string TaloNimi { get; set; }
        public string TavoiteLampotila { get; set; }
        public string NykyLampotila { get; set; }
        public bool LampoOn { get; set; }
        public bool LampoOff { get; set; }

        public char Astemerkki { get; set; }
        public object HuoneId { get; internal set; }
    }
}