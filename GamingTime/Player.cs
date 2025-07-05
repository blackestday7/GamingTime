using System.Numerics;

namespace GamingTime;

public class Player
{
    public string PlayerName = "placeholder";
    public int Hp = 12;
    public readonly int MaxHp = 12;
    public int Mp = 5;
    public readonly int Lvl = 1;
    public int Exp = 0;
    public int Gold = 0;
    public int Atk = 3;
    public int Def = 1;
    public int Spd = 1;
    public int StatPoints;
    public Vector2 Coords = new(0, 0);
    public int ExpVec = 5;
}