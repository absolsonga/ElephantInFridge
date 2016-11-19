using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject[] floors;
    public GameObject[] Enemys;

	// Update is called once per frame
	void Update () {
        if (transform.position.y < -9.7f)
        {
            transform.Translate(Vector2.up * 19.4f);
            for(int i = 0; i<3; i++)
            {
                float random1 = Random.Range(-7.5f,7.5f);
                int random2 = Random.Range(0, 4);
                
                GameObject soju = Instantiate(Enemys[random2]) as GameObject;
                soju.transform.Translate(random1, floors[i].transform.position.y+ 0.7f, 0);
                
                soju.transform.parent = this.transform;

            }
           
        }
	}
}
