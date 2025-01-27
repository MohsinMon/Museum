using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] bulls;
    public LevelInfo[] Levels;

    public GameObject[] ObjectsToTurnOn;
    public GameObject[] ObjectToTurnOff;
    public long TargetKills;
    public long Kills;
    public bool IsStart;
    void Start()
    {
       
        SoundManager.Instance.MainMusic.volume = 0;
    }

    public void Objective()
    {
        Debug.Log("55");
        foreach (GameObject obj in ObjectToTurnOff)
        {
            obj.SetActive(false);
        }
        foreach (GameObject vad in ObjectsToTurnOn)
        {
            vad.SetActive(true);
        }
        IsStart=true;
        Time.timeScale = 1;
        Debug.Log("@");
    }

 

    

   

    [System.Serializable]
    public class LevelInfo
    {
        public GameObject Level;
        public string Description;
        public int Time;
    }
}
