using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit){
        var other = hit.gameObject;
        if(other.CompareTag("Enemy")){
            Destroy(other);
        }
    }
}
