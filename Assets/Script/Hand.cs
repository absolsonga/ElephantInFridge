using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite[] resource = new Sprite[1];
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();	
	}

    public void setImage(int index)
    {
        spriteRenderer.sprite = resource[index];
    }

	// Update is called once per frame
	void Update () {
	
	}
}
