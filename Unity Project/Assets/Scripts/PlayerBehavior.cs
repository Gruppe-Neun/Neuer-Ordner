using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour{

    public float moveSpeed = 10f;

    public GameObject bullet;

    public CursorBehavior cursor;

    public int lives = 3;


    private bool shotLastFrame = false;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //Moving the Player
        transform.position += Vector3.up * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;


        //Shooting
        if(Input.GetMouseButtonDown(0)&&!shotLastFrame){
            GameObject bulletClone = Instantiate(bullet, transform.position, cursor.transform.rotation);
            shotLastFrame=true;
            Debug.Log("shot");
        }else{if(!Input.GetMouseButtonDown(0))
            shotLastFrame=false;
        }
        
    }

    //Enemy hit the Player
    public void hit(int damage){
        lives -= damage;
        if (lives <= 0){
            Destroy(gameObject);
        }
    }
}
