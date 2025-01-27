using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingPanel;
    [SerializeField] private int startingScore;

    void Start()
    {
        if (PlayerPrefs.GetInt("FirstTimeMain") != 1)
        {
            PlayerPrefs.GetInt("AmbientSound", 3);
            PlayerPrefs.SetInt("Truck0", 3);
            PlayerPrefs.SetInt("Coins", startingScore);
            PlayerPrefs.SetInt("FirstTimeMain", 1);

        }
        Time.timeScale = 1;
        SoundManager.Instance.MainMusic.volume = 0.5f;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void SetTrue(GameObject target)
    {
        target.SetActive(true);
    }

    public void SetFalse(GameObject target)
    {
        target.SetActive(false);
    }

    public void ToggleObject(GameObject target)
    {
        target.SetActive(!target.activeSelf);
    }

    public void StartButton(string SceneName)
    {
        if (LoadingPanel != null)
            LoadingPanel.SetActive(true);
        SceneManager.LoadScene(SceneName);
    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
    public void reteUs()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
