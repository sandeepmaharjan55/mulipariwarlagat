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
    
    public partial class anupasthit_bekti_many
    {
        public int ABM_ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Total { get; set; }
        public string went_place { get; set; }
        public string gone_reason { get; set; }
        public Nullable<int> AB_ID { get; set; }
    
        public virtual anupasthit_bekti anupasthit_bekti { get; set; }
    }
}
