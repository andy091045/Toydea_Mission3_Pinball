using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionObject : MonoBehaviour
{
    protected virtual string tag_ { get;} = "ball";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag_))
        {
            onCollisionEnterTag(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag_))
        {
            onCollisionExitTag(collision);
        }
    }

    protected virtual void onCollisionEnterTag(Collision collision)
    {

    }
    protected virtual void onCollisionExitTag(Collision collision)
    {

    }

}
