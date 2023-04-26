using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceManager : MonoBehaviour
{
    public Material[] materials;
    [SerializeField] private GameObject[] bounceObjects;

    void Start()
    {
        Stage2.OccurStage2 += ChangeColor2;
        Stage3.OccurStage3 += ChangeColor3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeColor2(string state)
    {
        if (state == "OnEnter")
        {
            foreach (var item in bounceObjects)
            {
                Renderer renderer = item.GetComponent<Renderer>();
                renderer.sharedMaterial = materials[1];
            }
        }
    }

    private void ChangeColor3(string state)
    {
        if (state == "OnEnter")
        {
            foreach (var item in bounceObjects)
            {
                Renderer renderer = item.GetComponent<Renderer>();
                renderer.sharedMaterial = materials[2];
            }
        }
    }

    private void OnDestroy()
    {
        Stage2.OccurStage2 -= ChangeColor2;
        Stage3.OccurStage3 -= ChangeColor3;
    }
}
