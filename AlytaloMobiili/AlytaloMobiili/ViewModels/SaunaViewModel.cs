using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlytaloMobiili.ViewModels
{
    public class SaunaViewModel
    {
        public int SaunaId { get; set; }

        public string SaunaNimi { get; set; }

        [Display(Name = "Tavoitelämpö")]
        public string TavoiteLampotila { get; set; }

        private string NykyLampotila { get; set; }

        [Display(Name = "ON / OFF")]
        public bool SaunanTila { get; set; }

        [Display(Name = "Sauna On")]
        public DateTime? SaunaStart { get; set; }

        [Display(Name = "Sauna Off")]
        public DateTime? SaunaStop { get; set; }
    }
}