namespace GamingTime
{
    public class Game
    {
        private static Player _player = new();
        private static Overworld _overworld = new(_player);
        private static float _textSpeed = 1;
        
        private static readonly List<string> BannedNames =
        [
            "balls",
            "dick",
            "ass",
            "fuck",
            "cum"
        ];

        public Game(Player player)
        {
            _player = player;
        }

        public static void Main()
        {
            _player = new Player();
            _overworld = new Overworld(_player);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLines("What's your name again?", 100);
            while (_player.PlayerName == "placeholder")
            {
                _player.PlayerName = Console.ReadLine()!;
                if (_player.PlayerName.Length > 12 || _player.PlayerName.Length < 3 || BannedNames.Contains(_player.PlayerName.ToLower()))
                {
                    _player.PlayerName = "placeholder";
                    WriteLines("No, it isn't", 100);
                }
            }
            WriteLines("Are you a fast reader?", 100);
            WriteLines("Y | N", 100);
            var s = Console.ReadKey(true).Key;
            while (!(s == ConsoleKey.Y || s == ConsoleKey.N))
            {
                WriteLines("Are you a fast reader?", 100);
                WriteLines("Y | N", 100);
                s = Console.ReadKey(true).Key;
            }
            if (s == ConsoleKey.Y)
            {
                _textSpeed = (float)0.5;
            }
            if (s == ConsoleKey.N)
            {
                _textSpeed = 1;
            }
            WriteLines($"{_player.PlayerName}, do you remember what happened?", 100);
            WriteLines("Jerry stole your wife, your kids, your eggs, your grass, your underwear and even your floor", 100);
            Thread.Sleep(500);
            WriteLines("Kill him.", 500);
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLines("You are in a forest", 50);
            Thread.Sleep(500);
            WriteLines("You spot Jerry nearby", 50);
            _overworld.Run(_player);
        }

        public static void WriteLines(string text, int textSpeed)
        {
            foreach (var line in text.ToList())
            {
                Console.Write(line);
                Thread.Sleep((int)(textSpeed * _textSpeed));
            }
            Console.WriteLine();
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}