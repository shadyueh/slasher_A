using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserController : MonoBehaviour
    {
        private ThirdPersonCharacter mainCharacter; // ThirdPersonCharacter on the object
        private Transform mainCam; // Main camera in the scenes transform
        private bool jump;

        // Start is called before the first frame update
        void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                mainCam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            mainCharacter = GetComponent<ThirdPersonCharacter>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!jump)
            {
                jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }
    }
}