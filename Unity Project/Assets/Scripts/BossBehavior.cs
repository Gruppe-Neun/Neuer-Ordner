using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : EnemyBehavior
{

    public int state = 0;

    public float punchCooldown = 3;



    private int maxLifePoints;

    private SpriteRenderer front;

    private ArmBehavior arm;

    // Start is called before the first frame update
    void Start()
    {
        front = GameObject.Find("front").GetComponent<SpriteRenderer>();
        arm = GetComponentInChildren<ArmBehavior>();
        maxLifePoints = lifepoints;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
