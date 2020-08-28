using dt102g_projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dt102g_projekt.ViewModels
{
    public class IndexViewModel
    {
        public List<Post> Posts { get; set; }
        public ContactForm ContactForm { get; set; }
    }
}
