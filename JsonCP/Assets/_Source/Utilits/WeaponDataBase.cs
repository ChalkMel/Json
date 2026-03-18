using System;

namespace _Source.Utilits
{
  public class WeaponDataBase
  {
    public Weapon[]  Weapons { get; private set; }

    public WeaponDataBase(Weapon[] weapons)
    {
      Weapons = weapons;
    }
    
  }
}