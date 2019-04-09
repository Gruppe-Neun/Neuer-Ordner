using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public float speed = 25.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up*speed*Time.deltaTime;    


        if(transform.position[0]>10||transform.position[0]<-10||transform.position[1]>10||transform.position[1]<-10){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("test");
        
    }
}
