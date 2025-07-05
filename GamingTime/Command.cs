namespace GamingTime;

public class Command
{
    private enum CommandType
    {
        Attack,
        Move,
        Quit,
        Check,
        Status,
        Wrong
    }

    private CommandType _commando;

    public void CheckCommand(ConsoleKey command)
    {
        switch (command)
        {
            default:
                Game.WriteLines("Not a valid command", 50);
                _commando = CommandType.Wrong;
                Game.WriteLines("balls", 50);
                break;
            case(ConsoleKey.A):
                _commando = CommandType.Attack;
                break;
            case(ConsoleKey.M):
                _commando = CommandType.Move;
                break;
            case(ConsoleKey.Q):
                _commando = CommandType.Quit;
                break;
            case(ConsoleKey.C):
                _commando = CommandType.Check;
                break;
            case(ConsoleKey.S):
                _commando = CommandType.Status;
                break;
        }
        if (_commando == CommandType.Wrong)
        {
            return;
        }
        DoCommand(_commando);
    }

    private void DoCommand(CommandType command)
    {
        switch (command)
        {
            case(CommandType.Attack):
                if (Overworld.CurrentMap.Enemies!.Count > 0)
                {
                    Overworld.Attack();
                }
                break;
            case(CommandType.Move):
                Overworld.Move();
                Overworld.Player.Hp = Overworld.Player.MaxHp;
                break;
            case(CommandType.Quit):
                Game.WriteLines("Goodbye", 250);
                Thread.Sleep(1000);
                Game.Quit();
                break;
            case(CommandType.Check):
                string names = "";
                foreach (Enemy enemy in Overworld.CurrentMap.Enemies!)
                {
                    names = names + enemy.EnemyName + " " + enemy.Hp + "hp, ";
                }
                if(names.Any())
                    names.Remove(names.Count() - 1);
                Game.WriteLines($"Enemies: {names}", 50);
                Game.WriteLines($"Coords: {Overworld.CurrentMap.Coords.Item1}, {Overworld.CurrentMap.Coords.Item2}", 50);
                break;
            case (CommandType.Status):
                Game.WriteLines($"Level: {Overworld.Player.Lvl}", 50);
                Game.WriteLines($"Exp: {Overworld.Player.Exp}", 50);
                Game.WriteLines($"Exp to next level: {Overworld.Player.ExpVec - Overworld.Player.Exp}", 50);
                Game.WriteLines($"Hp: {Overworld.Player.Hp}", 50);
                Game.WriteLines($"Mp: {Overworld.Player.Mp}", 50);
                Game.WriteLines($"Atk: {Overworld.Player.Atk}", 50);
                Game.WriteLines($"Def: {Overworld.Player.Def}", 50);
                Game.WriteLines($"Spd: {Overworld.Player.Spd}", 50);
                if (Overworld.Player.StatPoints > 0)
                {
                        Game.WriteLines($"You have {Overworld.Player.StatPoints} unused stat points", 50);
                        Game.WriteLines("I: Use stat points", 50);
                        Game.WriteLines("E: Don't use stat points", 50);
                        var k = Console.ReadKey(true).Key;
                        if (k == ConsoleKey.I)
                        {
                            bool quit = true;
                            while (Overworld.Player.StatPoints > 0 && quit)
                            {
                                Game.WriteLines("A: Atk", 50);
                                Game.WriteLines("D: Def", 50);
                                Game.WriteLines("S: Spd", 50);
                                Game.WriteLines("H: Hp", 50);
                                Game.WriteLines("M: Mp", 50);
                                Game.WriteLines("Q: quit", 50);
                                k = Console.ReadKey(true).Key;
                                switch (k)
                                {
                                    case ConsoleKey.A:
                                        Overworld.Player.Atk++;
                                        Overworld.Player.StatPoints--;
                                        break;
                                    case ConsoleKey.D:
                                        Overworld.Player.Def++;
                                        Overworld.Player.StatPoints--;
                                        break;
                                    case ConsoleKey.S:
                                        Overworld.Player.Spd++;
                                        Overworld.Player.StatPoints--;
                                        break;
                                    case ConsoleKey.H:
                                        Overworld.Player.Hp += 2;
                                        Overworld.Player.StatPoints--;
                                        break;
                                    case ConsoleKey.M:
                                        Overworld.Player.Mp++;
                                        Overworld.Player.StatPoints--;
                                        break;
                                    case ConsoleKey.Q:
                                        quit = false;
                                        break;
                                }
                            }
                        }
                    
                }
                break;
        }
    }
    
}