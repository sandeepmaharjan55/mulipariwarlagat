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
    
    public partial class pariwar_bekti_bibarand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pariwar_bekti_bibarand()
        {
            this.pariwar_bekti_bibarand_many = new HashSet<pariwar_bekti_bibarand_many>();
        }
    
        public int PB_ID { get; set; }
        public Nullable<int> senior_id { get; set; }
    
        public virtual table_house_senior_details table_house_senior_details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pariwar_bekti_bibarand_many> pariwar_bekti_bibarand_many { get; set; }
    }
}
