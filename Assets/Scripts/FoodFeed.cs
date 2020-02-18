using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFeed : MonoBehaviour {
    public float size = 20f;

    public float death_size = 5f;
    public static float feeding_rate = 10f;

    public delegate void VoidNoArg();
    public VoidNoArg onDeath;

    void Start() {
        SetSize(size);
    }

    public void SetSize(float new_size) {

        if (new_size < death_size) {
            if (onDeath != null) {
                onDeath();
            }

            Destroy(gameObject);
        }

        size = new_size;
        transform.localScale = new Vector3(size / 20f, size / 20f, 0);
    }

    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.tag == "Blob") {
            BlobData bd = other.gameObject.GetComponent<BlobData>();
            bd.AddSize();
            SetSize(size - feeding_rate * Time.deltaTime);
        }
    }

}
