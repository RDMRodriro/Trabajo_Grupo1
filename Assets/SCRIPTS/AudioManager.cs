using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume;

            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
