using System.Collections.Generic;

namespace TronBattleBot {
    public class TurnData {
        private List<Cycle> _cycles;

        public TurnData() {
            _cycles = new List<Cycle>();
        }

        public int NumberOfPlayers { get; set; }
        public int PlayerNumber { get; set; }
        public List<Cycle> Cycles => _cycles;
        public string Move { get; set; }
    }
}