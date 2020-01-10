using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool run = false;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            run = CrossPlatformInputManager.GetButton("Fire3");
            //Debug.Log(CrossPlatformInputManager.GetButtonDown("Fire1") + "Fire1");
            //Debug.Log(CrossPlatformInputManager.GetButtonDown("Jump") + "jump");
            //Debug.Log(CrossPlatformInputManager.GetButtonDown("Fire2")+ "Fire2");
            //Debug.Log(CrossPlatformInputManager.GetButtonDown("Fire3") + "Fire3");

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump, run);
            m_Jump = false;
        }
    }
}
