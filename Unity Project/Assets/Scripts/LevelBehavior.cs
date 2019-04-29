using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBehavior : MonoBehaviour
{
    
    
    public string levelName = "neuer Ordner";

    public GameControllerBehavior gameController;
    //number of keys to open
    public int locked = 0;

    public LevelBehavior successor_1;
    public LevelBehavior successor_2;
    public LevelBehavior successor_3;

    public LevelBehavior predecessor;

    protected int status = 0;
    protected PlayerBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void startLevel();

    public abstract void endLevel();

    public abstract float progress();

    public int getStatus() {
        return status;
    }

}
