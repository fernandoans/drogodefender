using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

    public float velocidade;
    public Sprite iFrente, iCostas, ilado, batata;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("right")) {
            transform.Translate(velocidade,0,0);
            transform.localScale = new Vector3(1, 1, 0);
            GetComponent<SpriteRenderer>().sprite = ilado;
        } else if (Input.GetKey("left")) {
            transform.Translate(-velocidade, 0, 0);
            transform.localScale = new Vector3(-1, 1, 0);
            GetComponent<SpriteRenderer>().sprite = iFrente;
        } else if (Input.GetKey("up")) {
            transform.Translate(0, velocidade, 0);
            GetComponent<SpriteRenderer>().sprite = iCostas;
        } else if (Input.GetKey("down")) {
            transform.Translate(0, -velocidade, 0);
            GetComponent<SpriteRenderer>().sprite = batata;
        }
    }
}
