using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

    const float speed = 1.0f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GetComponent<Transform>().position.y < -6.19f)
        {
            this.transform.Translate(Vector2.up * 10);
        }
        this.transform.Translate(Vector2.down * speed * Time.deltaTime);
	}
}
