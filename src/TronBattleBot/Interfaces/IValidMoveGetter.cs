using System;
using System.Collections.Generic;

namespace TronBattleBot.Interfaces {
    public interface IValidMoveGetter {
        List<string> GetValidMoves(GameState game, Coordinates position);
    }
}