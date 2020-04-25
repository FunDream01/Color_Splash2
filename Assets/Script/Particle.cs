using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Color32 color;
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
            if (Mixer.ColorIndex(ObstacleIndex,ColorIndex)!=0){
                ColorIndex=Mixer.ColorIndex(ObstacleIndex,ColorIndex);
                color = IntToColor.switchColor(ColorIndex);

                spriteRenderer.color=color;
            }
        }
    }
}
