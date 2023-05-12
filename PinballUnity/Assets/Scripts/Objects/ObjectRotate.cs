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

    public ObjectType objectType;

    void Start()
    {
        
    }

    void Update()
    {
        if (objectType == ObjectType.WallObject)
        {
            gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, 10.0f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(objectType == ObjectType.WallObject)
            {
                gameObject.transform.RotateAround(gameObject.transform.position, Vector3.up, yAngleSpeedMultiply_ * yAngleSpeed_ * Time.deltaTime);
            }            
        }
        else
        {
            if (objectType == ObjectType.MissionObject)
            {
                gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), yAngleSpeed_ * Time.deltaTime);
            }
        }
    }

    public enum ObjectType
    {
        MissionObject, WallObject
    }
}
