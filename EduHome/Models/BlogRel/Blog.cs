using EduHome.Models.APrimary;
using System;
using System.Collections.Generic;

namespace EduHome.Models.BlogRel
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int CommentCount { get; set; }
        public ICollection<BlogImage> BlogImages { get; set; }
    }
}
