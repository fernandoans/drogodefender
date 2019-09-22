using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VooDragao : MonoBehaviour {

    public static VooDragao instance;

    public float velocidade;
    public float tapForce = 1;
    public float tiltSmooth = 5;
    public Animator animator;
    private Vector3 posicao;
    private new SpriteRenderer renderer;
    Rigidbody2D drogoRB;
    private SpriteRenderer myRenderer;

    public GameObject fogoAzul;
    public float fogoForce;

    private bool startMoving = false;
    public bool StartMoving { get { return startMoving; }}

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        renderer = GetComponent<SpriteRenderer>();
        drogoRB = GetComponent<Rigidbody2D>();
        animator.SetBool("esquerda", false);
        startMoving = true;
    }

    // Update is called once per frame
    void Update() {
        posicao = transform.position;
//        if (Input.GetMouseButtonDown(0)) {
        if (Input.GetKey("up")) {
            drogoRB.AddForce(Vector2.up * 2, ForceMode2D.Force);
        }
        if (Input.GetKey("down")) {
            drogoRB.AddForce(Vector2.up * -1, ForceMode2D.Force);
        }
        if (posicao.y > 4.2) {
            transform.position = new Vector3(posicao.x, 4.2f, posicao.z);
        }

        bool esq = animator.GetBool("esquerda");
        if (Input.GetKey("right")) {
            esq = false;
            animator.SetBool("esquerda", esq);
            if (posicao.x < 8.33) {
                transform.Translate(velocidade,0,0);
            }
        } else if (Input.GetKey("left")) {
            esq = true;
            animator.SetBool("esquerda", esq);
            if (posicao.x > -8.33) {
                transform.Translate(-velocidade, 0, 0);
            }
        }

        // Verificar Fire1 para fazer fogoAzul
        if (Input.GetButtonDown("Fire1")) {
            GameObject newFogo = Instantiate(fogoAzul, transform.position, transform.rotation);
            if (esq) {
                newFogo.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * fogoForce);
            } else {
                newFogo.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * fogoForce);
            }
            Destroy(newFogo, 2.0f);
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