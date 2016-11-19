using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {

    public Text highScore;

    void Start()
    {
        highScore.text = "" + PlayerPrefs.GetFloat("Highscore", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
