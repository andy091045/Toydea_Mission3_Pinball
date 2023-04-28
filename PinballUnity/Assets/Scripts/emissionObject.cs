using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bounceObject emission Prototype
public class emissionObject : MonoBehaviour
{
    [Header("Flashing")]
    [SerializeField] private Color originColor_;
    [SerializeField] private float DesiredIntensity = 10.0f;
    [SerializeField] private float NowIntensity = 1.0f;
    [SerializeField] private float Increase = 0.3f;
    [SerializeField] private bool IsFlashing = false;
    [SerializeField] private int FlashingTimes = 2;
    private float originIntensity_;    
    private int times = 0;

    private void Start()
    {
        originColor_ = this.transform.GetComponent<MeshRenderer>().material.color;
        originIntensity_ = NowIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        TryFlashing();        
    }

    private void TryFlashing()
    {
        if (IsFlashing)
        {
            this.transform.GetComponent<MeshRenderer>().material.SetVector("_EmissionColor", originColor_ * NowIntensity);
            NowIntensity = NowIntensity + Increase;
            if (NowIntensity > DesiredIntensity)
            {
                NowIntensity = originIntensity_;
                this.transform.GetComponent<MeshRenderer>().material.SetVector("_EmissionColor", originColor_ * NowIntensity);
                times++;
                if(times > FlashingTimes)
                {
                    IsFlashing = false;
                    times = 0;
                }
            }
        }        
    }
}
