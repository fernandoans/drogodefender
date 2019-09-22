using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int life;

    void Start() {
        life = 1;
    }

    void Update() {
        if (life == 0) {
            Destroy(this, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ground")) {
            // Colidiu com o solo
            Destroy (gameObject);
        }
        if (other.CompareTag("Player")) {
            // Colidiu com Drogo
            Destroy (gameObject);
        }
        if (other.CompareTag("Fire")) {
            // Colidiu com Fogo
            life -= 1;
            if (life <= 0) {
                // gameObject.SetActive(false);
                Destroy (gameObject);
            }
        }
    }

}
