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
    
    public partial class Basket_items
    {
        public int id { get; set; }
        public int basket_id { get; set; }
        public int unit_id { get; set; }
        public int amount { get; set; }
    
        public virtual Basket Basket { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
