using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;

public class Stage3 : StateBase
{
    private float recordOriginGravity_;

    private float recordOriginBounceMaxForce_;

    private float recordOriginBounceMinForce_;

    public Stage3(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        //���L�I�̑͝���y
        recordOriginGravity_ = GameInput.Instance.Gravity;
        GameInput.Instance.Gravity = recordOriginGravity_ * 2.0f;

        recordOriginBounceMaxForce_ = GameInput.Instance.BounceMaxForce;
        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_ * 1.3f;

        recordOriginBounceMinForce_ = GameInput.Instance.BounceMinForce;
        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_ * 1.3f;

        //�V���J�n���J���C���㉺�J�V����

        //�L�����L�V��{���ғI趕������I�X��(���)�C����n�`�n��
        GameManager.Instance.MissionManager.IsStage3MissionStart = true;
    }

    public override void OnExit()
    {
        //�Ҍ����L�I��
        GameInput.Instance.Gravity = recordOriginGravity_;

        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_;

        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_;

        //萕��J�V���� 

        //萕n�`�n��        
        GameManager.Instance.MissionManager.IsStage3MissionStart = false;
    }

    public override void OnUpdate()
    {

    }   
}
