using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{

    private CircleCollider2D myImageCollider
    ;
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
    bool isBig = false;
 
void Start() {
   thisTF = GetComponent<Transform>();
}
 
void OnMouseDown() {
    if(!isBig)
    {
    Vector2 scaleUp = new Vector2(thisTF.localScale.x * 4, thisTF.localScale.y * 4);
    thisTF.localScale = scaleUp;

    this.myImageCollider
    .radius *= 4;

    isBig = true;
    }

    else if(isBig)
    {
        //Debug.Log("Is Big!");
        Vector2 scaleUp = new Vector2(thisTF.localScale.x / 4, thisTF.localScale.y / 4);
        thisTF.localScale = scaleUp;

        this.myImageCollider
        .radius /= 4;
 

        isBig = false;

    }
}

void Update(){
    
}

}


