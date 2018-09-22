using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D{
    public class door : MonoBehaviour
    {

        private GameObject myGameObject;
        private PlatformerCharacter2D m_Character;

        // Use this for initialization
        void Start(){
            myGameObject = GameObject.Find("Player");
            m_Character = myGameObject.GetComponent<PlatformerCharacter2D>();

        }
        public void OnTriggerEnter2D(Collider2D other){
            if (other.tag == "Player"){
                if (m_Character.key){
                    transform.position = new Vector3(-1000, 0, 0);
                }
            }
        }
    }

}
