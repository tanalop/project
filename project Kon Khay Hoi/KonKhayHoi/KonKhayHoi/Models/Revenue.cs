//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KonKhayHoi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Revenue
    {
        public int RID { get; set; }
        public string R_date { get; set; }
        public string R_list { get; set; }
        public int Weight { get; set; }
        public string Shop { get; set; }
        public int amount { get; set; }
        public string payee { get; set; }
        public int CID { get; set; }
    
        public virtual Circulation Circulation { get; set; }
    }
}
