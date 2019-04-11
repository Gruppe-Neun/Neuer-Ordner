using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour{

    public float speed = 30.0f;

    public float size = 1.0f;

    public float maxDistance = 100f;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        //Moving the projectile
        transform.position += transform.up*speed*Time.deltaTime;    

        //Deleting the projectile if too far away
        if(transform.position[0]>10||transform.position[0]<-10||transform.position[1]>10||transform.position[1]<-10){
            Destroy(gameObject);
        }

        //Deleting if traveled maxDistance
        maxDistance -= speed * Time.deltaTime;
        if (maxDistance <= 0){
            Destroy(gameObject);
        }
    }

    //bullet hit other object
    void OnTriggerEnter2D(Collider2D other){
        if (other.GetComponents<EnemyBehavior>().Length>0){
            other.GetComponent<EnemyBehavior>().hit(1);
            Destroy(gameObject);
        }
    }
}
