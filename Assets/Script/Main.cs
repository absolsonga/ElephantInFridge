using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public static int score = 0;
    public static int highscore = 0;

	// Update is called once per frame
	void Update () {
	
	}

    public void start()
    {
        SceneManager.LoadScene(1);
    }
}
