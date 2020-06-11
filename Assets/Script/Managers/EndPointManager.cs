using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointManager : MonoBehaviour
{
    public COLOR_CODE WinColor;
    private int WinPartical;
    public int NumberOfParticalToWin;
    private int ElsePartical;
    public int NumberOfParticalToLose;
    public bool Filled;
    public bool Win;
    public int State=0; 
    public SpriteRenderer Colored;
    public Color32 spcolor;

    void Start()
    {
       // WinColor=LevelManager.instant.WinColor;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.Particle)&&StepsManager.Instance.Step==SpawnerManager.Instance.NumberOfSteps){

            Destroy(other.gameObject);
            Particle particle=other.GetComponent<Particle>();

            if (particle.ColorIndex==WinColor){
                WinPartical++;
                FillWinColor();
                if (WinPartical==SpawnerManager.Instance.FinalWinBalls){
                    State=2;
                    Filled=true;
                    Win=true;
                    LevelManager.instant.CheckEndPoints();
                }
            }
            else{
                ElsePartical++;
                if (ElsePartical==SpawnerManager.Instance.FinalLoseBalls){
                    State=1;
                    Filled=true;
                    Win=false;
                    LevelManager.instant.CheckEndPoints();
                }
            }
        }
    }
    void FillWinColor(){
        spcolor = Colored.color;
        if (spcolor.a>230){
            spcolor.a=255;
        }else{ 
            spcolor.a+=10;
        }
        Colored.color = spcolor;
    }
}
