namespace TronBattleBot {
    public class Cycle {
        public Cycle() {
            Head = new Coordinates(0,0);
            Tail = new Coordinates(0,0);
        }

        public int Number { get; set; }
        public Coordinates Head { get; set; }
        public Coordinates Tail { get; set; }
    }
}
