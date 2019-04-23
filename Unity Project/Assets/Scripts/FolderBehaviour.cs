using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderBehaviour : MonoBehaviour
{
    public static int gameLayer = 0;

    public Text folderName;

    public GameObject player;

    public Animator animator;

    public GameObject folderTopLeft;

    public GameObject folderTopRight;

    public GameObject folderBottomLeft;

    public GameObject folderBottomRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        folderName = this.gameObject.GetComponentInChildren<Text>();

        folderTopLeft = GameObject.FindGameObjectWithTag("FolderTopLeft");
        folderTopRight = GameObject.FindGameObjectWithTag("FolderTopRight");
        folderBottomLeft = GameObject.FindGameObjectWithTag("FolderBottomLeft");
        folderBottomRight = GameObject.FindGameObjectWithTag("FolderBottomRight");

        gameObject.SetActive(false);

        folderBottomRight.SetActive(true);
        folderBottomRight.GetComponentInChildren<Text>().text = "Start Game";
    }

    // Update is called once per frame
    void Update()
    { 
        if(player.transform.position.x > gameObject.transform.position.x - 0.4f &&
           player.transform.position.x < gameObject.transform.position.x + 0.4f &&
           player.transform.position.y > gameObject.transform.position.y - 0.3f &&
           player.transform.position.y < gameObject.transform.position.y + 0.3f) {

            animator.SetBool("PlayerOnFolder", true);
        }
        else {
            animator.SetBool("PlayerOnFolder", false);
        }
    }

    private void LoadStage1() {

    }
}
