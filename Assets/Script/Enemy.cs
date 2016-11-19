using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // Update is called once per frame
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
            SoundManager.instance.PlaySound2();
            GameObject.Find("IngameManager").GetComponent<Ingame>().living = false;
            coll.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("gameover");
            GameObject.Find("Player").GetComponent<Animator>().SetBool("isDead", true);
        }
    }

}
