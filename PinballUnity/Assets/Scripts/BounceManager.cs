using DG.Tweening;
using GameManagerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceManager : MonoBehaviour
{
    public Material[] materials;
    [SerializeField] private GameObject[] bounceObjects;

    void Start()
    {
        GameManager.Instance.onChangeStateStateEvent.AddListener(ListenStateChange);
    }

    private void ListenStateChange(string name, string state)
    {
        switch (name)
        {            
            case "Stage2":
                if (state == "OnEnter")
                {
                    ChangeBounceObjectsMaterial(1);
                }
                break;
            case "Stage3":
                if (state == "OnEnter")
                {
                    ChangeBounceObjectsMaterial(2);
                }
                break;
            default:
                break;
        }
    }   

    private void ChangeBounceObjectsMaterial(int i)
    {
        foreach (var item in bounceObjects)
        {
            Renderer renderer = item.GetComponent<Renderer>();
            renderer.sharedMaterial = materials[i];

            BounceObject bounceObject = item.GetComponent<BounceObject>();
            bounceObject.OriginColor = materials[i].color;
        }
    }
}
