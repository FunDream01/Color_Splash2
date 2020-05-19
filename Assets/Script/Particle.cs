using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Color color;
    public int ColorIndex = 0 ;
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
            int ObstacleIndex = other.GetComponent<ColorizingObstacle>().ColorIndex;
            if (Mixer.ColorIndex(ObstacleIndex,ColorIndex)!=100){
                
                ColorIndex=Mixer.ColorIndex(ObstacleIndex,ColorIndex);
                color = LevelManager.instant.colors[ColorIndex].Color;
                
                color.a=1;
                spriteRenderer.color=color;
            }else{
                
            }
        }
    }
}
