using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    private int WinColor;
    public int WinPartical;
    public int NumberOfParticalToWin;
    public int ElsePartical;
    public int NumberOfParticalToLose;
    void Start()
    {
        WinColor=LevelManager.instant.WinColor;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Particle)){
            Particle particle=other.GetComponent<Particle>();
            if (particle.ColorIndex==WinColor){
                WinPartical++;
                if (WinPartical==NumberOfParticalToWin){
                    LevelManager.instant.Win();
                }
            }
            else{
                ElsePartical++;
                if (ElsePartical==NumberOfParticalToLose){
                    LevelManager.instant.Lose();
                }
            }
        }
    }
}
