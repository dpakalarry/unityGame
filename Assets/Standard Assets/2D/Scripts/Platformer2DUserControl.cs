using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private Vector2 grav;

        private float time;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            grav = Physics2D.gravity;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            grav = Physics2D.gravity;
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // Pass all parameters to the character control script.
            m_Character.Move(h, v, crouch, m_Jump, false);
            m_Jump = false;

            // Setting gravity to IJKL inputs
            if (m_Character.grav[0] || m_Character.grav[1])
            {
                if(Input.GetKey(KeyCode.J)){
                    m_Character.transform.rotation = Quaternion.AngleAxis(-90,Vector3.forward);
                    grav = new Vector2((float)-9.8, 0);
                } else if (Input.GetKey(KeyCode.L)){
                    m_Character.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                    grav = new Vector2((float)9.8, 0);
                } else if (Input.GetKey(KeyCode.I)){
                    m_Character.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
                    grav = new Vector2(0, (float)9.8);
                } else if (Input.GetKey(KeyCode.K)){
                    m_Character.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
                    grav = new Vector2(0, (float)-9.8);
                }
                Physics2D.gravity = grav;
            }

            //Propellant
            if (m_Character.propel)
            {
                if (Input.GetKey(KeyCode.U)){
                    for (int i = 0; i < 8; i++) { m_Character.Move(-1, 0, crouch, m_Jump, true); }
                }
                if (Input.GetKey(KeyCode.O)){
                    for (int i = 0; i < 8; i++) { m_Character.Move(+1, 0, crouch, m_Jump, true); }
                }
            }

        }
    }
}
