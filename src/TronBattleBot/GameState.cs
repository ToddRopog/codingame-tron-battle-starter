using System.Collections.Generic;

namespace TronBattleBot {
    public class GameState {
        public GameState(int gridWidth, int gridHeight) {
            Turns = new List<TurnData>();
            Grid = new bool[gridWidth, gridHeight];
        }

        public List<TurnData> Turns { get; internal set; }
        public bool[,] Grid { get; set; }

        public void UpdateGameState(TurnData currentTurn) {
            Turns.Add(currentTurn);
            UpdateGameGrid(Grid, currentTurn);
        }

        private static void UpdateGameGrid(bool[,] gameGrid, TurnData currentTurn) {
            foreach (var cycle in currentTurn.Cycles) {
                gameGrid[cycle.Head.X, cycle.Head.Y] = true;
            }
        }
    }
}
