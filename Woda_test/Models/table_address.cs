//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Woda_test.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class table_address
    {
        public int id { get; set; }
        public int Home_no { get; set; }
        public int Oda_number { get; set; }
        public string Sabik_gabisa { get; set; }
        public int Sabik_oda { get; set; }
        public string Tole { get; set; }
    
        public virtual table_home_facilities table_home_facilities { get; set; }
    }
}
