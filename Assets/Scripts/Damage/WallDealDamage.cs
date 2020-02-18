using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDealDamage : MonoBehaviour {
    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.tag == "Blob") {
            BlobData bd = other.gameObject.GetComponent<BlobData>();
            bd.TakeDamage();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Blob") {
            BlobData bd = other.gameObject.GetComponent<BlobData>();
            bd.TakeDamage();
        }
    }

}
