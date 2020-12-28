using MyBlogLister.Interfaces;

namespace MyBlogLister.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            this.Posts = new HashSet<Post>();
        }
    
        public int BlogId { get; set; }
        public string Author { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Permalink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
