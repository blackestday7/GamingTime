using System.Numerics;

namespace GamingTime;

public class Player
{
    public Random rand = new Random();
    public string PlayerName;
    public int Hp;
    public int MaxHp;
    public int Mp;
    public int Lvl;
    public int Exp;
    public int Gold;
    public int Atk;
    public int Def;
    public int Spd;
    public int Stat_points;
    public Vector2 Coords;
    public int ExpVec = 5;

    public Player()
    {
        PlayerName = "placeholder";
        MaxHp = 12;
        Hp = 12;
        Mp = 5;
        Lvl = 1;
        Exp = 0;
        Gold = 0;
        Atk = 3;
        Def = 1;
        Spd = 1;
        Coords =  new Vector2(0, 0);
    }

    public Player LevelupStats()
    {
        PlayerName = "level";
        Hp = rand.Next(8);
        Mp = rand.Next(4);
        Lvl = 1;
        Atk = rand.Next(3);
        Def = rand.Next(3);
        Spd = rand.Next(2);
        return this;
    }
}