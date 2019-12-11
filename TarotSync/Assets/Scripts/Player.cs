using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 movement;
    private Rigidbody rb;
    public float speed;
    public bool hasDouble;
    private bool onGround;
    public float jumpDist;
    public bool immune;
    public Text powerUpText;
    void Start()
    {
        //Sets lives for new users
        if(!PlayerPrefs.HasKey("lives")){
            PlayerPrefs.SetInt("lives",5);
        }
        speed=10f;
        rb=GetComponent<Rigidbody>();
        hasDouble=true;
        onGround=true;
        immune=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(hasDouble){
                if(!onGround){
                    hasDouble=false;
                }
                rb.AddForce(new Vector3(0,jumpDist,0));
            }
        }
    }
    void FixedUpdate(){
        movement = new Vector3(0,0,0);
        if(Input.GetKey(KeyCode.D)){
            movement+= new Vector3(speed,0,0);
        }
        if(Input.GetKey(KeyCode.A)){
            movement+= new Vector3(speed*-1,0,0);
        }

        if(Input.GetKey(KeyCode.LeftControl)){
            movement+=movement;
        }
        rb.AddForce(movement);
        //Reload Scene on death
        if(transform.position.y<-10){
            Death();
        }
    }

    void OnCollisionEnter(Collision hit){
        var other = hit.gameObject;
        if(other.CompareTag("Ground")){
            hasDouble=true;
            onGround=true;
        }
        else if(other.CompareTag("Enemy")){
            Death();
        }
    }
    void OnCollisionExit(Collision hit){
        var other = hit.gameObject;
        if(other.CompareTag("Ground")){
            onGround=false;
        }
    }

    void Death(){
        PlayerPrefs.SetInt("lives",PlayerPrefs.GetInt("lives")-1);
            if(PlayerPrefs.GetInt("lives")>0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else{
                //load menu here and reset lives
                PlayerPrefs.SetInt("lives",5);
            }
    }
}
