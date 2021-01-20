using Shouldly;
using System;
using System.Collections.Generic;
using TronBattleBot;
using TronBattleBot.Movers;
using Xunit;

namespace UnitTests.MoverTests.InertiaMoverTests {
    public class SelectNextMove_GivenAllMoves_Should {
        readonly List<string> allMoves;

        public SelectNextMove_GivenAllMoves_Should() {
            allMoves = new List<string> { "LEFT", "UP", "RIGHT", "DOWN" };
        }

        [Fact]
        public void ThrowsArgumentException_WhenFirstMove() {
            var mover = new InertiaMover();
            var game = new GameState(3, 3);
            game.Turns.Add(new TurnData());

            Assert.Throws<ArgumentException>(() => mover.SelectNextMove(game, allMoves));
        }

        [Fact]
        public void ReturnPreviousMove_WhenNotFirstMove() {
            var mover = new InertiaMover();
            var game = new GameState(3, 3);
            game.Turns.Add(new TurnData { Move = "LEFT" });
            game.Turns.Add(new TurnData());

            var move = mover.SelectNextMove(game, allMoves);

            move.ShouldBe("LEFT");
        }

        [Fact]
        public void ThrowApplicationException_WhenPreviousMoveNotAnOption() {
            var mover = new InertiaMover();
            var game = new GameState(3, 3);
            game.Turns.Add(new TurnData { Move = "LEFT" });
            game.Turns.Add(new TurnData());
            allMoves.Remove("LEFT");

            Assert.Throws<ApplicationException>(() => mover.SelectNextMove(game, allMoves));
        }
    }
}
