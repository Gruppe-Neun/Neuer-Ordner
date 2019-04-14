using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public float moveSpeed = 10f;

    public Vector3 verticalDirection;

    public Vector3 horizontalDirection;

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
        horizontalDirection = Vector3.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += horizontalDirection;

        verticalDirection = Vector3.up * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += verticalDirection;

        if(Input.GetMouseButtonDown(0)&&!shotLastFrame){
            GameObject bulletClone = Instantiate(bullet, transform.position, cursor.transform.rotation);
            shotLastFrame=true;
            Debug.Log("shot");
        }else{if(!Input.GetMouseButtonDown(0))
            shotLastFrame=false;
        }

        // Animations

        bool top = false;
        bool bot = false;
        bool left = false;
        bool right = false;

        float x = horizontalDirection.normalized.x;
        float y = verticalDirection.normalized.y;

        if(y == -1) {
            bot = true;
        }
        
        if(y == 1) {
            top = true;
        }

        if(y == 0 && x == -1) {
            left = true;
        }

        if(y == 0 && x == 1) {
            right = true;
        }

        animator.SetBool("top", top);
        animator.SetBool("bot", bot);
        animator.SetBool("left", left);
        animator.SetBool("right", right);
        animator.SetBool("dableft", Input.GetKey(KeyCode.Q));
        animator.SetBool("dabright", Input.GetKey(KeyCode.E));

        Debug.Log("Q: "+ Input.GetKey(KeyCode.Q));
        Debug.Log("E: " + Input.GetKey(KeyCode.E));
    }
}
