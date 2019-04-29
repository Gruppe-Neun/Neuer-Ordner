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
        if(player.transform.position.x > gameObject.transform.position.x - 0.4f &&
           player.transform.position.x < gameObject.transform.position.x + 0.4f &&
           player.transform.position.y > gameObject.transform.position.y - 0.3f &&
           player.transform.position.y < gameObject.transform.position.y + 0.3f) {

            gameController.selectLevel(gameObject.tag);
            animator.SetBool("PlayerOnFolder", true);
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
