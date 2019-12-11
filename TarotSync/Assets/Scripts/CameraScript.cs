using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>transform.position.x){
            transform.position=new Vector3(player.transform.position.x,transform.position.y,-10);
        }
        transform.position=new Vector3(transform.position.x,player.transform.position.y,-10);
    }
}
