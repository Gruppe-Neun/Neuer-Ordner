using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour{

    public float moveSpeed;

    public BulletBehavior bullet;
    
    public CursorBehavior cursor;

    public PauseMenu pauseMenu;

    public int lives = 3;



    public float bulletSizeMultiplier = 1;
    public int bulletCountMultiplier = 1;
    public float bulletSpeedMultiplier = 1;
    public float shotSpeedMultiplier = 1;
    public float moveSpeedMutiplier = 1;
    public int bulletDamageMultiplier = 1;


    private Rigidbody2D rb;
    private Animator animator;
    private PlayerLifeBehavior lifeCount;


    private float shotCooldown = 0f;
    private float invincible = -1;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lifeCount = GetComponentInChildren<PlayerLifeBehavior>();
    }

    // Update is called once per frame

    void Update(){

        //Shooting
        if(Input.GetMouseButton(0)&&shotCooldown<=0&&!PauseMenu.gamePaused){
            float rotation = Vector3.Angle(new Vector3(0, -1, 0), new Vector3(transform.position[0] - cursor.transform.position[0], transform.position[1] - cursor.transform.position[1], 0));
            if (transform.position[0] > cursor.transform.position[0]) { rotation *= -1; }
            rotation -= ((bulletCountMultiplier - 1) * 2.5f);
            for (int i = 0; i < bulletCountMultiplier;i++) {
                BulletBehavior bulletClone = Instantiate(bullet, transform.position, Quaternion.AngleAxis(rotation+(5*i),Vector3.back));
                bulletClone.speed = 10.0f * bulletSpeedMultiplier;
                bulletClone.size = bulletSizeMultiplier;
                bulletClone.damage = bulletDamageMultiplier;
            }

            
            shotCooldown=1;
        }else {
            shotCooldown -= Time.deltaTime * shotSpeedMultiplier;
        }

        if (invincible > 0) {
            invincible -= Time.deltaTime;
        }
        


        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed * Time.deltaTime * moveSpeedMutiplier;

        // Animations
        bool top = false;
        bool bot = false;
        bool left = false;
        bool right = false;

        if(Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))) {
            top = true;
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            left = true;
        }

        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))) {
            bot = true;
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
            right = true;
        }

        if (!PauseMenu.gamePaused) {
            animator.SetBool("top", top);
            animator.SetBool("bot", bot);
            animator.SetBool("left", left);
            animator.SetBool("right", right);
            animator.SetBool("dableft", Input.GetKey(KeyCode.Q));
            animator.SetBool("dabright", Input.GetKey(KeyCode.E));
        }
    }

    //Enemy hit the Player
    public void hit(int damage){
        if (invincible > 0) {
            lives -= damage;
            lifeCount.hit(lives);
            if (lives < 0) {
                Destroy(gameObject);
            }
            invincible = 1;
        }
    }

    public void upgrade(int Type, int Amount) {
        switch (Type) {
            case UpgradeBehavior.UPGRADE_BULLETCOUNT :
                bulletCountMultiplier += Amount;
                break;

            case UpgradeBehavior.UPGRADE_BULLETSIZE :
                bulletSizeMultiplier += Amount * 0.5f;
                break;

            case UpgradeBehavior.UPGRADE_BULLETSPEED :
                bulletSpeedMultiplier += Amount * 0.25f;
                break;

            case UpgradeBehavior.UPGRADE_MOVESPEED:
                moveSpeedMutiplier += Amount * 0.25f;
                break;

            case UpgradeBehavior.UPGRADE_SHOTSPEED:
                shotSpeedMultiplier += Amount * 0.5f;
                break;

            case UpgradeBehavior.UPGRADE_BULLETDAMAGE:
                bulletDamageMultiplier += Amount;
                break;
        }
    }
}
