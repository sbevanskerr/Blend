using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindAnswer : MonoBehaviour
{

    public bool hasWon = false;
    public GameObject control;

    void Start()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
    }

    public void OnMouseDown() {
    //RGBA(0.500, 0.000, 0.500, 0.706
    Debug.Log("Clicked on small circle!");
    Debug.Log("Its color was");
    Debug.Log(GetComponent<SpriteRenderer>().color);
    Color currentColor = GetComponent<SpriteRenderer>().color;

    Scene currentScene = SceneManager.GetActiveScene();
    string sceneName = currentScene.name;
    Color answerColor = new Color(0f, 0f, 0f, 0f);

    if(sceneName == "Level 1") {
    answerColor = new Color(0.500f, 0.0f, 0.500f, 0.706f);
    Debug.Log("Level is 1");
    }

    if(sceneName == "Level 2") {
    answerColor = new Color(0.500f, 1.0f, 0.500f, 0.706f);
    Debug.Log("Level is 2");
    }

    if(sceneName == "Level 3") {
    answerColor = new Color(1.0f, 0.4759924f, 0.03537735f, 0.706f);
    Debug.Log("Level is 3");
    }
    

    //Color answerColor = new Color(0.500f, 0.0f, 0.500f, 0.706f);
    

   /* if(currentColor.r == answerColor.r
    && currentColor.g == answerColor.g
    && currentColor.b == answerColor.b)*/
    if(Mathf.Approximately(currentColor.r, answerColor.r)
    && Mathf.Approximately(currentColor.g, answerColor.g)
    && Mathf.Approximately(currentColor.b, answerColor.b))
    {
        Debug.Log("Correct!");
        controller.wrong.SetActive(false);
        control = GameObject.Find("EventSystem");
        controller otherScript = control.GetComponent<controller>();

        controller.nextButton.SetActive(true);
        controller.congrats.SetActive(true);
        if(!hasWon)
    
        controller.points += 10;
        

        hasWon = true;
    }
    else{
        controller.congrats.SetActive(false);
        
        control = GameObject.Find("EventSystem");
        controller otherScript = control.GetComponent<controller>();

        if(!hasWon)
        controller.points -= 10;
        

        controller.wrong.SetActive(true);
        Debug.Log("Wrong! Answer is");
        Debug.Log(answerColor);

        if(currentColor.r != answerColor.r)
        Debug.Log("r value was wrong");

        if(currentColor.g != answerColor.g) {
        Debug.Log("g value was wrong");
        Debug.Log(currentColor.g);
        }

        if(currentColor.b != answerColor.b) {
        Debug.Log("b value was wrong");
        Debug.Log(currentColor.b);
        }
    }
    
    }

}
