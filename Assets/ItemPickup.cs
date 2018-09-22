using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class ItemPickup : MonoBehaviour {
        private GameObject myGameObject;
        private PlatformerCharacter2D m_Character;

		// Use this for initialization
		void Start () {
            myGameObject = GameObject.Find("Player");
            m_Character = myGameObject.GetComponent<PlatformerCharacter2D>();
		}

		void OnTriggerEnter2D(Collider2D other){
            switch (gameObject.name)
            {
                case "PropelPickup":
                    m_Character.propel = true;
                    break;
                case "GravPickupTemp":
                    m_Character.grav[0] = true;
                    break;
                case "GravPickup":
                    m_Character.grav[1] = true;
                    break;
                case "KeyPickup":
                    m_Character.key = true;
                    break;
                case "KnifePickup":
                    GameObject.Find("Knife").GetComponent<knife>().enabled = true;
                    break;
            }
		}
        void OnTriggerExit2D(Collider2D other)
        {
            if(gameObject.name == "GravPickupTemp"){
                m_Character.grav[0] = false;
            }
        }
	}
}