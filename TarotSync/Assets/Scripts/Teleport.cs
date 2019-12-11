using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public int charges;
    public Camera cam;
    private Vector3 mousePos;
    private Player player;

    void Start()
    {
        charges=5;
        
    }

    void OnEnable(){
        charges=5;
        player=GetComponent<Player>();
        player.powerUpText.GetComponent<Text>().text="Power Up: Teleport\nCharges = 5";
        //v.powerUpText.GetComponent<Text>().text="Power Up: Laser";
    
    }

    void onDisable(){
        player.powerUpText.GetComponent<Text>().text="";
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            mousePos=cam.ScreenToWorldPoint(Input.mousePosition+ new Vector3(0,0,10));
            transform.position = mousePos;
            charges--;
            player.powerUpText.GetComponent<Text>().text="Power Up: Teleport\nCharges = "+charges.ToString();
            StartCoroutine(Invul());
        }
        if(charges<1){
            enabled=false;
        }
    }

    IEnumerator Invul(){
        player.immune=true;
        player.hasDouble=true;
        yield return new WaitForSeconds(2);
        player.immune=false;
    }
}
