using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip jump;
    public AudioClip Key;
    public AudioClip Dam;
    public AudioClip wins;

   

    void Start()
    {

    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void JumpSound()
    {
        sfxSource.PlayOneShot(jump);
    }
    public void Damge()
    {
        sfxSource.PlayOneShot(Dam);
    }
    public void keys()
    {
        sfxSource.PlayOneShot(Key);

    }
    public void win()
    {
        sfxSource.PlayOneShot(wins);
    }

}