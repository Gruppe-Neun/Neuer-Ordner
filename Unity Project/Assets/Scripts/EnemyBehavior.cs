using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour{

    public PlayerBehavior player;

    public int lifepoints = 1;

    public float moveSpeed = 4.0f;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    //Bullet hit the Enemy
    public void hit(int damage){
        lifepoints -= damage;
        if (lifepoints <= 0){
            Destroy(gameObject);
        }
    }
}
