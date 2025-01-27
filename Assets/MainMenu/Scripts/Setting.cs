using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Toggle Music;
    public Toggle Sound;


    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound.isOn = true;
            SoundState(true);
        }
        else
        {
            Sound.isOn = false;
            SoundState(false);
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Music.isOn = true;
            MusicState(true);
        }
        else
        {
            Music.isOn = false;
            MusicState(false);
        }
    }
    public void SoundState(bool state)
    {
        if(state)
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Sound", 1);
        }
        
    } public void MusicState(bool state)
    {
        if (state)
        {
            SoundManager.Instance.MainMusic.volume = 0.5f;
            PlayerPrefs.SetInt("Music",0);
        }
        else
        {
            SoundManager.Instance.MainMusic.volume = 0;
            PlayerPrefs.SetInt("Music", 1);
        }
    }
}
