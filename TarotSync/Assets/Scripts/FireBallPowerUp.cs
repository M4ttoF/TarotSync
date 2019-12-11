using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireball;
    public Camera cam;
    private Vector3 mousePos;
    public AudioSource myAudio;
    public AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            myAudio.PlayOneShot(clip, .5f);
            mousePos=cam.ScreenToWorldPoint(Input.mousePosition+ new Vector3(0,0,10));
            var ball = Instantiate(fireball, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce((mousePos-transform.position)*400);
            StartCoroutine(KillBall(ball));
        }
    }

    void OnEnable(){
        StartCoroutine(Timeout());
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="Power Up: FireBall";
    }

    void OnDisable(){
        var v = GetComponent<Player>();
        v.powerUpText.GetComponent<Text>().text="";
    }

    IEnumerator Timeout(){
        yield return new WaitForSeconds(40);
        enabled=false;
    }
    IEnumerator KillBall(GameObject g){
        yield return new WaitForSeconds(2);
        Destroy(g);
    }
}
