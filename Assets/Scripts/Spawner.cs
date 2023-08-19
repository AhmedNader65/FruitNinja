using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitSpawnPrefabs;
    public GameObject bombPrefab;
    public Transform[] spawnPlaces;

    public int chanceToSpawnBomb = 10;
    public float minWait = 0.3f;
    public float maxWait = 1.0f;

    public float minForce = 10;
    public float maxForce = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform t = spawnPlaces[Random.Range(0,spawnPlaces.Length)];
            GameObject go = null;
            float rnd = Random.Range(0,100);
            if(rnd < chanceToSpawnBomb){
                go = bombPrefab;
            }else{
                go = fruitSpawnPrefabs[Random.Range(0,fruitSpawnPrefabs.Length)];
            }

            GameObject fruit = Instantiate(go,t.transform.position,t.transform.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.up * Random.Range(minForce, maxForce),ForceMode2D.Impulse);

            Destroy(fruit, 5f);
        }
    }
}
