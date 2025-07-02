namespace GamingTime;

public class Enemy
{
    public string EnemyName;
    public int Hp;
    public int Mp;
    public int Lvl;
    public int Atk;
    public int Def;
    public int Spd;

    public Enemy(string enemyName, int hp, int mp, int lvl, int atk, int def, int spd)
    {
        EnemyName = enemyName;
        Hp = hp;
        Mp = mp;
        Lvl = lvl;
        Atk = atk;
        Def = def;
        Spd = spd;
    }

    public readonly List<string> EnemyNames = ["Fisher", "Walter", "Gert", "Slink", "Chris", "Connor", "Ruben", "Lars", "Eagle", "Starch", "Fern", "Horatio", "Sinda", "Liss", "Pascal", "Sploinky"];
}