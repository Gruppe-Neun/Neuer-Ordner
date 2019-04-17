using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour{

    public float moveSpeed;

    public BulletBehavior bullet;
    
    public CursorBehavior cursor;


    public int lives = 3;



    private Rigidbody2D rb;
    private Animator animator;



    private bool shotLastFrame = false;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update(){

        //Shooting
        if(Input.GetMouseButtonDown(0)&&!shotLastFrame){
            BulletBehavior bulletClone = Instantiate(bullet, transform.position, cursor.transform.rotation);
            bulletClone.speed = 15.0f;
            shotLastFrame=true;
        }
        else {
            if (!Input.GetMouseButtonDown(0))
                shotLastFrame = false;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed * Time.deltaTime;

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

        animator.SetBool("top", top);
        animator.SetBool("bot", bot);
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        animator.SetBool("dableft", Input.GetKey(KeyCode.Q));
        animator.SetBool("dabright", Input.GetKey(KeyCode.E));
    }

    //Enemy hit the Player
    public void hit(int damage){
        lives -= damage;
        if (lives <= 0){
            Destroy(gameObject);
        }
    }
}
