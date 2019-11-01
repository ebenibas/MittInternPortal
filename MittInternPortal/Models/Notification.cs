using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MittInternPortal.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateSent { get; set; }
        public string Description { get; set; }
    }
}