using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool up = true;
    private bool down = false;
    private bool left = false;
    private bool right = false;

    public static int score = 0;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Pickup")) {
            switch(other.gameObject.name) {
                case "Collectible":
                case "Collectible(Clone)":
                    score += 5;
                    break;
                case "Collectible1":
                case "Collectible1(Clone)":
                    score += 100;
                    break;
                case "Collectible2":
                case "Collectible2(Clone)":
                    score += 200;
                    break;
                case "Collectible3":
                case "Collectible3(Clone)":
                    score += 500;
                    break;
                case "Collectible4":
                case "Collectible4(Clone)":
                    score += 10;
                    RemoveHazards();
                    break;
            }

            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score.ToString();
            gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().Spawn();
            Destroy(other.gameObject);
        }
    }

    void RemoveHazards() {
        GameObject[] hazardsInScene = GameObject.FindGameObjectsWithTag("Hazard");
        if (hazardsInScene.Length > 0) {
            foreach (GameObject hazard in hazardsInScene) {
                Destroy(hazard);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (up) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        } else if (down) {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        } else if (left) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } else if (right) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0) {
            up = true;
            down = false;
            left = false;
            right = false;
        } else if (verticalInput < 0) {
            up = false;
            down = true;
            left = false;
            right = false;
        } else if (horizontalInput > 0) {
            up = false;
            down = false;
            left = false;
            right = true;
        } else if (horizontalInput < 0) {
            up = false;
            down = false;
            left = true;
            right = false;
        }

    }
}
