using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmNamespace;

public class ArmType : MonoBehaviour
{
    public ChooseArmType chooseArmType;

    public float startAngle_ = 30.0f;
    public float rotateAngle_ = 45.0f;

    public Arm ArmScript;

    // Start is called before the first frame update
    void Start()
    {
        ArmScript = gameObject.GetComponent<Arm>();
        SetStartAngle();
        GameInput.Instance.onControlLeftArmEvent.AddListener(TryControllLeftArm);
        GameInput.Instance.onControlRightArmEvent.AddListener(TryControllRightArm);
    }

    public void SetStartAngle()
    {
        if(chooseArmType == ChooseArmType.LeftArm)
        {
            ArmScript.StartAngle = startAngle_;
        }
        else
        {
            ArmScript.StartAngle = -startAngle_;
        }
    }

    public void TryControllLeftArm()
    {
        if(chooseArmType == ChooseArmType.LeftArm)
        {
            ArmScript.KeyDown = true;
            ArmScript.TargetAngle = -(rotateAngle_ - startAngle_);
        }        
    }

    public void TryControllRightArm()
    {
        if(chooseArmType == ChooseArmType.RightArm)
        {
            ArmScript.KeyDown = true;
            ArmScript.TargetAngle = (rotateAngle_ - startAngle_);
        }            
    }

    public enum ChooseArmType
    {
        LeftArm, RightArm
    } 
}
