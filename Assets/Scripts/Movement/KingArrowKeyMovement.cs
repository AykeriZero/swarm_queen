using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingArrowKeyMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private BlobData my_bd;

    public string key;
    public float speed = 4f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        my_bd = GetComponent<BlobData>();
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxis(key + "Horizontal");
        float v = Input.GetAxis(key + "Vertical");

        rb.velocity = new Vector2(h * (1/my_bd.size) * speed * 10f, v * (1/my_bd.size) * speed * 10f);
    }
}
