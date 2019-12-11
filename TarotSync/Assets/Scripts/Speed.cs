using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip clip;
    void OnEnable(){
        myAudio.PlayOneShot(clip,1f);
        StartCoroutine(Timeout());
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="Power Up: Speed";
        v.speed = 20f;
    }

    void OnDisable(){
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="";
        v.speed=10f;
    }
    IEnumerator Timeout(){
        yield return new WaitForSeconds(30);
        enabled=false;
    }
}
