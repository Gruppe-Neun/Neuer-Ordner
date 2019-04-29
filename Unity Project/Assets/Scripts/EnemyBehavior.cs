using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour{

    public PlayerBehavior player;

    public GameControllerBehavior gameController;

    public int score = 20;

    public int lifepoints = 1;

    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    //Bullet hit the Enemy
    public abstract void hit(int damage);
}
