using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.

public class circle3 : MonoBehaviour
{
    //gets collider information so I can scale the collider with the circle
    private CircleCollider2D myImageCollider;
    private void Awake()
    { 
    this.myImageCollider = GetComponent<CircleCollider2D>(); 
    }

    //variable declarations
    private Transform thisTF;
    public bool itBig = false; //bool for other scripts
   
    bool begin = false;
    bool canClick = true;
 

void Start() {
   thisTF = GetComponent<Transform>();
}
 
public void OnMouseDown() {
    if(!itBig && canClick)
    {
    itBig = true;
    begin = true; 
    //Debug.Log("Hold it! Big!");
    }

    else if(itBig && canClick)
    {
    itBig = false;
    begin = true;
    //Debug.Log("Take that! Small!");
    }
}

int counter = 0;
void Update(){

    //for every update cycle, check if circle is big
    //if circle is small, enlarge circle and its collider
    //if circle is big, bring it back to original size
    //this is controlled by user clicks 
    if(itBig && begin)
    {
    canClick = false;
    Vector2 scaleUp = new Vector2(thisTF.localScale.x + 1, thisTF.localScale.y + 1);
    thisTF.localScale = scaleUp;

    this.myImageCollider.radius += 0.0001f;

    /*if(this.myImageCollider.radius >= 0.01f)
    {
        begin = false;
    }*/
    counter++;
    
    if(counter >= 220)
    {
        begin = false;
        counter = 0;
        Debug.Log("Is big now?");
  
        canClick = true;
    }
}

    else if(!itBig && begin)
    {
        canClick = false;
        //Debug.Log("Is Big!");
        Vector2 scaleUp = new Vector2(thisTF.localScale.x - 1, thisTF.localScale.y - 1);
        thisTF.localScale = scaleUp;

        this.myImageCollider
        .radius -= 0.0001f;

        if(this.myImageCollider.radius <= 0.5)
    {
        begin = false;
        Debug.Log("Is smol now?");

        canClick = true;
    }
}
    }
}


