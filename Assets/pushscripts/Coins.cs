using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    public TextMeshProUGUI coins,magicGreen;
    int coinpoint,magicGreenC;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.tag=="coin")
        {
            coinpoint++;
            Destroy(other.gameObject);
            
        }

        else if (other.gameObject.tag == "magicGreen")
        {
            magicGreenC++;
        }
      }
    // Update is called once per frame
    void Update()
    {
        coins.text = coinpoint.ToString();
        magicGreen.text = magicGreenC.ToString();
    }

   
}
