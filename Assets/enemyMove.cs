using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour {

    private float time;
    private float dist;
    private float velocity;
    private bool movRight;
    private float curTime;

	// Use this for initialization
	void Start () {
        dist = 10f;
        time = 2f;
        velocity = dist / time;
        curTime = 0;
        movRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        transform.Translate(new Vector3(velocity * (movRight ? 1 :-1), 0, 0) * Time.deltaTime);
        if(curTime >= time){
            movRight = !movRight;
            curTime = 0;
        }

	}
}
