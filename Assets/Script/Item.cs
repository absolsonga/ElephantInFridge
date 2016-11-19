using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            Ingame.score += 200;
        }
    }
}
