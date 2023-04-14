using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public float Force;
    float totalForce_ = 0;
    GameObject ball_;
    float fMin_ = 1;
    float fMax_ = 6;
    // Start is called before the first frame update
    void Start()
    {
        ball_ = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            totalForce_ += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) && ball_ != null)
        {
            ball_.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, Mathf.Clamp(totalForce_, fMin_, fMax_) * Force));
            totalForce_ = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ball_ = collision.transform.gameObject;
    }
    private void OnCollisionExit(Collision collision)
    {
        ball_ = null;
    }
}
