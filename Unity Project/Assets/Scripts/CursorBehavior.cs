using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{

    public float sensitivity = 15f;

    public Rigidbody2D rb;

    public PlayerBehavior player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime, sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime);

        //transform.position += Vector3.up * sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;
        //transform.position += Vector3.right * sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;

        float rotation = Vector3.Angle(new Vector3(0,1,0),new Vector3(transform.position[0]-player.transform.position[0],transform.position[1]-player.transform.position[1], 0));
        if(transform.position[0]<player.transform.position[0]){rotation*=-1;}
        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.back);
    }
}
