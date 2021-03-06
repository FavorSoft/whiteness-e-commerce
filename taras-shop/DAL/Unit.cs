//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Unit
    {
        public Unit()
        {
            this.Basket_items = new HashSet<Basket_items>();
            this.Images = new HashSet<Images>();
            this.Order_items = new HashSet<Order_items>();
            this.UnitInfo = new HashSet<UnitInfo>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public string producer { get; set; }
        public Nullable<int> price { get; set; }
        public int category_id { get; set; }
        public string material { get; set; }
        public string color { get; set; }
        public int likes { get; set; }
        public string description { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<int> old_price { get; set; }
    
        public virtual ICollection<Basket_items> Basket_items { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<Images> Images { get; set; }
        public virtual ICollection<Order_items> Order_items { get; set; }
        public virtual ICollection<UnitInfo> UnitInfo { get; set; }
    }
}
