using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleo.Shared.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; } = new User();

    }
}
