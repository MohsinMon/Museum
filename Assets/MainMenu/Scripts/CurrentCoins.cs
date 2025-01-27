using UnityEngine;
using UnityEngine.UI;

public class CurrentCoins : MonoBehaviour
{
    public Text CoinText;
   void OnEnable()
    {
        CoinText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
