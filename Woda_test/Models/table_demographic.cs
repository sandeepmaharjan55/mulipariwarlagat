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
    
    public partial class table_demographic
    {
        public int id { get; set; }
        public int Total_person { get; set; }
        public int Male_count { get; set; }
        public int Female_count { get; set; }
        public string caste { get; set; }
        public string religion { get; set; }
        public int Home_no { get; set; }
    
        public virtual table_home_facilities table_home_facilities { get; set; }
    }
}
