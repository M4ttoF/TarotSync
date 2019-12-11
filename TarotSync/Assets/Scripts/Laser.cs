using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    public Camera cam;
    private Vector3 mousePos;
    private RaycastHit[] hits;
    private LineRenderer lr;
    public AudioSource myAudio;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector3(0,0,0);
        lr = GetComponent<LineRenderer>();
    }

    void OnEnable(){
        StartCoroutine(Timeout());
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="Power Up: Laser";
    }

    void OnDisable(){
        lr.enabled=false;
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            myAudio.PlayOneShot(clip, 1f);
            mousePos=cam.ScreenToWorldPoint(Input.mousePosition+ new Vector3(0,0,10));
            Debug.Log(mousePos);
            hits = Physics.RaycastAll(transform.position, mousePos-transform.position, 200f);
            foreach (var i in hits){
                Debug.Log(i.transform.gameObject.name);
                if(i.transform.gameObject.CompareTag("Enemy")){
                    Destroy(i.transform.gameObject);
                }
            }
            StartCoroutine(DrawLaser());
        }
    }

    IEnumerator DrawLaser(){
        lr.enabled = true;
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1, (mousePos-transform.position)*10);
        yield return new WaitForSeconds(.2f);
        lr.enabled=false;
    }

    IEnumerator Timeout(){
        yield return new WaitForSeconds(30);
        enabled=false;
    }
}
