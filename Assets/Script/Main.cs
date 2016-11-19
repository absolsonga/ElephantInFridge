using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public Text highScore;

    void Start()
    {
        highScore.text = "" + PlayerPrefs.GetFloat("Highscore", 0);
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void start()
    {
        SoundManager.instance.PlaySound1();
        SceneManager.LoadScene(1);
    }
}
