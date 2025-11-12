using ClockPatience.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.Interfaces
{
    public interface IGameRepository
    {
        void AddGame(ClockSolitaireGame currentGameSession);
        void SaveGameResult(ClockSolitaireGame gameToSave);
    }
}
