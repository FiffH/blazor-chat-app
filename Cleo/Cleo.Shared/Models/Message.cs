using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleo.Shared.Models
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; } = new User();

    }
}
