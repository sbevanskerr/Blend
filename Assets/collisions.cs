using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{
    public GameObject newCircle;
    public GameObject prevColl;
    int newCirc = 0;
    private GameObject e; 

    private void OnTriggerStay2D(Collider2D other){
        //Debug.Log("Collision detected!");
        //creates script references for this object and who it collided with
        circle3 thisScript = GetComponent<circle3>();
        circle3 otherScript = other.gameObject.GetComponent<circle3>();

        //problem chunk: if both circles are big (ie finished expanding) they create a child
        //this should only happen once, controlled by the noNewCirc bool
        if(thisScript.itBig && otherScript.itBig && prevColl != other.gameObject && newCirc < 1)
        {
            Debug.Log("Time to make a new circle");
            e = Instantiate(newCircle) as GameObject;
            e.transform.position = (transform.position + other.transform.position) / 2;
            e.GetComponent<SpriteRenderer>().color = CombineColors(
                GetComponent<SpriteRenderer>().color, other.GetComponent<SpriteRenderer>().color
                );
            Debug.Log(e.GetComponent<SpriteRenderer>().color);


            newCirc++;
       }
       
       /*
       if(other.gameObject != null)
       prevColl = other.gameObject; 
       */
 }

/*void Update()
{
    circle3 thisScript = GetComponent<circle3>();
    if(!thisScript.itBig && newCirc > 0)
    {
        Destroy(e);
        newCirc--;
    }

}
   */ 

//function to combine colors
public static Color CombineColors(params Color[] aColors)
 {
     Color result = new Color(0,0,0,0);
     foreach(Color c in aColors)
     {
         result += c;
     }
     result /= aColors.Length;
     return result;
 }
    
}
