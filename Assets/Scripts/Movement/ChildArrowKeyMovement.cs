using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildArrowKeyMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private BlobData my_bd;

    public float speed = 4f;
    public float return_force = 10f;

    public GameObject king;
    private string key;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        my_bd = GetComponent<BlobData>();
        key = king.GetComponent<KingArrowKeyMovement>().key;

        // TEMP
        king.GetComponent<BlobData>().onDeathNoArg += SelfDestruct;
    }

    void SelfDestruct() {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        // if input, move in direction of input, else move toward the king
        Vector3 offset = king.transform.position - transform.position;
        float magsqr = offset.sqrMagnitude;

        // Add Force to move toward the parent
        rb.AddForce(return_force * offset.normalized);

    }
}
