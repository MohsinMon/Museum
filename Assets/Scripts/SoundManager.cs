using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MainMusic;
    public AudioSource BakiSounds;
    public AudioClip[] AllSounds;

    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayButtonSound()
    {
        BakiSounds.PlayOneShot(AllSounds[0]);
    }
    public void playAnySound(int num)
    {
        BakiSounds.PlayOneShot(AllSounds[num]);
    }
}
