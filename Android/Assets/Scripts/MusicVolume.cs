using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public AudioSource mixer;
    public Slider slider;

    void Start()
    {
        
        mixer = FindObjectOfType<AudioPlayerManager>().gameObject.GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("MusicVol");
    }

    public void SetLevel()
    {
        float sliderValue = slider.value;
        mixer.volume = slider.value;
        //mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }
}