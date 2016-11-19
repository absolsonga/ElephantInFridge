using UnityEngine;
using System.Collections;

public  class Player : MonoBehaviour {
    
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            animator.SetBool("jumpchk", false);
        }

    }
}

