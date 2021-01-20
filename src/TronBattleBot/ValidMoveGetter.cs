using System.Collections.Generic;
using TronBattleBot.Interfaces;

namespace TronBattleBot {
    public class ValidMoveGetter : IValidMoveGetter {
        private const string LEFT = "LEFT";
        private const string RIGHT = "RIGHT";
        private const string UP = "UP";
        private const string DOWN = "DOWN";

        public List<string> GetValidMoves(GameState game, Coordinates position) {
            var validMoves = new List<string>();
            if (position.X > game.Grid.GetLowerBound(0) && !game.Grid[position.X - 1, position.Y]) validMoves.Add(LEFT);
            if (position.X < game.Grid.GetUpperBound(0) && !game.Grid[position.X + 1, position.Y]) validMoves.Add(RIGHT);
            if (position.Y > game.Grid.GetLowerBound(1) && !game.Grid[position.X, position.Y - 1]) validMoves.Add(UP);
            if (position.Y < game.Grid.GetUpperBound(1) && !game.Grid[position.X, position.Y + 1]) validMoves.Add(DOWN);

            return validMoves;
        }
    }
}
