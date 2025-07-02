namespace GamingTime
{
    public class Game
    {
        private static Player Player = new();
        private static Overworld Overworld = new(Player);
        private static float textpeed = 1;
        
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
            Player = player;
        }

        public static void Main()
        {
            Player = new Player();
            Overworld = new Overworld(Player);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLines("What's your name again?", 100);
            while (Player.PlayerName == "placeholder")
            {
                Player.PlayerName = Console.ReadLine();
                if (Player.PlayerName != null && (Player.PlayerName.Length > 12 || Player.PlayerName.Length < 3 || BannedNames.Contains(Player.PlayerName.ToLower())))
                {
                    Player.PlayerName = "placeholder";
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
                textpeed = (float)0.5;
            }
            if (s == ConsoleKey.N)
            {
                textpeed = 1;
            }
            WriteLines($"{Player.PlayerName}, do you remember what happened?", 100);
            WriteLines("Jerry stole your wife, your kids, your eggs, your grass, your underwear and even your floor", 100);
            Thread.Sleep(500);
            WriteLines("Kill him.", 500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLines("You are in a forest", 50);
            Thread.Sleep(500);
            WriteLines("You spot Jerry nearby", 50);
            Overworld.Run(Player);
        }

        public static void WriteLines(string text, int textSpeed)
        {
            foreach (var line in text.ToList())
            {
                Console.Write(line);
                Thread.Sleep((int)(textSpeed * textpeed));
            }
            Console.WriteLine();
        }

        public static void Quit()
        {
            Environment.Exit(0);
        }
    }
}