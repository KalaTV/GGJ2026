using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
 
public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
 
    private void Start()
    {
        SaveVolume();
        LoadVolume();
        MusicManager.Instance.PlayMusic("Main Menu");
    }
 
    public void Play()
    {
        LevelManager.Instance.LoadScene("LD", "CrossFade");
        MusicManager.Instance.PlayMusic("Game");
    }
 
    public void Quit()
    {
        Application.Quit();
    }
 
    public void UpdateMusicVolume(float volume)
    {
        volume = musicSlider.value;
        audioMixer.SetFloat("MusicVolume", volume);
    }
 
    public void UpdateSoundVolume(float volume)
    {
        volume = sfxSlider.value;
        audioMixer.SetFloat("SFXVolume", volume);
    }
 
    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
 
        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }
 
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}