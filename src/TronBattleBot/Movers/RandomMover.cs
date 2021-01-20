using System;
using System.Collections.Generic;
using System.Linq;
using TronBattleBot.Interfaces;

namespace TronBattleBot.Movers {
    public class RandomMover : IMover {
        private readonly Random rng;

        public RandomMover(int seed) {
            rng = new Random(seed);
        }

        public string SelectNextMove(GameState game, List<string> validMoves) {
            return validMoves.ElementAt(rng.Next(validMoves.Count));
        }
    }
}