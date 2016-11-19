using UnityEngine;
using System.Collections;

public  class Player : MonoBehaviour {
    
    private Animator animator;
    private Ingame ingame;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        ingame = GameObject.Find("IngameManager").GetComponent<Ingame>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            animator.SetBool("jumpchk", false);
            Ingame.score += 100.0f;
            Ingame.floor += 1;
        }
    }
}

