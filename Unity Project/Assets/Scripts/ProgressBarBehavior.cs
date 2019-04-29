using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarBehavior : MonoBehaviour
{

    private float xPos;
    private float xScale;
    
    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setProgress(float progress) {
        transform.localScale = new Vector3(xScale * progress, transform.localScale.y, 1);
        //transform.position.Set(xPos * progress / 200, transform.position.y, transform.position.z);
    }
}
