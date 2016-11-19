using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ingame : MonoBehaviour {

    public GameObject Player;
    public Sprite jump, idle;
    public float speed = 10f;
    private Animator animator;

    public Text state;

    private Vector3 mousePos;
    private Vector2 touchStartPos;
    private List<bool> touchStarted = new List<bool>();
    private List<float> touchStartTime = new List<float>();
    private const float minSwipeDistancePixels = 100f;
    private const float minSwipeTime = 0.75f;


    private void Swipe(Touch touch)
    {
        var lastPos = touch.position;
        var distance = Vector2.Distance(lastPos, touchStartPos);

        if (distance > minSwipeDistancePixels)
        {
            float dy = lastPos.y - touchStartPos.y;
            float dx = lastPos.x - touchStartPos.x;

            float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);

            angle = (360 + angle - 45) % 360;

            if (angle < 90)
            {
                // right
            }
            else if (angle < 180)
            {
                // down
                state.text = "다운상태";
            }
            else if (angle < 270)
            {
                // left
            }
            else
            {
                // up
                state.text = "점프상태";
            }
        }
    }

    void Start()
    {
        touchStarted.AddRange(new bool[10]);
        touchStartTime.AddRange(new float[10]);
        animator = Player.GetComponent<Animator>();
    }

	void Update () {

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                var touch = Input.touches[i];

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log(i);
                        touchStarted[i] = true;
                        touchStartTime[i] = Time.time;
                        touchStartPos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        if (touchStarted[i] && Time.time - touchStartTime[i] < minSwipeTime)
                        {
                            Swipe(touch);
                            touchStarted[i] = false;
                        }
                        break;
                    case TouchPhase.Canceled:
                        touchStarted[i] = false;
                        break;
                    case TouchPhase.Stationary:
                        break;
                    case TouchPhase.Moved:
                        break;
                }
            }

        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("runchk", true);
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            if (mousePos.x < 0)
            {
                Player.GetComponent<SpriteRenderer>().flipX = false;
                Player.transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            else if (mousePos.x > 0)
            {
                Player.GetComponent<SpriteRenderer>().flipX = true;
                Player.transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
        }
        else
        {
            animator.SetBool("runchk", false);
        }
	
	}
}
