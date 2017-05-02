using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControls
{
    public class CameraBoundBehaviour : MonoBehaviour
    {
        public CameraBoundType boundType;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("MainCamera"))
            {
                collision.GetComponent<CameraFollowBehaviour>().boundType |= boundType;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("MainCamera"))
            {
                collision.GetComponent<CameraFollowBehaviour>().boundType &= ~boundType;
            }
        }

    }
}
