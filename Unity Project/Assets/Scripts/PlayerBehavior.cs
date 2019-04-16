using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;

    public GameObject bullet;
    
    public CursorBehavior cursor;

    public Animator animator;


    private bool shotLastFrame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !shotLastFrame) {
            GameObject bulletClone = Instantiate(bullet, transform.position, cursor.transform.rotation);
            shotLastFrame = true;
            Debug.Log("shot");
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
}
