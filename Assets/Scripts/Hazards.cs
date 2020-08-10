using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("GameOverUI").GetComponent<GameOver>().EndGame();
        }
    }
}
