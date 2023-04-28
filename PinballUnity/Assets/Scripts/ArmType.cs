using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmNamespace;

public class ArmType : MonoBehaviour
{
    public ChooseArmType chooseArmType;

    public float startAngle_ = 30.0f;
    [SerializeField] private float rotateAngle_ = 45.0f;

    Arm arm_;

    // Start is called before the first frame update
    void Start()
    {
        arm_ = gameObject.GetComponent<Arm>();
        SetStartAngle();
        GameInput.Instance.onControlLeftArmEvent.AddListener(TryControllLeftArm);
        GameInput.Instance.onControlRightArmEvent.AddListener(TryControllRightArm);
    }

    public void SetStartAngle()
    {
        if(chooseArmType == ChooseArmType.LeftArm)
        {
            arm_.StartAngle = startAngle_;
        }
        else
        {
            arm_.StartAngle = -startAngle_;
        }
    }

    private void TryControllLeftArm()
    {
        if(chooseArmType == ChooseArmType.LeftArm)
        {
            arm_.KeyDown = true;
            arm_.TargetAngle = -(rotateAngle_ - startAngle_);
        }        
    }

    private void TryControllRightArm()
    {
        if(chooseArmType == ChooseArmType.RightArm)
        {
            arm_.KeyDown = true;
            arm_.TargetAngle = (rotateAngle_ - startAngle_);
        }            
    }

    public enum ChooseArmType
    {
        LeftArm, RightArm
    } 
}
