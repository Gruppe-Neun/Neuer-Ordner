using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderBehaviour : MonoBehaviour
{
    public static int gameLayer = 0;

    public Text folderName;


    private GameControllerBehavior gameController;

    private GameObject player;

    private Animator animator;

    private float cooldown = 0;

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
        if(player.transform.position.x > gameObject.transform.position.x - 0.4f &&
           player.transform.position.x < gameObject.transform.position.x + 0.4f &&
           player.transform.position.y > gameObject.transform.position.y - 0.3f &&
           player.transform.position.y < gameObject.transform.position.y + 0.3f) {
            
            animator.SetBool("PlayerOnFolder", true);

            if (Input.GetKey(KeyCode.E) && cooldown <= 0) {
                gameController.selectLevel(gameObject.tag);
            }
        }
        else {
            animator.SetBool("PlayerOnFolder", false);
        }
    }
    
    public void setName(string folderName) {
        if (folderName == null) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            GetComponentInChildren<Text>().text = folderName;
        }
    }
}
