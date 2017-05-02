using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindAI : MonoBehaviour
{
    public float xSpeed;
    public new Rigidbody2D rigidbody;

    public bool CanMove;

    private void Update()
    {
        if (CanMove)
            rigidbody.velocity = new Vector2(xSpeed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PathfindNode node = collision.GetComponent<PathfindNode>();

        if (node != null)
        {
            PathInfo path = rigidbody.velocity.x > 0 ? node.PosInfo : node.NegInfo;

            if (path == null)
                return;

            if (path.YForce != 0)
                rigidbody.AddForce(new Vector2(0, path.YForce));
            if (path.XSpeed != 0)
            {
                xSpeed = path.XSpeed;
            }
        }

    }

}
