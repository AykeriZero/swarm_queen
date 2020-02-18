using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

    // Ya really should decouple these
    public static float food_generation_time = 5f;
    private float time_since_food;

    public static bool generateFood;
    public Transform food_prefab;

    // Start is called before the first frame update
    void Start() {
        time_since_food = Time.time;
        generateFood = true;
    }

    // Update is called once per frame
    void Update() {
        if (food_generation_time + time_since_food < Time.time && generateFood) {
            time_since_food = Time.time;
            food_generation_time = food_generation_time * 1.1f;
            GenerateFood();
        }
    }

    void GenerateFood() {
        Transform c = Instantiate(food_prefab, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
        c.GetComponent<FoodFeed>().SetSize(Random.Range(10f, 30f));
    }
}
