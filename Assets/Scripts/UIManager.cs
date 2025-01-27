using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject Pause, InfoPanel,eButton;
    public TextMeshProUGUI infoText,headerText;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InfoPanel.activeSelf)
            {
                InfoPanel.SetActive(false);
                eButton.SetActive(true) ;
            }
            else
            {
                Time.timeScale = 0;
                Pause.SetActive(true);
            }
        }
        //if (ControlFreak2.CF2Input.GetButtonDown("Sprint"))
        //{
        //    Time.timeScale = 0;
        //    CF2Panel.SetActive(false);
        //    ObjectiveScreen.SetActive(true);
        //}
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
    public void Next()
    {
        Time.timeScale = 1;
        Constants.CurrentLevel++;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void InfoPanelStatus(bool val,string header="",string fulltext="")
    {
        if (val)
        {
            InfoPanel.SetActive(true);
            fullText = fulltext;
            headerText.text= header;
            StartCoroutine(TypeText());
        }
        else
        {
            InfoPanel.SetActive(false);
        }
    }

    public float typingSpeed = 0.001f; 
    public string fullText; 
    private string currentText = "";


    

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            currentText += letter;
            infoText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


}
