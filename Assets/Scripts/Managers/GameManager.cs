using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public BlobData player1king;
    public BlobData player2king;

    private bool gameEnded;

    public GameObject gameOverInstructions;
    public Text winnerText;

    void Start() {
        player1king.onDeathIntArg += playerDied;
        player2king.onDeathIntArg += playerDied;

        gameEnded = false;
        winnerText.text = "";
        gameOverInstructions.SetActive(false);
        BlobData.damage_rate = 10f;

        WallManager.wallsMove = true;
    }

    void playerDied(int team) {
        if (!gameEnded) {
            int winner = 1;
            if (team == 1) {
                winner = 2;
            }

            winnerText.text = "Player " + winner + " wins!";
            gameOverInstructions.SetActive(true);

            // FoodManager turn off
            FoodManager.generateFood = false;
            WallManager.wallsMove = false;

            StartCoroutine(EndGame(winner));
        }

        gameEnded = true;
        BlobData.damage_rate = 0;
    }

    IEnumerator EndGame(int winner) {
        while (true) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("Start");
                BlobData.damage_rate = 10f;
                FoodManager.generateFood = true;
                WallManager.wallsMove = true;
                FoodManager.food_generation_time = 5f;
            }
            yield return null;
        }

    }
}
