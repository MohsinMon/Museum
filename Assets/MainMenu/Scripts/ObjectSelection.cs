using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectSelection : MonoBehaviour
{
    public AllObjects[] Bulls;
    
    public Button buyBtn;
    public Button Playbtn;
    public Text priceText;
    public Text coinsText;
    public GameObject LoadingScreen;
    private int selectedTruckIndex;
    ObjectData[] currentdata;


    void Start()
    {
        if (PlayerPrefs.GetInt(Constants.modeType.ToString() + "FirstTruck") != 1)
        {
            Debug.Log("aagya yahan");
            PlayerPrefs.SetInt(Constants.modeType.ToString()+"Truck0", 1);
            PlayerPrefs.SetInt(Constants.modeType.ToString() + "FirstTruck", 1);
        }

        selectedTruckIndex = 0;
        Constants.CurrentTruck = selectedTruckIndex;
        //if (Constants.modeType==ModeType.Alpha)
        //{
        //    currentdata = Truck;
        //}
        //else if (Constants.modeType == ModeType.Beta)
        //{
        //    currentdata = Trailer;
        //}
        for (int i = 0; i < Bulls.Length; i++)
        {
            if (Constants.modeType == Bulls[i].Mode)
            {
                currentdata = Bulls[i].Data; break;
            }
        }
        currentdata[selectedTruckIndex].prefab.SetActive(true);
        UpdateWeaponData();
        UpdateUI();
       
    }

  
    public void ChangeWeapon(bool isRight)
    {
        if (isRight)
        {
            selectedTruckIndex++;
            if (selectedTruckIndex >= currentdata.Length)
            {
                selectedTruckIndex = 0;
            }
        }
        else
        {
            selectedTruckIndex--;
            if (selectedTruckIndex < 0)
            {
                selectedTruckIndex = currentdata.Length - 1;
            }
        }
       // PlayerPrefs.SetInt(Constants.SelectVehicleType + "Truck" + selectedTruckIndex, 1);
        Constants.CurrentTruck = selectedTruckIndex;
        UpdateWeaponData();
        SoundManager.Instance.PlayButtonSound();
    }

    public void BuyWeapon()
    {
        if (PlayerPrefs.GetInt("Coins") >= currentdata[selectedTruckIndex].Price)
        {
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - currentdata[selectedTruckIndex].Price));
            PlayerPrefs.SetInt(Constants.modeType.ToString() + "Truck"+selectedTruckIndex, 1);
        }
        else
        {
            //Adsmanager.instance._ShowAndroidToastMessage("Not Enough Coins");
        }
        UpdateUI();
        SoundManager.Instance.PlayButtonSound();
    }

    private void UpdateWeaponData()
    {
        for (int i = 0; i < currentdata.Length; i++)
        {
            if (i == selectedTruckIndex)
            {
                currentdata[selectedTruckIndex].prefab.SetActive(true);
            }
            else
            {
                currentdata[i].prefab.SetActive(false);
            }
        }
        UpdateUI();
    }


    private void UpdateUI()
    {
      
        priceText.text = "PRICE "+currentdata[selectedTruckIndex].Price.ToString();
        if (PlayerPrefs.GetInt(Constants.modeType.ToString() + "Truck" + selectedTruckIndex) == 1)
        {
            buyBtn.gameObject.SetActive(false);
           // Lock.SetActive(false);
            Playbtn.gameObject.SetActive(true);
        }
        else
        {
            buyBtn.gameObject.SetActive(true) ;
           // Lock.SetActive(true) ;
            Playbtn.gameObject.SetActive(false) ;
        }
        coinsText.text = "Coins "+PlayerPrefs.GetInt("Coins").ToString();
    }

    public void Back()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene("LevelSelection");
        SoundManager.Instance.PlayButtonSound();
    }
    public void Select()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(Constants.CurrentMode);
        SoundManager.Instance.PlayButtonSound();
    }

    [System.Serializable]
    public class ObjectData
    {
        public string ObjectName;
        public GameObject prefab;
        public int Price;

    }
    [System.Serializable]
    public class AllObjects
    {
        public ModeType Mode;
        public ObjectData[] Data;
    }
}
