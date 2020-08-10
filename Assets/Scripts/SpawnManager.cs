using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 11f;
    private float spawnRangeY = 5f;
    private Vector3 spawnPos;

    public GameObject pickup;
    public GameObject hazard;
    public GameObject border;
    Collider2D borderCol;

    public GameObject[] collectibles;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeSpawnPosition();
        CreatePickup();
    }

    public void Spawn() {
        RandomizeSpawnPosition();
        CreatePickup();

        RandomizeSpawnPosition();
        int num = Random.Range(0, 11);
        if (num <= 6) {
            CreateHazard();
        } else {
            if (CheckPickupCount()) {
                CreateCollectible();
            }
        }
    }

    private void RandomizeSpawnPosition() {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0);
        float distance = Vector3.Distance(playerPos, spawnPos);

        if (SceneManager.GetActiveScene().name == "Hard") {
            borderCol = border.GetComponent<Collider2D>();
            if (borderCol.bounds.Contains(spawnPos) || distance <= 2f) {
                Debug.Log("true");
                RandomizeSpawnPosition();
            }
        } else {
            if (distance <= 2f) {
                RandomizeSpawnPosition();
            }
        }
    }

    private void CreatePickup() {
        Instantiate(pickup, spawnPos, pickup.transform.rotation);
    }

    private void CreateHazard() {
        Instantiate(hazard, spawnPos, hazard.transform.rotation);
    }

    private void CreateCollectible() {
        int collectiblesIndex = Random.Range(0, collectibles.Length);
        Instantiate(collectibles[collectiblesIndex], spawnPos, collectibles[collectiblesIndex].transform.rotation);
    }

    private bool CheckPickupCount() {
        GameObject[] pickupsInScene = GameObject.FindGameObjectsWithTag("Pickup");
        if (pickupsInScene.Length > 2) {
            // do not spawn new collectibles if there are more than 2 in a scene
            return false;
        }
        return true;
    }
}
