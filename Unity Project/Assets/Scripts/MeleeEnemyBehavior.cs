using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : EnemyBehavior{
    // Start is called before the first frame update
    

    

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //moving towards player
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,moveSpeed*Time.deltaTime);
    }

    //Enemy touches the player
    void OnTriggerEnter2D(Collider2D other){
        if (other.GetComponents<PlayerBehavior>().Length > 0){
            other.GetComponent<PlayerBehavior>().hit(1);
            Destroy(gameObject);
        }
    }

    public override void hit(int damage) {
        lifepoints -= damage;
        if (lifepoints <= 0) {
            Destroy(gameObject);
            gameController.addScore(score);
        }
    }
}
