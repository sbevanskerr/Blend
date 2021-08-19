using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle2 : MonoBehaviour
{

    private CircleCollider2D myImageCollider;
    
    private void Awake()
    { 
    this.myImageCollider
     = GetComponent<CircleCollider2D>(); 
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collision detected!");
        //color code
    }


    private Transform thisTF;
    bool isLarge = false;
    bool start = false;
 
void Start() {
   thisTF = GetComponent<Transform>();
}
 
void OnMouseDown() {
    if(!isLarge)
    {
    isLarge = true;
    start = true; 
    Debug.Log("Big!");
    }

    else if(isLarge)
    {
    isLarge = false;
    start = true;
    Debug.Log("Small!");
    }
}

void Update(){

    if(isLarge && start)
    {
    Vector2 scaleUp = new Vector2(thisTF.localScale.x + 1, thisTF.localScale.y + 1);
    thisTF.localScale = scaleUp;

    this.myImageCollider
    .radius += 1;

    if(this.myImageCollider.radius >= 200)
    {
        start = false;
    }

    }

    else if(!isLarge && start)
    {
        //Debug.Log("Is Big!");
        Vector2 scaleUp = new Vector2(thisTF.localScale.x - 1, thisTF.localScale.y - 1);
        thisTF.localScale = scaleUp;

        this.myImageCollider
        .radius -= 1;

        if(this.myImageCollider.radius <= 0.5)
    {
        start = false;
    }

    }
    
}

}


