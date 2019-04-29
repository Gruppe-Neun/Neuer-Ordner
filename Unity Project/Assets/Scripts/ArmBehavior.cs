using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehavior : MonoBehaviour
{

    private SpriteRenderer warningSprite;

    public GameObject arm;


    private float timer = -1;
    private float warning;
    private float hit;
    private Color warningColor;
    // Start is called before the first frame update
    void Start()
    {
        warningSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == -1) {
            return;
        }
        timer += Time.deltaTime;
        if (timer < warning) {
            warningColor.a = (timer / warning) * 255;
            warningSprite.color = warningColor;
        } else {
            if(timer < hit+warning) {
                arm.transform.position = new Vector3((timer-warning)/hit*9-9,0,1);
            } else {
                if(timer < hit + warning + 2) {

                } else {
                    arm.transform.position = new Vector3(-9, 0, 1);
                    warningColor.a = 0;
                    warningSprite.color = warningColor;
                }
            }
        }
    }

    public void punch(float warningTime,float hitTime,Vector3 from,Vector3 to) {
        timer = 0;
        warning = warningTime;
        hit = hitTime;
        transform.position = Vector3.MoveTowards(from, to, Vector3.Distance(from, to));
        transform.rotation = Quaternion.FromToRotation(from, to);
        arm.transform.position = new Vector3(-9,0,-1);
        warningColor = new Color(255, 255, 255, 0);
        warningSprite.color = warningColor;
    }
}
