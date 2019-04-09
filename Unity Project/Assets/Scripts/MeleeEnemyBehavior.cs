using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerBehavior player;

    public float speed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
        Destroy(other.gameObject);
        
    }
}
