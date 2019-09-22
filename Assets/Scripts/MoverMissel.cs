using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMissel : MonoBehaviour {

    private float speed;

    // Start is called before the first frame update
    void Start() {
        speed = 1.2f;        
    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
