using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehavior : EnemyBehavior
{

    public BulletBehavior bullet;

    public float shootSpeed = 1.0f;

    public int bulletNumber = 1;

    public float bulletSpeed = 5.0f;

    public float bulletSize = 1.0f;

    public float bulletSpread = 0f;

    public float targetDistance = 2f;


    private Animator animator;
        

    private float shootcooldown = 2f;

    // Start is called before the first frame update
    void Start(){
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){



        //move
        float distance = Vector3.Distance(transform.position, player.transform.position)-targetDistance-1;
        float rotation = Vector3.Angle(new Vector3(0, -1, 0), new Vector3(transform.position[0] - player.transform.position[0], transform.position[1] - player.transform.position[1], 0));
        if (transform.position[0] > player.transform.position[0]) { rotation *= -1; }
        if (distance > 0) rotation += 90 / distance;
        else if (distance == 0) rotation += 90;
        else rotation += 90 - (distance) * 10;

        //rotation += Mathf.Asin(moveSpeed / distance);

        transform.position += Quaternion.AngleAxis(rotation, Vector3.back) * Vector3.up * moveSpeed * Time.deltaTime;
        
        if (rotation > 0) { animator.SetBool("facingRight", true); }
        else { animator.SetBool("facingRight", false); }


        //shoot
        if (shootcooldown <= 0){
            shootcooldown = shootSpeed;
            shoot();
        }else{
            shootcooldown -= Time.deltaTime;
        }
    }

    private void shoot(){
        for (int i = 0; i < bulletNumber; i++){
            float rotation = (Random.value * bulletSpread) - (bulletSpread / 2) + Vector3.Angle(new Vector3(0, -1, 0), new Vector3(transform.position[0] - player.transform.position[0], transform.position[1] - player.transform.position[1], 0));
            if (transform.position[0] > player.transform.position[0]) { rotation *= -1; }
            BulletBehavior bulletClone = Instantiate(bullet, transform.position, Quaternion.AngleAxis(rotation, Vector3.back));
            bulletClone.hostile = true;
            bulletClone.speed = bulletSpeed;
            bulletClone.size = bulletSize;
        }
    }
}