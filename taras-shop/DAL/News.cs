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
    
    public partial class News
    {
        public News()
        {
            this.News_image = new HashSet<News_image>();
        }
    
        public int id { get; set; }
        public string title { get; set; }
        public System.DateTime data_create { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<News_image> News_image { get; set; }
    }
}
