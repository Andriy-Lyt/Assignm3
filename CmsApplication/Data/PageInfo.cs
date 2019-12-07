using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsApplication.Data
{
    /// <summary>
    /// Page information
    /// </summary>
    public class PageInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishDate { get; set; }
    };
}