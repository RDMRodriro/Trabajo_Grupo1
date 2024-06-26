using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class Menu_Options_Settings : MonoBehaviour
{
    public AudioMixer audioMixerMusica;
    public AudioMixer audioMixerEffects;
    public Toggle toggle;
    public Dropdown dropdown;
    public int calidad;

    void Start ()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = calidad;
        AjustarCalidad();
    }
    public void SetVolume(float volume)
    {
        audioMixerMusica.SetFloat("volume", volume);
    }

    public void SetVolumeEffects(float volume)
    {
        audioMixerEffects.SetFloat("volume", volume);
    }
    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        calidad = dropdown.value;
    }
    public void SetFullScreen(bool isfullScreen)
    {
        Screen.fullScreen = isfullScreen;
    }
    
}
