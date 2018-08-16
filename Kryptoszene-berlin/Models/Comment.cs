using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kryptoszene_berlin.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}