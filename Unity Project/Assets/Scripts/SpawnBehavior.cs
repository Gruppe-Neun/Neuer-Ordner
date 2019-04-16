using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour
{

    public float height = 15;
    public float width = 20;

    public PlayerBehavior player;

    public EnemyBehavior[] enemyTypes;

    public int[] wave;

    public int waveCount = 3;



    private EnemyBehavior[] current;

    private float cooldown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        for(int e = 0; e < enemyTypes.Length; e++) {
            enemyTypes[e].player = player;
        }

        int count = 0;
        for (int c = 0; c < wave.Length; c++) {
            count += wave[c];
        }
        current = new EnemyBehavior[count];
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown < 0) {
            cooldown = 10f;
            bool ready = true;
            for (int i = 0; i < current.Length; i++) {
                if (current[i] != null) ready = false;
            }
            if (ready) {
                spawnWave();
            }

        }else {
            cooldown -= Time.deltaTime;
        }
    }

    private void spawnWave(){
        if(waveCount <= 0) {
            return;
        }

        waveCount--;
        int c = 0;
        for(int i = 0; i < wave.Length; i++) {
            for(int v = 0; v < wave[i]; v++) {
                Vector3 spawn = new Vector3(Random.value*width-width/2,Random.value*height-height/2,0);
                if (Mathf.Abs(spawn[0]) > Mathf.Abs(spawn[1])) { spawn[1] = height / 2 * (Mathf.Abs(spawn[1]) / spawn[1]); }
                else { spawn[0] = width / 2 *(Mathf.Abs(spawn[0])/spawn[0]) ; }
                current[c] = Instantiate(enemyTypes[i], spawn, new Quaternion());
                current[c].moveSpeed = Random.Range(3.0f,4.2f);
            }


        }


    }
}
