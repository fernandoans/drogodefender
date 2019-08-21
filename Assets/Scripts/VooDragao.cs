﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VooDragao : MonoBehaviour {

    public float velocidade;
    public float tapForce = 1;
    public float tiltSmooth = 5;
    public Vector3 startPos;
    private new SpriteRenderer renderer;
    public Sprite esquerda, direita, cima;
    private Rigidbody2D rigidbody;
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
//        rigidbody.simulated = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<SpriteRenderer>().sprite = cima;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
        if (Input.GetKey("right")) {
            transform.Translate(velocidade,0,0);
            GetComponent<SpriteRenderer>().sprite = direita;
        } else if (Input.GetKey("left")) {
            transform.Translate(-velocidade, 0, 0);
            GetComponent<SpriteRenderer>().sprite = esquerda;
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "ScoreZone") {

        }

        if (col.gameObject.tag == "DeadZone") {
            rigidbody.simulated = false;
        }
    }  
}

[System.Serializable]
public class SpriteCollection {
    public string name;
    public Texture sheet;
 
    [System.NonSerialized]
    public Sprite[] sprites;
}