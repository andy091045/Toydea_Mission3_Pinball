using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bounceObject emission Prototype
public class emissionObject : MonoBehaviour
{
    [Header("Flashing")]
    public Color OriginColor;
    [SerializeField] private float desiredIntensity_ = 5.0f;
    [SerializeField] private float originIntensity_ = 1.0f;
    [SerializeField] private float nowIntensity_ = 2.0f;
    [SerializeField] private float increase_ = 0.004f;

    private void Update()
    {
        TryFlashing();
    }

    private void TryFlashing()
    {
        this.transform.GetComponent<SpriteRenderer>().material.SetVector("_EmissionColor", OriginColor * nowIntensity_);
        nowIntensity_ = nowIntensity_ + increase_;
        if (nowIntensity_ > desiredIntensity_ || nowIntensity_ < originIntensity_)
        {
            increase_ = -increase_;
        }
    }
}
