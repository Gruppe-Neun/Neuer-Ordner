using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderBehaviour : MonoBehaviour
{
    public static int gameLayer = 0;

    public Text folderName;

    public SpriteRenderer lockSprite;

    public Sprite lock_1;

    public Sprite lock_2;

    public Sprite lock_3;

    private GameControllerBehavior gameController;

    private GameObject player;

    private Animator animator;

    private float cooldown = 0;

    private int lockState = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        folderName = this.gameObject.GetComponentInChildren<Text>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerBehavior>(); ;
    }

    // Update is called once per frame
    void Update()
    { 
        if(cooldown>0) {
            cooldown -= Time.deltaTime;
        }
        if(lockState==0 &&
           player.transform.position.x > gameObject.transform.position.x - 0.4f &&
           player.transform.position.x < gameObject.transform.position.x + 0.4f &&
           player.transform.position.y > gameObject.transform.position.y - 0.3f &&
           player.transform.position.y < gameObject.transform.position.y + 0.3f) {
            
            animator.SetBool("PlayerOnFolder", true);

            if (Input.GetKey(KeyCode.E) && cooldown <= 0) {
                gameController.selectLevel(gameObject.tag);
            }
        }else {
            animator.SetBool("PlayerOnFolder", false);
        }
    }

    public void setName(string folderName, int lockMode) {
        if (folderName == null) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            GetComponentInChildren<Text>().text = folderName;
        }
        lockState = lockMode;
        switch (lockMode) {
            case 3:
                lockSprite.sprite = lock_3;
                lockSprite.gameObject.SetActive(true);
                lockSprite.enabled = true;
                break;
            case 2:
                lockSprite.sprite = lock_2;
                lockSprite.gameObject.SetActive(true);
                lockSprite.enabled = true;
                break;
            case 1:
                lockSprite.sprite = lock_1;
                lockSprite.gameObject.SetActive(true);
                lockSprite.enabled = true;
                break;
            case 0:
                lockSprite.enabled = false;
                lockSprite.gameObject.SetActive(false);
                break;
        }
    }
}
