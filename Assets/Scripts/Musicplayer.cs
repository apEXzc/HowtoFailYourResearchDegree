using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musicplayer : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource AudioSource;
    private float musicVolume = 1f;
    public Slider volumeSlider;
    public GameObject Objectmusic;
    void Start()
    {
        Objectmusic = GameObject.FindWithTag("Music");
        AudioSource = Objectmusic.GetComponent<AudioSource>();

        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;

}

// Update is called once per frame
void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);

    }


public void updatevolume(float volume)
    {
        musicVolume = volume;
    }
}
