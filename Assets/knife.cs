using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D{
    public class knife : MonoBehaviour
    {
        private PlatformerCharacter2D m_player;

        private float time;
        private float bgnLag;
        private float endLag;
        private float duration;

        BoxCollider2D box;
        SpriteRenderer boxSpr;

        private void Start()
        {
            m_player = GameObject.Find("Player").GetComponent<PlatformerCharacter2D>();
            transform.position = new Vector3(-1000, 0, 0);
            endLag = -.5f;
            bgnLag = 0f;
            duration = 0.5f;
        }
        private void Awake()
        {
            box = GetComponent<BoxCollider2D>();
            boxSpr = GetComponent<SpriteRenderer>();
        }
        private void Update() {
            if (Input.GetKey(KeyCode.E)) {
                if (!box.enabled && time < endLag) {
                    time = duration + bgnLag;
                }
            }

            time -= Time.deltaTime;
            if (time <= 0){
                box.enabled = false;
                boxSpr.enabled = false;
            } else if(time <= duration){
                box.enabled = true;
                boxSpr.enabled = true;
            } else{
                if (Physics2D.gravity.y != 0) {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    transform.position = new Vector3(m_player.transform.position.x + (m_player.m_FacingRight ? 0.25f : -1.75f), m_player.transform.position.y, m_player.transform.position.z);
                }
                else {
                    transform.rotation = new Quaternion(0, 0, 90, 90);
                    transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y + (m_player.m_FacingRight ? 0.25f : -1.5f), m_player.transform.position.z);
                }
            }


        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.name == "Enemy"){
                other.gameObject.transform.position = new Vector3(-1000,0,0);
            }
        }
    }
}

