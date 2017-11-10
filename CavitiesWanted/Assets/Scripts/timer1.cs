using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer1 : MonoBehaviour {

    Image fillImg;
    float timeLeft = 60f;
    public Text timerSeconds;
    public string levelToLoad;
    public Color loadToColor = Color.black;

    void Start () {
        fillImg = this.GetComponent<Image>();
    }

    void Update() {

        timeLeft -= Time.deltaTime;
        fillImg.fillAmount = timeLeft / 60;
        timerSeconds.text = timeLeft.ToString("f1");// + " seconds left!";

        if (timeLeft <= 0)
        {
            Initiate.Fade(levelToLoad, loadToColor, 3.0f);
        }

    }
}
