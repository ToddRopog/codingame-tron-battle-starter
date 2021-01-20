using System;
using System.Collections.Generic;
using System.Linq;
using TronBattleBot.Interfaces;

namespace TronBattleBot.Movers {
    public class InertiaMover : IMover {

        public string SelectNextMove(GameState game, List<string> validMoves) {
            if (game.Turns.Count < 2) {
                throw new ArgumentException("Must be at game turn 2 or later.");
            }

            var previousMove = game.Turns.ElementAt(game.Turns.Count - 2).Move;
            if (validMoves.Contains(previousMove)) return previousMove;

            throw new ApplicationException("Can't keep moving in same direction");
        }
    }
}
