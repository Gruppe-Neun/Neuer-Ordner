using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLevelBehavior : LevelBehavior {


    public float time = 30;

    public float SpawnInterval = 5;

    public EnemyBehavior[] enemies;

    public int[] EnemyAmout;

    public UpgradeBehavior Reward;

    
    private float timeLeft;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }

    public override void startLevel() {
        if (status == 0) {
            gameObject.SetActive(true);
            timeLeft = time;
            nextSpawn = time - SpawnInterval/2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            gameObject.SetActive(false);
            status = 1;
        }
        if (timeLeft <= nextSpawn) {
            if (nextSpawn > SpawnInterval) {
                nextSpawn -= SpawnInterval;
            } else {
                nextSpawn = -1;
            }
            spawnWave();
            
        }

    }

    private void spawnWave() {
        for(int i = 0; i < enemies.Length; i++) {

            for (int c = 0; c < EnemyAmout[i]; c++) {

                float xSpawn = 0, ySpawn = 0;

                int side = Random.Range(0, 4);
                switch (side) {
                    case 0:
                        xSpawn = -8;
                        ySpawn = 8 * Random.value - 4;
                        break;
                    case 1:
                        xSpawn = 8;
                        ySpawn = 8 * Random.value - 4;
                        break;
                    case 2:
                        xSpawn = 16 * Random.value -8;
                        ySpawn = -4;
                        break;
                    case 3:
                        xSpawn = 16 * Random.value -8;
                        ySpawn = 4;
                        break;
                }

                //low chance to spawn Item instead of enemy
                if (Random.value > 0.98) {

                }
                else {
                    EnemyBehavior newEnemy = GameObject.Instantiate(enemies[i], new Vector3(xSpawn, ySpawn, 0), new Quaternion());
                    newEnemy.player = player;
                }
                
            }
        }
    }

    public override float progress() {
        return (time-timeLeft) / time;
    }

    public override void endLevel() {
        gameObject.SetActive(false);
    }
}
