using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlytaloMobiili.ViewModels
{
    public class ValoViewModel
    {
        public int ValoId { get; set; }
        public string Huone { get; set; }

        [Display(Name = "Valot pois")]
        public bool ValoOff { get; set; }
        public bool Valo33 { get; set; }
        public bool Valo66 { get; set; }
        public bool Valo100 { get; set; }
     
    }

 }
