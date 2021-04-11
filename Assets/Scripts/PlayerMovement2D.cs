using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rigidbody2d;
    private Vector3 moveDir;
    private bool isSprintButtonDown;

    // Start is called before the first frame update
    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        moveDir = (transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetButton("Sprint")){
            isSprintButtonDown = true;
        }
    }

    void FixedUpdate() {
        rigidbody2d.velocity = moveDir * speed;

        if(isSprintButtonDown){
            rigidbody2d.velocity = moveDir * (speed * 2);
            isSprintButtonDown = false;
        }
    }
}
