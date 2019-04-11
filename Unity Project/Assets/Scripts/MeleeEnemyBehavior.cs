﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : EnemyBehavior{
    // Start is called before the first frame update
    

    public float speed = 5.0f;

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //moving towards player
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
    }

    //Enemy touches the player
    void OnTriggerEnter2D(Collider2D other){
        if (other.GetComponents<PlayerBehavior>().Length > 0){
            other.GetComponent<PlayerBehavior>().hit(1);
            Destroy(gameObject);
        }
    }
}
