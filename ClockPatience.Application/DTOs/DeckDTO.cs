using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.DTOs
{
    public class DeckDTO
    {
        public int DeckNumber { get; set; }
        public List<CardDTO> Cards { get; set; } = new();
    }
}
