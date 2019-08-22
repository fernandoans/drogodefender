using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VooDragao : MonoBehaviour {

    public float velocidade;
    public float tapForce = 1;
    public float tiltSmooth = 5;
    public Animator animator;
    private Vector3 posicao;
    private new SpriteRenderer renderer;
    Rigidbody2D drogoRB;
    private SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        drogoRB = GetComponent<Rigidbody2D>();
        animator.SetBool("esquerda", false);
//        rigidbody.simulated = false;
    }

    // Update is called once per frame
    void Update() {
        posicao = transform.position;
        if (Input.GetMouseButtonDown(0)) {
            if (posicao.y > 4.2) {
                transform.position = new Vector3(posicao.x, 4.2f, posicao.z);
            } else {
                drogoRB.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            }
        }
        if (Input.GetKey("right")) {
            animator.SetBool("esquerda", false);
            if (posicao.x < 8.33) {
                transform.Translate(velocidade,0,0);
            }
        } else if (Input.GetKey("left")) {
            animator.SetBool("esquerda", true);
            if (posicao.x > -8.33) {
                transform.Translate(-velocidade, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "ScoreZone") {

        }

        if (col.gameObject.tag == "DeadZone") {
            drogoRB.simulated = false;
        }
    }  
}