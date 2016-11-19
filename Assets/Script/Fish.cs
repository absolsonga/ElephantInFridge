using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{
    const bool LEFT = false, RIGHT = true;
    const float speed = 8.5f;
    bool direction;
    SpriteRenderer sprite;
    float offsetY = 0.0f;

    // Use this for initialization
    void Start()
    {
        direction = Random.Range(0, 2) == 0;
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.flipX = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (direction ? -1 : 1) * speed * Time.deltaTime);
        //offsetY = Mathf.Sin(Time.time * 10) * 0.01f;
    }
}
