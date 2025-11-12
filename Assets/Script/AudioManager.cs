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

   

    void Start()
    {
        

        // Add listeners
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);

        // Apply initial volumes
        ChangeMusicVolume(musicSlider.value);
        ChangeSFXVolume(sfxSlider.value);
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

}