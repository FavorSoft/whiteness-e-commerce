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
    
    public partial class Categories
    {
        public Categories()
        {
            this.Unit = new HashSet<Unit>();
        }
    
        public int id { get; set; }
        public string category { get; set; }
        public int type_id { get; set; }
        public string category_img { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<Unit> Unit { get; set; }
        public virtual Category_type Category_type { get; set; }
    }
}
