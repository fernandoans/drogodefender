using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //public or private identify
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        if (transform.position.x > 8.5f) {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        } else if (transform.position.x < -8.5f) {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }

        if (transform.position.y > 4.2f) {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        } else if (transform.position.y < -4.2f) {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
    }
}
