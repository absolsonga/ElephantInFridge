using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {
    const bool LEFT = false, RIGHT = true;
    const float speed = 6.0f;
    bool direction;

	// Use this for initialization
	void Start () {
        direction = Random.Range(0, 2) == 0;
        this.GetComponent<SpriteRenderer>().flipX = direction;
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Translate(Vector2.left * (direction ? -1 : 1) * speed * Time.deltaTime);
	}
}
