using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmHitBehavior : MonoBehaviour
{
    private float hitCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCooldown > 0) {
            hitCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponents<PlayerBehavior>().Length > 0 && hitCooldown<=0) {
            other.GetComponent<PlayerBehavior>().hit(1);
            hitCooldown = 3;
        }
    }
}
