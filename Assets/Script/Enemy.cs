using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
            Debug.Log("gameover");
            //coll.gameObject.SendMessage("ApplyDamage", 10);

    }
}
