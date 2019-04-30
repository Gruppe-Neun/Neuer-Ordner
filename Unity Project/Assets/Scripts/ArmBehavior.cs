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
            warningColor.a = ((float)timer / (float)warning);
            warningSprite.color = warningColor;
        } else {
            if(timer < hit+warning) {
                arm.transform.localPosition = new Vector3((timer-warning)/hit*10-10,0,-1);
            } else {
                if(timer < hit + warning + 2) {
                    warningColor.a = 0;
                    warningSprite.color = warningColor;
                    arm.transform.localPosition = new Vector3(0 - (timer - warning - hit) / 2 * 10, 0, -1);
                } else {
                    arm.transform.localPosition = new Vector3(-10, 0, -1);
                }
            }
        }
    }

    public void punch(float warningTime,float hitTime,Vector3 from,float rotation) {

        timer = 0;
        warning = warningTime;
        hit = hitTime;

        transform.rotation = Quaternion.AngleAxis(rotation ,Vector3.back);
        transform.localPosition = from;
        transform.position += transform.right * 5;
        arm.transform.localPosition = new Vector3(-10,0,-1);

        warningColor = new Color(255, 255, 255, 0);
        warningSprite.color = warningColor;
    }
}
