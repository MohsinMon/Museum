using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public LevelsSprites[] LevelSprites=new LevelsSprites[0];
    public GameObject LevelPrefab;
    public Transform Content;
    public GameObject LoadingPanel;


    Sprite Locked;
    Sprite Unlocked;
    Sprite Selected;
    void Start()
    {

        if (PlayerPrefs.GetInt(Constants.CurrentMode + "FirstLevel") != 1)
        {
            PlayerPrefs.SetInt(Constants.CurrentMode + "LevelCompleted", 1);
            PlayerPrefs.SetInt(Constants.CurrentMode + "FirstLevel", 1);
        }

        for (int i = 0; i < LevelSprites.Length; i++)
        {
            if (LevelSprites[i].SceneName == Constants.CurrentMode)
            {
                Locked = LevelSprites[i].Locked;
                Unlocked = LevelSprites[i].Unlocked;
                Selected = LevelSprites[i].Selected;
            }
        }
        Debug.LogError("LevelCompleted" + PlayerPrefs.GetInt(Constants.CurrentMode + "LevelCompleted"));
        for (int i = 0; i < Constants.TotalLevel; i++)
        {
            GameObject level = Instantiate(LevelPrefab, Content);

            if (i < PlayerPrefs.GetInt(Constants.CurrentMode + "LevelCompleted"))
            {
                level.GetComponent<Button>().interactable = true;
                int r = i;
                level.GetComponent<Button>().onClick.AddListener(() => Playlevel(r));
                level.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
                if (Unlocked) level.GetComponent<Image>().sprite = Unlocked;
            }
            else
            {
                level.GetComponent<Button>().interactable = false;
                level.transform.GetChild(0).GetComponent<Text>().text = "";
                if (Locked) level.GetComponent<Image>().sprite = Locked;

            }
        }

    }
    public void Playlevel(int LevelNo)
    {
        Constants.CurrentLevel = LevelNo;
        if (LoadingPanel != null)
            LoadingPanel.SetActive(true);
        SceneManager.LoadScene("ObjectSelection");
        SoundManager.Instance.PlayButtonSound();
        Debug.Log(LevelNo);
    }
    public void Back()
    {
        if (LoadingPanel != null)
            LoadingPanel.SetActive(true);
        SceneManager.LoadScene("ModeSelection");
        SoundManager.Instance.PlayButtonSound();
    }

    [System.Serializable]
    public class LevelsSprites
    {
        public string SceneName;
        public Sprite Locked;
        public Sprite Unlocked;
        public Sprite Selected;
    }
}
