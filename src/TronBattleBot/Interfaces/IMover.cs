using System.Collections.Generic;

namespace TronBattleBot.Interfaces {
    public interface IMover {
        string SelectNextMove(GameState game, List<string> validMoves);
    }
}