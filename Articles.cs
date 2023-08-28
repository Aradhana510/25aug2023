using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dynamicwebsite
{
    public partial class Articles
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }

}