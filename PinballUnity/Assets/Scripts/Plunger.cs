using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public float force;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && ball != null)
        {
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, force));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ball = collision.transform.gameObject;
    }
    private void OnCollisionExit(Collision collision)
    {
        ball = null;
    }
}
