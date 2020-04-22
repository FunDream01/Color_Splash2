using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama_is_bear : MonoBehaviour
{
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Red") 
        {
            renderer.color = Color.green;
        }
        else if (col.gameObject.name == "Blue")
        {
            renderer.color = Color.red;
        }
    }

}
