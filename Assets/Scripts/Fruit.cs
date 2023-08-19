using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;
    public float explosionRadois = 5f;

    public GameManager gm;

    public int scoreAmount = 3; 

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    public void CreateSlicedFruit(){

        GameObject inst = Instantiate(slicedFruitPrefab,transform.position,transform.rotation);
        Rigidbody[] rbOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(500,1000),transform.position, 5f);
        }

        gm.IncreaseScore(scoreAmount);
        gm.PlayRandomSliceSound();
        Destroy(gameObject);
        Destroy(inst, 5f);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Blade b = other.GetComponent<Blade>();
        if(!b){
            return;
        }
        CreateSlicedFruit();
    }
}
