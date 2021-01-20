using Shouldly;
using System.Collections.Generic;
using TronBattleBot.Movers;
using Xunit;

namespace UnitTests.MoverTests.RandomMoverTests {
    public class SelectNextMove_GivenAllMoves_Should {
        readonly List<string> allMoves;

        public SelectNextMove_GivenAllMoves_Should() {
            allMoves = new List<string> { "LEFT", "UP", "RIGHT", "DOWN" };
        }

        [Fact]
        public void ReturnRight_WhenSeedEqualsZero() {
            var mover = new RandomMover(0);

            mover.SelectNextMove(null, allMoves).ShouldBe("RIGHT");
        }

        [Fact]
        public void ReturnLeft_WhenSeedEqualsOne() {
            var mover = new RandomMover(1);

            mover.SelectNextMove(null, allMoves).ShouldBe("LEFT");
        }

        [Fact]
        public void ReturnDown_WhenSeedEqualsTwo() {
            var mover = new RandomMover(2);

            mover.SelectNextMove(null, allMoves).ShouldBe("DOWN");
        }

        [Fact]
        public void ReturnUp_WhenSeedEqualsThree() {
            var mover = new RandomMover(3);

            mover.SelectNextMove(null, allMoves).ShouldBe("UP");
        }
    }
}
