using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pipeList;
    public GameObject spawnSpace;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float curTime;
    public float delayPerSpawn;

    private void Update()
    {
        if (GameManager.instance.gameOver == true || GameManager.instance.isStartGame == false) return;
        if(curTime> delayPerSpawn)
        {
            curTime = 0;
            Spawn();
        }
        curTime += Time.deltaTime;
    }

    protected void Spawn()
    {
        int randomPipe = Random.Range(0, pipeList.Count);
        GameObject pipes = Instantiate(pipeList[randomPipe]);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
