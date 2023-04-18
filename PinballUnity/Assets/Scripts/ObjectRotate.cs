using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectRotate : MonoBehaviour
{
    [SerializeField] float yAngleSpeed_ = 50.0f;

    [SerializeField] float yAngleSpeedMultiply_ = 3;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, yAngleSpeedMultiply_ * yAngleSpeed_ * Time.deltaTime);
        }
        else
        {
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, yAngleSpeed_ * Time.deltaTime);
        }
    }
}
