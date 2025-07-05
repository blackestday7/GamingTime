namespace GamingTime;

public class Enemy(string enemyName, int hp, int mp, int lvl, int atk, int def, int spd)
{
    public readonly string EnemyName = enemyName;
    public int Hp = hp;
    public int Mp = mp;
    public readonly int Lvl = lvl;
    public readonly int Atk = atk;
    public readonly int Def = def;
    public readonly int Spd = spd;

    public readonly List<string> EnemyNames = ["Fisher", "Walter", "Gert", "Slink", "Chris", "Connor", "Ruben", "Lars", "Eagle", "Starch", "Fern", "Horatio", "Sina", "Less", "Pascal", "Slinky"];
}