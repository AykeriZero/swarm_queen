using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
    static public bool wallsMove;

    public float SecondsTilClosing = 10f;
    public float wall_speed = 1f;

    public GameObject eastWall;
    public GameObject westWall;
    public GameObject northWall;
    public GameObject southWall;

    // Update is called once per frame
    void Update() {
        if (wallsMove) {
            SecondsTilClosing -= Time.deltaTime;

            if (SecondsTilClosing < 0) {
                eastWall.transform.position -= new Vector3(wall_speed,0,0);
                westWall.transform.position += new Vector3(wall_speed,0,0);
                northWall.transform.position -= new Vector3(0, wall_speed, 0);
                southWall.transform.position += new Vector3(0, wall_speed, 0);
            }
        }

    }
}
