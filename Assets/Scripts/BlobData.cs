using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobData : MonoBehaviour
{
    public float size = 5f;
    public int team = 1;

    public static float damage_rate = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool red;

    public delegate void VoidIntArg(int num);
    public delegate void VoidNoArg();
    public VoidIntArg onDeathIntArg;
    public VoidNoArg onDeathNoArg;

    public void TakeDamage() {
        if (damage_rate != 0) {
            if (!red) {
                StartCoroutine(FlashRed());
            }
            SetSize(size - damage_rate * Time.deltaTime);
        }
    }

    public void AddSize() {
        SetSize(size + damage_rate * Time.deltaTime);
    }

    public void SetSize(float new_size) {
        if (new_size <= 5f) {
            gameObject.SetActive(false);

            if (onDeathIntArg != null) {
                onDeathIntArg(team);
            }
            if (onDeathNoArg != null) {
                onDeathNoArg();
            }

            return;
        }
        size = new_size;

        rb.mass = size / 8f;

        transform.localScale = new Vector3(size / 20f, size / 20f, 1);
    }

    public void SetTeam(int new_team) {
        team = new_team;
        SetColor();
    }

    void SetColor() {
        switch (team) {
            case 1:
                sr.color = new Color(0.25f, 0.4f, 0.84f, 1f);
                break;
            case 2:
                sr.color = new Color(0.0f, 0.8f, 0.24f, 1f);
                break;
            default:
                sr.color = new Color(64, 111, 127, 255);
                break;
        }
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() {
        SetSize(size);
        SetTeam(team);

        red = false;
    }

    IEnumerator FlashRed() {
        red = true;

        Color prev_color = sr.color;
        sr.color = sr.color + new Color(.8f, -.2f, -.2f, 1f);
        yield return new WaitForSeconds(0.5f);

        SetColor();
        red = false;
    }
}
