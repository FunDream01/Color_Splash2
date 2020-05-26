using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Color color;
    public COLOR_CODE ColorIndex = COLOR_CODE.NONE ;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward*Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag(Tags.Obstacle)){
            COLOR_CODE ObstacleIndex = (COLOR_CODE) (1 << other.GetComponent<ColorizingObstacle>().ColorIndex);
                ColorIndex=(ObstacleIndex|ColorIndex);
                color = Mixer.Index2Color(ColorIndex, FindObjectOfType<LevelManager>()); //LevelManager.instant.colors[ColorIndex].Color;
                color.a=1;
                spriteRenderer.color=color;
                
        }
    }
}