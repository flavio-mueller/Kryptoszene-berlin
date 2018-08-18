using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kryptoszene_berlin.Models
{
    public class CommentViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }
    }
}