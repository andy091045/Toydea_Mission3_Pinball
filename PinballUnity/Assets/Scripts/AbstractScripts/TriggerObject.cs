using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerObject : MonoBehaviour
{
    protected virtual string tag_ { get; } = "ball";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag_))
        {
            onTriggerEnterTag(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(tag_))
        {
            onTriggerStayTag(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag_))
        {
            onTriggerExitTag(other);
        }
    }

    protected virtual void onTriggerEnterTag(Collider other)
    {

    }
    protected virtual void onTriggerStayTag(Collider other)
    {

    }
    protected virtual void onTriggerExitTag(Collider other)
    {

    }
}
