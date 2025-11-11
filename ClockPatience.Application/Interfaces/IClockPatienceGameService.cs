using ClockPatience.Application.DTOs;
using ClockPatience.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.Interfaces
{
    public interface IClockPatienceGameService
    {
        public void StartNewGame();

        public List<DeckDTO> SeedDecks(int numberOfDecks);

        public void StopGame();
    }
}
