using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelBehavior : LevelBehavior
{


    public float SpawnInterval = 5;

    public EnemyBehavior[] enemies;

    public int[] EnemyAmout;

    public UpgradeBehavior Reward;

    public float itemPercentage = 2f;

    public BossBehavior boss;

    private float nextSpawn;

    // Start is called before the first frame update
    void Start() {
        gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerBehavior>();

    }

    public override void startLevel() {
        if (status == 0) {
            gameObject.SetActive(true);

            nextSpawn = SpawnInterval;
            boss = GameObject.Instantiate(boss);
            boss.gameController = gameController;
            player.transform.position = new Vector3(3, 0, player.transform.position.z);
        }
        
       
    }

    // Update is called once per frame
    void Update() {
        nextSpawn -= Time.deltaTime;
        if (boss.lifepoints <= 0) {
            gameObject.SetActive(false);
            status = 1;
            GameObject.Instantiate(Reward, new Vector3(0, 0, 0), new Quaternion());
        }
        if (nextSpawn <= 0) {
            spawnWave();
            nextSpawn = SpawnInterval;
            
        }
        
        
    }

    private void spawnWave() {
        for (int i = 0; i < enemies.Length; i++) {

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
                        xSpawn = 16 * Random.value - 8;
                        ySpawn = -4;
                        break;
                    case 3:
                        xSpawn = 16 * Random.value - 8;
                        ySpawn = 4;
                        break;
                }

                //low chance to spawn Item instead of enemy
                if (Random.value > 1 - itemPercentage) {
                    GameObject.Instantiate(Reward, new Vector3(0, 0, 0), new Quaternion());
                } else {
                    EnemyBehavior newEnemy = GameObject.Instantiate(enemies[i], new Vector3(xSpawn, ySpawn, 0), new Quaternion());
                    newEnemy.player = player;
                }

            }
        }
    }

    public override float progress() {
        return boss.healthPercentage();
    }

    public override void endLevel() {
        gameObject.SetActive(false);
    }
}
