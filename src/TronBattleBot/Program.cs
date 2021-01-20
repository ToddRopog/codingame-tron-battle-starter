using System;
using TronBattleBot;
using TronBattleBot.Movers;

class Program {
    static void Main(String[] args) {
        
        var bot = new Bot(new ValidMoveGetter());
        bot.AddMover("Random", new RandomMover(DateTime.Now.Millisecond));
        bot.AddMover("Inertia", new InertiaMover());

        var game = new GameState(30, 20);

        while (true) {
            var currentTurn = GetCurrentTurnData();
            game.UpdateGameState(currentTurn);
            currentTurn.Move = bot.GetNextMove(game);
            SubmitMove(currentTurn.Move);
        }
    }

    private static void SubmitMove(string move) {
        Console.WriteLine(move);
    }

    private static TurnData GetCurrentTurnData() {
        var newTurn = new TurnData();
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        newTurn.NumberOfPlayers = int.Parse(inputs[0]); // total number of players (2 to 4).
        newTurn.PlayerNumber = int.Parse(inputs[1]); // your player number (0 to 3).

        for (int i = 0; i < newTurn.NumberOfPlayers; i++) {
            inputs = Console.ReadLine().Split(' ');
            var cycle = new Cycle { Number = i };
            cycle.Tail = new Coordinates(int.Parse(inputs[0]), int.Parse(inputs[1]));
            cycle.Head = new Coordinates(int.Parse(inputs[2]), int.Parse(inputs[3]));

            newTurn.Cycles.Add(cycle);
        }

        return newTurn;
    }
}