using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Stage3 : IState
{
    private StateManager stateManager;

    public Stage3(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public void OnEnter()
    {
        //�V���J�n���J���C���㉺�J�V���� ���L�I�̑͝���y

        //�L�����L�V��{���ғI趕������I�X��(���)�C����n�`�n��
    }

    public void OnExit()
    {
        //萕��J�V���� 

        //萕n�`�n��
    }

    public void OnUpdate()
    {
        

    }
}
