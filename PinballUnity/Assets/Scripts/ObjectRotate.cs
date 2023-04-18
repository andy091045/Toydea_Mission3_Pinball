using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ObjectRotate : MonoBehaviour
{
    [Label("‰ñ“]‘¬“x")]
    [SerializeField] float yAngleSpeed_ = 50.0f;

    [Label("ƒvƒŒƒXSpace‘¬“x”{—¦")]
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
