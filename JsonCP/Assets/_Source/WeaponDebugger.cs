using _Source.Utilits;
using UnityEngine;
using Newtonsoft.Json;

public class WeaponDebugger : MonoBehaviour
{
  [SerializeField] private TextAsset weaponDataFile;
    
  private void Awake()
  {
    weaponDataFile = Resources.Load<TextAsset>(CSVUtil.json_file_name);
        
    if (weaponDataFile == null)
    {
      Debug.LogError("No json file found");
      return;
    }
        
    WeaponDataBase db = JsonConvert.DeserializeObject<WeaponDataBase>(weaponDataFile.text);
        
    foreach (var weapon in db.Weapons)
    {
      Debug.Log($"Weapon: {weapon.Name}, {weapon.Damage}, {weapon.Cooldown}");
    }
  }
}