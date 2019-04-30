using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelBehavior : LevelBehavior {


    public Sprite[] sprite;
    public float time = 5;

    private float timeLeft;
    private int frame = 1;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        
        timeLeft = time;
        //spriteRenderer = GameObject.FindGameObjectWithTag("LevelBackground").GetComponent<SpriteRenderer>();
        
    }

    public override void startLevel() {
        
        gameObject.SetActive(true);
        spriteRenderer.gameObject.SetActive(true);
        spriteRenderer.sprite = sprite[frame-1];
    }

    public override void endLevel() {
        gameObject.SetActive(false);
        spriteRenderer.gameObject.SetActive(false);
    }

    public override float progress() {
        return 0;
    }

    // Update is called once per frame
    void Update() {
        if (timeLeft < 0) {
            if (frame+1 >= sprite.Length) {
                spriteRenderer.sprite = sprite[frame];
                status = 1;
            } else {
                frame++;
                timeLeft = time;
                spriteRenderer.sprite = sprite[frame - 1];
            }
        } else {
            timeLeft -= Time.deltaTime;
        }
    }
}
