using Moq;
using Shouldly;
using System.Collections.Generic;
using TronBattleBot;
using TronBattleBot.Interfaces;
using Xunit;

namespace UnitTests.BotTests {
    public class GetNextMoveShould {

        [Fact]
        public void ReturnNoValidMoves_GivenGameStateWithNoValidMoves() {
            var mockMoveGetter = new Mock<IValidMoveGetter>();
            mockMoveGetter.Setup(m => m.GetValidMoves(It.IsAny<GameState>(), It.IsAny<Coordinates>())).Returns(new List<string>());
            var bot = new Bot(mockMoveGetter.Object);
            var game = new GameState(1, 1);
            var currentTurn = new TurnData { PlayerNumber = 0 };
            currentTurn.Cycles.Add(new Cycle { Number = 0, Head = new Coordinates(0, 0) });
            currentTurn.Cycles.Add(new Cycle { Number = 1, Head = new Coordinates(0, 0) });
            game.UpdateGameState(currentTurn);

            var move = bot.GetNextMove(game);

            move.ShouldBe("No Valid Moves");
        }
    }
}
