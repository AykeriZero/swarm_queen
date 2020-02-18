using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobDealDamage : MonoBehaviour {
    public GameObject eating;
    private BlobData my_bd;

    void Awake() {
        my_bd = GetComponent<BlobData>();
    }

    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.tag == "Blob") {
            BlobData bd = other.gameObject.GetComponent<BlobData>();

            if (!eating && bd.team != my_bd.team) {
                eating = other.gameObject;
            }

            if (eating == other.gameObject) {
                bd.TakeDamage();
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject == eating) {
            eating = null;
        }
    }
}
