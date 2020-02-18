using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {
    public GameObject start_food;
    public GameObject start_food2;

    public int num_ready;
    void Start() {
        num_ready = 0;
        start_food.GetComponent<FoodFeed>().onDeath += StartPlay;
        start_food2.GetComponent<FoodFeed>().onDeath += StartPlay;
    }

    void StartPlay() {

        num_ready++;
        if (num_ready == 2) {
            SceneManager.LoadScene("Play");
        }
    }
}
