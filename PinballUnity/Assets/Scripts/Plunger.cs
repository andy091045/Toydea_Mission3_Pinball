using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : CollisionObject
{
    [SerializeField] private float force_;

    private float totalForce_ = 0;

    private GameObject ball_;

    /// <summary>
    /// totalForce_‚Ìmin_force
    /// </summary>
    private float fMin_ = 0.5f;

    /// <summary>
    /// totalForce_‚Ìmax_force
    /// </summary>
    private float fMax_ = 6;

    void Start()
    {
        ball_ = null;
    }

    void Update()
    {
        totalForce_ += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            totalForce_ = 0;            
        }
        if (Input.GetKeyUp(KeyCode.Space) && ball_ != null)
        {
            ball_.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, Mathf.Clamp(totalForce_, fMin_, fMax_) * force_));
            totalForce_ = 0;
        }
        //Debug.Log(totalForce_);
    }

    protected override void onCollisionEnterTag(Collision collision)
    {
        ball_ = collision.transform.gameObject;
    }
    protected override void onCollisionExitTag(Collision collision)
    {
        ball_ = null;
    }
}
