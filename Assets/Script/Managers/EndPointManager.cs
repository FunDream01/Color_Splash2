using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    public COLOR_CODE WinColor;
    public int WinPartical;
    public int NumberOfParticalToWin;
    public int ElsePartical;
    public int NumberOfParticalToLose;
    public bool Filled;
    public bool Win;
    public int State=0; 

    void Start()
    {
       // WinColor=LevelManager.instant.WinColor;
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
                    State=2;
                    Filled=true;
                    Win=true;
                    LevelManager.instant.CheckEndPoints();
                }
            }
            else{
                ElsePartical++;
                if (ElsePartical==NumberOfParticalToLose){
                    State=1;
                    Filled=true;
                    Win=false;
                    LevelManager.instant.CheckEndPoints();
                }
            }
        }
    }
}
