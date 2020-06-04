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
        if (other.CompareTag(Tags.Particle)&&StepsManager.Instance.Step==2){

            Destroy(other.gameObject);
            Particle particle=other.GetComponent<Particle>();

            if (particle.ColorIndex==WinColor){
                WinPartical++;
                FillWinColor();
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
