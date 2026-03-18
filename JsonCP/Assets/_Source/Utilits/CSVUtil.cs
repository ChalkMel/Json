using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

namespace _Source.Utilits
{
  public static class CSVUtil
  {
    private const string csv_file_name = "JsonTest";
    internal const string json_file_name = "WeaponData";
    private const string json_file_path = "/_Presentation/Resources/";

    [MenuItem("Tools/CSVUtils/ParseSCV")]
    public static void ParseCSV()
    {
      TextAsset textAsset = Resources.Load<TextAsset>(csv_file_name);

      if (textAsset == null)
      {
        Debug.LogError("CSV not found");
        return;
      }
      
      string[] lines = textAsset.text.Split('\n');

      if (lines.Length <= 1)
      {
        Debug.LogError("CSV contains no data");
        return;
      }

      List<Weapon> weaponList = new();
      
      for(int i = 1; i < lines.Length; i++)
      {
        string line  = lines[i].Trim();
        string[] colums = line.Split(',');

        if (colums.Length < 3)
        {
          Debug.LogError("CSV contains not enough data");
          return;
        }
        
        string name = colums[0];
        int damage = int.Parse(colums[1]);
        float cooldown = float.Parse(colums[2]);
        
        Weapon weapon = new(name, damage, cooldown);
        weaponList.Add(weapon);
      }

      WeaponDataBase db = new WeaponDataBase(weaponList.ToArray());
      SaveToJson(db);
    }

    private static void SaveToJson(WeaponDataBase db)
    {
      string path = Application.dataPath + json_file_path + json_file_name + ".json";
      using (StreamWriter sw = new StreamWriter(path))
      using (JsonWriter jw = new JsonTextWriter(sw))
      {
        jw.Formatting = Formatting.Indented;
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(jw, db);
      }
    }
  }
}