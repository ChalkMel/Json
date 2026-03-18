using UnityEngine;
using System.IO;
using UnityEditor;
using Newtonsoft.Json;

public class VolumeDataController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    private const string json_file_name = "SoundData";
    private const string json_file_path = "/_Presentation/Resources/";
    private string _path;
    private VolumeData _volumeData;
    
    private void Awake()
    {
        _path = Application.dataPath + json_file_path + json_file_name + ".json";
        LoadVolume();
    }
    
    private void Update()
    {
        if (_volumeData != null && !Mathf.Approximately(audioSource.volume, _volumeData.Volume))
        {
            _volumeData.Volume = audioSource.volume;
            SaveVolume();
        }
    }
    
    private void LoadVolume()
    {
        if (File.Exists(_path))
        {
            Debug.Log("Sound data found");
            string json = File.ReadAllText(_path);
            _volumeData = JsonConvert.DeserializeObject<VolumeData>(json);
            audioSource.volume = _volumeData.Volume;
        }
        else
        {
            Debug.Log("No sound data found");
            CreateNewVolumeData();
        }
    }
    
    private void CreateNewVolumeData()
    {
        _volumeData = new VolumeData(audioSource.volume);
        SaveVolume();
    }
    
    private void SaveVolume()
    {
        using (StreamWriter sw = new StreamWriter(_path))
        using (JsonWriter jw = new JsonTextWriter(sw))
        {
            jw.Formatting = Formatting.Indented;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jw, _volumeData);
        }
    }
}