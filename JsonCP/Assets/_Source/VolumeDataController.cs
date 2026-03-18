using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;
public class VolumeDataController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;
    private const string json_file_name = "SoundData";
    private string _path;
    private VolumeData _volumeData;
    
    private void Awake()
    {
        _path = Application.persistentDataPath + json_file_name + ".json";
        LoadVolume();
        slider.onValueChanged.AddListener(delegate { SaveVolume(); });
    }
    
    private void LoadVolume()
    {
        if (File.Exists(_path))
        {
            Debug.Log("Sound data found");
            string json = File.ReadAllText(_path);
            _volumeData = JsonConvert.DeserializeObject<VolumeData>(json);
            audioSource.volume = _volumeData.Volume;
            slider.value = _volumeData.Volume;
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
        slider.value = _volumeData.Volume;
        SaveVolume();
    }
    
    private void SaveVolume()
    {
        audioSource.volume = slider.value;
        _volumeData.Volume = audioSource.volume;
        using (StreamWriter sw = new StreamWriter(_path))
        using (JsonWriter jw = new JsonTextWriter(sw))
        {
            jw.Formatting = Formatting.Indented;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jw, _volumeData);
        }
    }
}