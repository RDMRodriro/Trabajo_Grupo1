using UnityEngine;
using UnityEngine.Audio;

public class Menu_Options_Settings : MonoBehaviour
{
    public AudioMixer audioMixerMusica;
    public AudioMixer audioMixerEffects;

    public void SetVolume(float volume)
    {
        audioMixerMusica.SetFloat("volume", volume);
    }

    public void SetVolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }
    
}
