using System.Collections.Immutable;

namespace GamingTime;

public class Command
{
    public enum CommandType
    {
        Attack,
        Move,
        Quit,
        Check,
        Status,
        Wrong
    } 
    public CommandType Commando;

    public void CheckCommand(ConsoleKey command)
    {
        switch (command)
        {
            default:
                Game.WriteLines("Not a valid command", 50);
                Commando = CommandType.Wrong;
                Game.WriteLines("balls", 50);
                break;
            case(ConsoleKey.A):
                Commando = CommandType.Attack;
                break;
            case(ConsoleKey.M):
                Commando = CommandType.Move;
                break;
            case(ConsoleKey.Q):
                Commando = CommandType.Quit;
                break;
            case(ConsoleKey.C):
                Commando = CommandType.Check;
                break;
            case(ConsoleKey.S):
                Commando = CommandType.Status;
                break;
        }
        if (Commando == CommandType.Wrong)
        {
            return;
        }
        DoCommand(Commando);
    }

    public void DoCommand(CommandType command)
    {
        switch (command)
        {
            default:
                break;
            case(CommandType.Attack):
                if (Overworld.CurrentMap.Enemies.Count > 0)
                {
                    Overworld.Attack();
                }
                break;
            case(CommandType.Move):
                Overworld.Move();
                Overworld.player.Hp = Overworld.player.MaxHp;
                break;
            case(CommandType.Quit):
                Game.WriteLines("Goodbye", 250);
                Thread.Sleep(1000);
                Game.Quit();
                break;
            case(CommandType.Check):
                string names = "";
                foreach (Enemy enemy in Overworld.CurrentMap.Enemies)
                {
                    names = names + enemy.EnemyName + " " + enemy.Hp + "hp, ";
                }
                if(names.Count() > 0)
                    names.Remove(names.Count() - 1);
                Game.WriteLines($"Enemies: {names}", 50);
                Game.WriteLines($"Coords: {Overworld.CurrentMap.Coords.X}, {Overworld.CurrentMap.Coords.Y}", 50);
                break;
            case (CommandType.Status):
                bool status = true;
                Game.WriteLines($"Level: {Overworld.player.Lvl}", 50);
                Game.WriteLines($"Exp: {Overworld.player.Exp}", 50);
                Game.WriteLines($"Exp to next level: {Overworld.player.ExpVec - Overworld.player.Exp}", 50);
                Game.WriteLines($"Hp: {Overworld.player.Hp}", 50);
                Game.WriteLines($"Mp: {Overworld.player.Mp}", 50);
                Game.WriteLines($"Atk: {Overworld.player.Atk}", 50);
                Game.WriteLines($"Def: {Overworld.player.Def}", 50);
                Game.WriteLines($"Spd: {Overworld.player.Spd}", 50);
                if (Overworld.player.Stat_points > 0)
                {
                        Game.WriteLines($"You have {Overworld.player.Stat_points} unused stat points", 50);
                        Game.WriteLines("I: Use stat points", 50);
                        Game.WriteLines("E: Don't use stat points", 50);
                        var k = Console.ReadKey(true).Key;
                        if (k == ConsoleKey.I)
                        {
                            bool quit = true;
                            while (Overworld.player.Stat_points > 0 && quit)
                            {
                                Game.WriteLines("A: Atk", 50);
                                Game.WriteLines("D: Def", 50);
                                Game.WriteLines("S: Spd", 50);
                                Game.WriteLines("H: Hp", 50);
                                Game.WriteLines("M: Mp", 50);
                                Game.WriteLines("Q: quit", 50);
                                k = Console.ReadKey().Key;
                                switch (k)
                                {
                                    case ConsoleKey.A:
                                        Overworld.player.Atk++;
                                        Overworld.player.Stat_points--;
                                        break;
                                    case ConsoleKey.D:
                                        Overworld.player.Def++;
                                        Overworld.player.Stat_points--;
                                        break;
                                    case ConsoleKey.S:
                                        Overworld.player.Spd++;
                                        Overworld.player.Stat_points--;
                                        break;
                                    case ConsoleKey.H:
                                        Overworld.player.Hp += 2;
                                        Overworld.player.Stat_points--;
                                        break;
                                    case ConsoleKey.M:
                                        Overworld.player.Mp++;
                                        Overworld.player.Stat_points--;
                                        break;
                                    case ConsoleKey.Q:
                                        quit = false;
                                        break;
                                }
                            }
                        }
                        else if (k == ConsoleKey.E)
                        {
                            break;
                        }
                }
                break;
        }
    }
    
}