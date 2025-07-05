namespace GamingTime;

public class Overworld
{
    private static readonly MapSegment[,] Map = new  MapSegment[5, 5];
    public static MapSegment CurrentMap = new();
    public static Player Player = null!;
    private static readonly Random Random = new();
    private static readonly Enemy Enemy = new(null!, 0, 0, 0, 0, 0, 0);

    private readonly string[] _flavorTexts =
    [
        "Quiet tree limbs dangled from many trees, and a mishmash of flowers, which were unique to this region, spruced up the otherwise dark backdrop.",
        "A discord of wild noises, which were caused by varmint, echoed in the air, and drowned out the sound of the wind blowing gently through the forest.",
        "an array of flowers, which desperately tried to claim the last remnants of light, brightened up the otherwise unchanging terrain.",
        "The forest was enormous, bright, and rich. Its canopy was marked by yew, chestnut, and asp, who allowed adequate light to pass down for a range of plants to claim the moist and fertile bottom layer below.",
        "Bundled branches suspended from every tree, and a potpourri of flowers, which blossomed brightly, added some bright touches to the otherwise mundane forest floor.",
        "A cacophony of sounds, which were caused by herds of larger animals, filled the air, and drowned out the swaying of tree tops in the wind.",
        "The forest was humble, compact, and archaic. Its canopy was contested by holly, larch, and sequoia, their crowns allowed cascading lights to shimmer through for a patchwork of saplings to rule the moist and fertile bottom layer below.",
        "Curling tree limbs held onto many trees, and a potluck of flowers, which were new to this region, caught attention in the otherwise unvarying lower level.",
        "A variety of noises, belonging mostly to foraging beasts, reverberated through the air, and were out of sync with the splashing of fish in a nearby lake."
    ];
    public Overworld(Player player)
    {
        Player = player;
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                Map[i, j] = new MapSegment
                {
                    Coords = new(i, j),
                    FlavorText = _flavorTexts[Random.Next(0, _flavorTexts.Length)],
                    Enemies = []
                };
                if (Random.Next(1) == 0)
                {
                    var s = Random.Next(4);
                    switch (s)
                    {
                        case 0:
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            break;
                        case 1:
                            break;
                        case 2:
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            break;
                        case 3:
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            Map[i, j].Enemies!.Add(new(Enemy.EnemyNames[Random.Next(16)], Random.Next(1, 3 + ((i + j) * 2)),
                                Random.Next(6 + i + j), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j))), Random.Next(1, 1 + ((i + j)))));
                            break;
                    }
                }
            }
        }
        Player.Coords = new(0, 0);
        Map[0, 0].Enemies!.Add(new("Jerry", 2, 1, 1, 0, 0, 0));
        Map[1, 1].Enemies!.Add(new("Jerry-Gear 2", 6, 2, 2, 2, 2, 2));
        Map[2, 2].Enemies!.Add(new("Jerry-Gear 3", 12, 3, 3, 4, 4, 4));
        Map[3, 3].Enemies!.Add(new("Jerry-Gear 4", 18, 5, 4, 7, 6, 5));
        Map[4, 4].Enemies = [new Enemy("Jerry-Gear 5", 30, 10, 5, 13, 11, 10)];
        CurrentMap = Map[0, 0];
    }

    private readonly Command _command = new();
    public void Run(Player player)
    {
        while(player.Hp > 0)
        {
            Game.WriteLines("What are you going to do?", 50);
            Thread.Sleep(500);
            Game.WriteLines("A: Attack | M: Move | Q: Quit | C: Check | S: Status", 50);
            _command.CheckCommand(Console.ReadKey(true).Key);
        }
        Game.WriteLines("You can't die yet, Get up....", 200);
        Game.WriteLines("Continue?", 100);
        Game.WriteLines("Y | N", 100);
        var key =  Console.ReadKey(true).Key;
        if (key == ConsoleKey.Y)
        {
            Game.Main();
        }
        if (key == ConsoleKey.N)
        {
            Environment.Exit(0);
        }
    }

    public static void Move()
    {
        Game.WriteLines("In which direction?", 50);
        Game.WriteLines("N: North | S: South | E: East | W: West", 50);
        var direction = Console.ReadKey(true).Key;
        switch (direction)
        {
            default:
                Game.WriteLines("Not a direction", 50);
                break;
            case ConsoleKey.N:
                if (Math.Abs(Player.Coords.Y - 4) < 0.1)
                {
                    Game.WriteLines("The world ends here", 50);
                    break;
                }
                Player.Coords.Y++;
                Game.WriteLines("You moved North", 50);
                break;
            case ConsoleKey.S:
                if (Player.Coords.Y == 0)
                {
                    Game.WriteLines("The world ends here", 50);
                    break;
                }
                Player.Coords.Y--;
                Game.WriteLines("You moved South", 50);
                break;
            case ConsoleKey.E:
                if (Math.Abs(Player.Coords.X - 4) < 0.1)
                {
                    Game.WriteLines("The world ends here", 50);
                    break;
                }
                Player.Coords.X++;
                Game.WriteLines("You moved East", 50);
                break;
            case ConsoleKey.W:
                if (Player.Coords.X == 0)
                {
                    Game.WriteLines("The world ends here", 50);
                    break;
                }
                Player.Coords.X--;
                Game.WriteLines("You moved West", 50);
                break;
        }
        CurrentMap = Map[(int)Player.Coords.X, (int)Player.Coords.Y];
        Game.WriteLines(CurrentMap.FlavorText, 50);
    }

    public static void Attack()
    {
        Game.WriteLines("Which enemy?", 50);
        var j = 0;
        foreach (var enemy in  CurrentMap.Enemies!)
        {
            j += 1;
            var i = j + ": " + enemy.EnemyName + " hp: " + enemy.Hp + ".";
            Game.WriteLines(i, 50);
        }
        var etA = Console.ReadKey(true).KeyChar;
        var f = GetNumber(etA) - 1;
        
        if (f >= CurrentMap.Enemies.Count || f < 0)
        {
            Game.WriteLines("That is not a valid enemy", 50);
            return;
        }
        Game.WriteLines("Choose your attack:", 50);
        Game.WriteLines("L: Light Attack", 50);
        Game.WriteLines("H: Heavy Attack", 50);
        var key = Console.ReadKey(true).Key;
        int damage;
        int acc;
        while (!(key == ConsoleKey.L || key == ConsoleKey.H))
        {
            Game.WriteLines("Not a valid attack", 50);
            key = Console.ReadKey(true).Key;
        }
        if (key == ConsoleKey.L) 
        {
                damage = Player.Atk - CurrentMap.Enemies[f].Def +
                       Random.Next(-Player.Lvl, Player.Lvl + 1) + Random.Next(-Player.Lvl, Player.Lvl + 1);
                acc = Random.Next(0, 7) + Player.Spd - CurrentMap.Enemies[f].Spd; 
        }
        else
        {
                damage = Player.Atk - CurrentMap.Enemies[f].Def +
                       Random.Next(-Player.Lvl + 1, Player.Lvl + 2) + Random.Next(-Player.Lvl + 1, Player.Lvl + 2);
                acc = Random.Next(0, 3) + Player.Spd - CurrentMap.Enemies[f].Spd;
        }
        if (acc <= 0)
        {
            Game.WriteLines("You missed!", 50);
        }
        else if (damage <= 0)
        {
            Game.WriteLines("They blocked!", 50);
        }
        else
        {
            CurrentMap.Enemies[f].Hp -= damage;
            Console.ForegroundColor = ConsoleColor.Red;
            Game.WriteLines($"{Player.PlayerName} did {damage} damage", 50);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        if (CurrentMap.Enemies[f].Hp <= 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (CurrentMap.Enemies[f].EnemyName == "Jerry" || CurrentMap.Enemies[f].EnemyName == "Jerry-Gear 2" ||
                CurrentMap.Enemies[f].EnemyName == "Jerry-Gear 3" || CurrentMap.Enemies[f].EnemyName == "Jerry-Gear 4")
            {
                Game.WriteLines("Jerry ran away.", 50);
            }
            else if (CurrentMap.Enemies[f].EnemyName == "Jerry-Gear 5")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Game.WriteLines("You finally took your revenge.", 100);
                Game.WriteLines("Jerry is dead, but so are your wife and kids.", 100);
                Game.WriteLines("Welp, time to find a new wife.", 100);
                Game.WriteLines("Play again?", 100);
                Game.WriteLines("Y | N", 100);
                var gey = Console.ReadKey(true).Key;
                while (!(gey == ConsoleKey.Y || gey == ConsoleKey.N))
                { 
                    Game.WriteLines("Make up your mind!", 50);
                    gey = Console.ReadKey(true).Key;
                }
                if (gey == ConsoleKey.Y)
                {
                    Game.Main();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Game.WriteLines($"{CurrentMap.Enemies[f].EnemyName} died a pitiful death", 50);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            var b = (int)Math.Ceiling((CurrentMap.Enemies[f].Lvl *
                                               ((CurrentMap.Coords.Item1 + (float)CurrentMap.Coords.Item2 + 1) / 2)));
            Player.Exp += b;
            Game.WriteLines($"You gained {b} Exp", 50);
            if (Player.Exp >= Player.ExpVec)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Game.WriteLines("You leveled up! Don't forget to use your new stat points", 50);
                Player.Exp -= Player.ExpVec;
                var r = Random.Next(2, 8);
                Player.StatPoints += r;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Game.WriteLines($"You got {r} stat points", 50);
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.ExpVec = (int)Math.Ceiling(Math.Pow(Player.ExpVec, 1.1));
            }
            CurrentMap.Enemies.RemoveAt(f);
        }
        if (CurrentMap.Enemies.Count <= 0) return;
        Game.WriteLines("But the enemy fights back!", 50);
        foreach (var mainEnemy in CurrentMap.Enemies)
        {
            var run = Player.Def - Player.Spd;
            if (run < 0)
            {
                run = Random.Next(-10, 4);
            }
            else if (run > 0)
            {
                run = Random.Next(-3, 11);
            }
            else
            {
                run = Random.Next(-10, 11);
            }
            int h;
            int hAcc;
            if (run > 0)
            {
                h = mainEnemy.Atk - Player.Def + Random.Next(-mainEnemy.Lvl + 1, mainEnemy.Lvl + 1);
                hAcc = mainEnemy.Spd - Player.Spd + Random.Next(-mainEnemy.Lvl, mainEnemy.Lvl);
                Game.WriteLines($"{mainEnemy.EnemyName} did a heavy attack", 50);
            }
            else if (run < 0)
            {
                h = mainEnemy.Atk - Player.Def + Random.Next(-mainEnemy.Lvl, mainEnemy.Lvl);
                hAcc = mainEnemy.Spd - Player.Spd + Random.Next(-mainEnemy.Lvl + 1, mainEnemy.Lvl + 1);
                Game.WriteLines($"{mainEnemy.EnemyName} did a light attack", 50);
            }
            else
            {
                h = mainEnemy.Atk - Player.Def + Random.Next(-mainEnemy.Lvl, mainEnemy.Lvl);
                hAcc = mainEnemy.Spd - Player.Spd + Random.Next(-mainEnemy.Lvl, mainEnemy.Lvl);
                Game.WriteLines($"{mainEnemy.EnemyName} did a clumsy attack", 50);
            }
            if (hAcc <= 0)
            {
                Game.WriteLines($"{mainEnemy.EnemyName} missed", 50);
            }
            else if (h <= 0)
            {
                Game.WriteLines("You blocked the hit", 50);
            }
            else
            {
                Player.Hp -= h;
                Console.ForegroundColor = ConsoleColor.Red;
                Game.WriteLines($"{mainEnemy.EnemyName} did {h} damage", 50);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }

    public static int GetNumber(char character)
    { 
        return character - '0';
    }
}

public class MapSegment
{
    public List<Enemy>? Enemies;
    public (int, int) Coords;
    public string FlavorText = null!;
}