using UnityEngine;
using System.Collections;

public  class Player : MonoBehaviour {
    
    private Animator animator;
    private Ingame ingame;

    public float leftDist = 0.0f;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        ingame = GameObject.Find("IngameManager").GetComponent<Ingame>();
    }

    void Update()
    {
        if (leftDist != 0)
        {
            float offset = Mathf.Sign(leftDist) * Time.deltaTime * 10.0f;
            if (Mathf.Abs(offset) > Mathf.Abs(leftDist))
            {
                offset = leftDist;
            }
            this.transform.Translate(Vector2.up * offset);
            leftDist -= offset;
            if (leftDist == 0)
            {
                animator.SetBool("jumpchk", false);
                Ingame.score += 100.0f;
                Ingame.floor += 1;
            }
        }
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

