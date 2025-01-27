using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelection : MonoBehaviour
{
    public ModeDetail[] Modes;
    public GameObject LoadingPanel;
    public float LoadingTime;
    private void Start()
    {
        //PlayerPrefs.SetInt("Mode", 4);
        if (PlayerPrefs.GetInt("FirstTimeMode"+Application.version) != 1)
        {
            PlayerPrefs.SetInt("Mode", 1);
            PlayerPrefs.SetInt("FirstMode" + Application.version, 1);
        }
       
        for(int i = 0; i < Modes.Length; i++)
        {
            int mode = i;
            ModeDetail currentMode = Modes[mode];
            if (i< PlayerPrefs.GetInt("Mode"))
            {
                Modes[i].ModeButton.interactable = true;
                Modes[i].ModeButton.onClick.AddListener(()=>SelectMode(currentMode.SceneName, currentMode.ModeType, currentMode.TotalLevel));
                Modes[i].ModeButton.transform.GetChild(2).GetComponent<Text>().text = "";
            }
            else
            {
                Modes[i].ModeButton.interactable = false;
                Modes[i].ModeButton.transform.GetChild(2).GetComponent<Text>().text = "Coming Soon";
            }
        }
       
    }
  
    public void SelectMode(string Mode,ModeType modeType,int TotalLevel)
    { 
        Constants.CurrentMode = Mode;
        Constants.modeType = modeType;
        Constants.TotalLevel= TotalLevel;
        if(LoadingPanel!=null)
        LoadingPanel.SetActive(true);
        Invoke("LoadLevelsWithTime", LoadingTime);
        SoundManager.Instance.PlayButtonSound();

    }

    public void LoadLevelsWithTime()
    {
        SceneManager.LoadScene("LevelSelection");
    }


    public void Back(string SceneName)
    {
        if (LoadingPanel != null)
            LoadingPanel.SetActive(true);
        SceneManager.LoadSceneAsync(SceneName);
        SoundManager.Instance.PlayButtonSound();
    }

    [System.Serializable]
    public class ModeDetail
    {
        [Tooltip("Mode Gameplay Scene Name which will be started after object selection")]
        public string SceneName;
        [Tooltip("Mainly Used for Object Selection, We Can make differnt Object Selection through this value at GunSelection ")]
        public ModeType ModeType;
        public Button ModeButton;
        public int TotalLevel;
        
    }
  
}


