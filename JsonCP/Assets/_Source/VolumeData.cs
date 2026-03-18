using System;
[Serializable]
  public class VolumeData
  {
    public float Volume { get; set; }
        
    public VolumeData(float volume)
    {
      Volume = volume;
    }
}