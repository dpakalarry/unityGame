using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    public float fallMult = 1f;
    public float lowJump = 1f;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Setting correct gravity (x or y)
        float grav = Physics2D.gravity.y != 0 ? Physics2D.gravity.y : Physics2D.gravity.x;
        //Setting the jump direction based on gravity (x or y)
        Vector2 dir = Physics2D.gravity.y != 0 ? Vector2.up : Vector2.right;
        //Getting current "vertical" velocity based on gravity
        float vel = Physics2D.gravity.y != 0 ? rb.velocity.y : rb.velocity.x;
        //changing velocity to fall faster and jump shorter if jump button is not held
        rb.velocity += dir * grav * ((((grav > 0) == (vel > 0)) ? fallMult : ((!Input.GetButton("Jump")) ? lowJump : 1)) - 1) * Time.deltaTime;
	}
}
