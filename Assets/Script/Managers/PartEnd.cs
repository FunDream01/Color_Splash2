using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartEnd : MonoBehaviour
{
    public int NextPartIndex;
    public float NumberofDots;
    public float DotsNeeded;
    float startTime = -1;
    public bool oki = false;
    const float LOSE_SECONDS = 10f;
    public bool loss = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(startTime < 0) return;
        if (oki) return;
        if(Time.time - startTime  > LOSE_SECONDS)
        {
            LevelManager.instant.Lose();
            Debug.Log(NextPartIndex +" loss");
            loss = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool myJob = true;
        if(StepsManager.Instance.Step < (NextPartIndex - 1)) { myJob = false;}  

        if (other.CompareTag(Tags.Particle))
        {
            startTime = Time.time;
            NumberofDots++;
            if (myJob && NumberofDots == SpawnerManager.Instance.BallsOfSpawner[NextPartIndex-1] && !loss)
            {
            startTime = -1;
            oki = true;
                StepsManager.Instance.NextStep(NextPartIndex);
                StepsManager.Instance.Step=NextPartIndex;
            }
        }
    }
}
