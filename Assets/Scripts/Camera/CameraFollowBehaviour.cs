using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControls
{
    [System.Flags]
    public enum CameraBoundType
    {
        Unbound = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
        All = Left | Right | Up | Down
    }

    public class CameraFollowBehaviour : MonoBehaviour
    {

        public Transform target;

        public new Camera camera;

        public float xLimit;

        public float upperLimit;
        public float bottomLimit;

        public CameraBoundType boundType;

        private void LateUpdate()
        {
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
            Vector3 dest = transform.position;

            if (delta.x > xLimit && !((boundType & CameraBoundType.Right) == CameraBoundType.Right))
                dest.x = target.position.x - xLimit;
            else if (delta.x < -xLimit && !((boundType & CameraBoundType.Left) == CameraBoundType.Left))
                dest.x = target.position.x + xLimit;

            if (delta.y > upperLimit && !((boundType & CameraBoundType.Down) == CameraBoundType.Down))
                dest.y = target.position.y - upperLimit;
            else if (delta.y < -bottomLimit && !((boundType & CameraBoundType.Up) == CameraBoundType.Up))
                dest.y = target.position.y + bottomLimit;

            dest.z = transform.position.z;

            transform.position = dest;

            //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        }

    }
}
