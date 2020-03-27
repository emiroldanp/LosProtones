using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    Transform bar;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(.4f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setSize(float size){
        bar.localScale = new Vector3(size,1f);
    }
    
    public void setColor(Color color){
        spriteRenderer.color = color;
    }
}
