//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nakliyeciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nakliyeciler()
        {
            this.Satislar = new HashSet<Satislar>();
        }
    
        public int NakliyeciID { get; set; }
        public string SirketAdi { get; set; }
        public string Telefon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
