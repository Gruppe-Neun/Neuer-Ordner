using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBehavior : MonoBehaviour
{

    private Animator animator;
    private float updated = -1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updated > 0) {
            
            updated -= Time.deltaTime;
        }else {
            updated -= 1;
            animator.SetInteger("Lifes", -1);
        }

    }

    public void hit(int lifes) {
        animator.SetInteger("Lifes", lifes);
        updated = 0.5f;
    }
}
