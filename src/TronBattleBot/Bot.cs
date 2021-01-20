using System;
using System.Collections.Generic;
using System.Linq;
using TronBattleBot.Interfaces;

namespace TronBattleBot {
    public class Bot {
        private readonly IValidMoveGetter validMoveGetter;
        private readonly Dictionary<string, IMover> movers;

        public Bot(IValidMoveGetter validMoveGetter) {
            this.validMoveGetter = validMoveGetter;
            movers = new Dictionary<string, IMover>();
        }

        public void AddMover(string moverName, IMover mover) {
            movers.Add(moverName, mover);
        }

        public string GetNextMove(GameState game) {
            var currentTurn = game.Turns.Last();
            var playerPosition = GetPlayerCurrentPosition(currentTurn);
            var validMoves = validMoveGetter.GetValidMoves(game, playerPosition);
            
            try {
                if (!validMoves.Any()) return "No Valid Moves";

                if (validMoves.Count == 1) {
                    Console.Error.WriteLine("One Choice");
                    return validMoves.First();
                }

                if (game.Turns.Count > 1) {
                    Console.Error.WriteLine("Inertia");
                    return movers["Inertia"].SelectNextMove(game, validMoves);
                }
            }
            catch (Exception ex) {
                Console.Error.WriteLine(ex.Message);
            }

            Console.Error.WriteLine("Random");
            return movers["Random"].SelectNextMove(null, validMoves);
        }

        private static Coordinates GetPlayerCurrentPosition(TurnData currentTurn) {
            return currentTurn.Cycles.Single(c => c.Number == currentTurn.PlayerNumber).Head;
        }

        private static Coordinates GetOpponentCurrentPosition(TurnData currentTurn) {
            return currentTurn.Cycles.Single(c => c.Number != currentTurn.PlayerNumber).Head;
        }
    }
}
