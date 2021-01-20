using Shouldly;
using TronBattleBot;
using Xunit;

namespace UnitTests.ValidMoveGetterTests {
    public class GetValidMovesShould {
        readonly ValidMoveGetter getter;
        readonly GameState game;

        public GetValidMovesShould() {
            getter = new ValidMoveGetter();
            game = new GameState(3, 3);
        }

        [Fact]
        public void ReturnLeft_WhenLeftIsValidMove() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X - 1, coords.Y] = false;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldContain("LEFT");
        }

        [Fact]
        public void NotReturnLeft_WhenLeftCellIsOccupied() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X - 1, coords.Y] = true;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("LEFT");
        }

        [Fact]
        public void NotReturnLeft_WhenAtLeftEdge() {
            var coords = new Coordinates(0, 1);
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("LEFT");
        }

        [Fact]
        public void ReturnUp_WhenUpIsValidMove() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X, coords.Y - 1] = false;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldContain("UP");
        }

        [Fact]
        public void NotReturnUp_WhenUpCellIsOccupied() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X, coords.Y - 1] = true;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("UP");
        }

        [Fact]
        public void NotReturnUp_WhenAtTopEdge() {
            var coords = new Coordinates(1, 0);
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("UP");
        }

        [Fact]
        public void ReturnRight_WhenRightIsValidMove() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X + 1, coords.Y] = false;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldContain("RIGHT");
        }

        [Fact]
        public void NotReturnRight_WhenRighteCellIsOccupied() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X + 1, coords.Y] = true;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("RIGHT");
        }

        [Fact]
        public void NotReturnRight_WhenkAtRightEdge() {
            var coords = new Coordinates(2, 1);
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("RIGHT");
        }

        [Fact]
        public void ReturnDown_WhenDownIsValidMove() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X, coords.Y + 1] = false;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldContain("DOWN");
        }

        [Fact]
        public void NotReturnDown_WhenDownCellIsOccupied() {
            var coords = new Coordinates(1, 1);
            game.Grid[coords.X, coords.Y + 1] = true;
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("DOWN");
        }

        [Fact]
        public void NotReturnDown_WhenAtBottomEdge() {
            var coords = new Coordinates(1, 2);
            var moves = getter.GetValidMoves(game, coords);

            moves.ShouldNotContain("DOWN");
        }
    }
}
