using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorPowerUp : MonoBehaviour
{
    private GameObject armor;
    // Start is called before the first frame update
    void Start()
    {
        armor=transform.Find("Armor").gameObject;
    }

    void OnEnable(){
        armor=transform.Find("Armor").gameObject;
        armor.SetActive(true);
        StartCoroutine(Timeout());
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="Power Up: Armor";
    
    }
    void OnDisable(){
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="";
        armor.SetActive(false);
    }

    IEnumerator Timeout(){
        yield return new WaitForSeconds(10);
        enabled=false;
    }
}
