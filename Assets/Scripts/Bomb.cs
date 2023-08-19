using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Blade b = other.GetComponent<Blade>();
        if(!b)
            return;
        GameManager gm = FindObjectOfType<GameManager>();
        gm.PlayBombSound();
        gm.onBombHit();
    }
}
