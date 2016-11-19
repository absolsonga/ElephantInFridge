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
        SoundManager.instance.PlaySound1();
        SceneManager.LoadScene(0);
    }
}
