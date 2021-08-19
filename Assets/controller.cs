using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class controller : MonoBehaviour
{

    public static GameObject nextButton;
    public static GameObject congrats;
    public static GameObject wrong;
    //public Text scoreText;
    public static int points = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        nextButton = GameObject.Find("NextButton");
        nextButton.SetActive(false);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Victory")
        nextButton.SetActive(true);

        congrats = GameObject.Find("Congrats");
        congrats.SetActive(false);

        wrong = GameObject.Find("Wrong");
        wrong.SetActive(false);

        //scoreText = GameObject.Find("NumPoints").GetComponent<TMPro.TextMeshProUGUI>();

    }

    void Update()
    {
        GameObject.Find("NumPoints").GetComponent<TMPro.TextMeshProUGUI>().text = "POINTS: " + points;
        //scoreText.text = points.ToString();
        //Debug.Log(scoreText.text);
        //Debug.Log(points);
    }
}
