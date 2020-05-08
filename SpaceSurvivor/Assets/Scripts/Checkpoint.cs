using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private GameMaster gm;
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Updates coordinates");
            gm.lastCheckPointPos = transform.position;
            SoundManager.PlaySound("Checkpoint");
            Debug.Log("Sound works");
        }
    }
}

