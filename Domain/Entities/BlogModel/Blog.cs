using Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.BlogModel
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
