//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlytaloMobiili.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saunat
    {
        public int SaunaId { get; set; }
        public string SaunaNimi { get; set; }
        public Nullable<bool> SaunaOff { get; set; }
        public Nullable<bool> SaunaOn { get; set; }
        public Nullable<int> SaunaTavoiteLampotila { get; set; }
        public Nullable<int> SaunaNykyLampotila { get; set; }
    }
}
