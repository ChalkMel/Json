using System;

[Serializable]
public class Weapon 
{
    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public float Cooldown { get; protected set; }

    public Weapon(string name, int damage, float cooldown)
    {
        Name = name;
        Damage = damage;
        Cooldown = cooldown;
    }
}
