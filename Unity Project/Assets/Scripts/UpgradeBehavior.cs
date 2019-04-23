using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBehavior : MonoBehaviour
{

    public const int UPGRADE_SHOTSPEED = 1;
    public const int UPGRADE_BULLETSPEED = 2;
    public const int UPGRADE_BULLETSIZE = 3;
    public const int UPGRADE_BULLETCOUNT = 4;
    public const int UPGRADE_MOVESPEED = 5;
    public const int UPGRADE_BULLETDAMAGE = 6;

    public PlayerBehavior player;

    public int type = UPGRADE_SHOTSPEED;

    public Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the item
        transform.position += velocity * Time.deltaTime;



    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponents<PlayerBehavior>().Length > 0) {
            other.GetComponent<PlayerBehavior>().upgrade(type,1);
            Destroy(gameObject);
        }
    }
}
