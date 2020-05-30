using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartEnd : MonoBehaviour
{
    public int NextPartIndex;
    public float NumberofDots;
    public float DotsNeeded;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Particle))
        {
            NumberofDots++;
            if (NumberofDots == DotsNeeded)
            {
                StepsManager.Instance.NextStep(NextPartIndex);
                StepsManager.Instance.Step=NextPartIndex;
            }
        }
    }
}
