using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class House
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Owner { get; set; }
    }
}
