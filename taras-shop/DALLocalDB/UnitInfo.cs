//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALLocalDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnitInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnitInfo()
        {
            this.Basket_items = new HashSet<Basket_items>();
        }
    
        public int id { get; set; }
        public int unit_id { get; set; }
        public int size_id { get; set; }
        public int amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket_items> Basket_items { get; set; }
        public virtual Sizes Sizes { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
