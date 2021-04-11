using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private int speed = 6;

    private Vector2 moveDir;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        moveDir = (transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate() {
        rb.velocity = moveDir * speed;

        if(Input.GetButton("Sprint")){
            rb.velocity = moveDir * (speed * 2);
        }
        if(Input.GetButtonDown("Dodge")){
            dodge();
        }
    }

    void dodge(){
        // TODO: Move the player a specific length of space quickly/introduce i-frames
    }
}
