using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.DTOs
{
    public class CardDTO
    {
        public string Rank { get; set; } = string.Empty;
        public string Suit { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
