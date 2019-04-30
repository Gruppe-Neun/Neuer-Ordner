using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : EnemyBehavior
{

    public int state = 0;

    public float punchCooldown = 8;



    private float damageOnTouchCooldown = 0;

    private int maxLifePoints;

    private SpriteRenderer front;

    private ArmBehavior arm;

    private Vector3 armOrigin = new Vector3(1,-1.6f,1);

    private float nextPunch;


    // Start is called before the first frame update
    void Start()
    {
        //front = GameObject.Find("front").GetComponent<SpriteRenderer>();
        arm = GetComponentInChildren<ArmBehavior>();
        maxLifePoints = lifepoints;
        nextPunch = punchCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageOnTouchCooldown > 0) {
            damageOnTouchCooldown -= Time.deltaTime;
        }

        float armRotation = Random.Range(-45, 45);
        switch (state) {
            case 0:
                if (nextPunch < 0) {
                    nextPunch = punchCooldown;
                    arm.punch(2, 0.2f, armOrigin, armRotation);
                } else {
                    nextPunch -= Time.deltaTime;
                }
                break;

            case 1:
                if (nextPunch < 0) {
                    nextPunch = punchCooldown;
                    arm.punch(2, 0.15f, armOrigin, armRotation);
                } else {
                    nextPunch -= Time.deltaTime;
                }
                break;

            case 2:
                if (nextPunch < 0) {
                    nextPunch = punchCooldown;
                    arm.punch(1.5f, 0.1f, armOrigin, armRotation);
                } else {
                    nextPunch -= Time.deltaTime;
                }
                break;
        }

        
    }

    public override void hit(int damage) {
        lifepoints -= damage;
        if (lifepoints <= 0) {
            gameObject.SetActive(false);
            gameController.addScore(score);
            state = 3;
        } else {
            if (lifepoints < maxLifePoints / 3) {
                state = 2;

            } else {
                if(lifepoints < maxLifePoints / 3 * 2) {
                    state = 1;
                }
            }
        }
        
    }

    public float healthPercentage() {
        return ((float)lifepoints/(float)maxLifePoints);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponents<PlayerBehavior>().Length > 0 && damageOnTouchCooldown <= 0) {
            other.GetComponent<PlayerBehavior>().hit(1);
            damageOnTouchCooldown = 3;
        }
    }
}
