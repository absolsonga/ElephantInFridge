using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Ingame : MonoBehaviour
{

    public GameObject Player;
    public Sprite jump, idle;
    public float speed = 10f;
    public GameObject bg1, bg2;
    private Animator animator;

    public Text highScoreText, scoreText, floorText;

    public static float score = 0.0f;
    public static int floor = 0;
    public bool living = true;

    private Vector3 mousePos;
    private Vector2 touchStartPos;
    private List<bool> touchStarted = new List<bool>();
    private List<float> touchStartTime = new List<float>();
    private const float minSwipeDistancePixels = 100f;
    private const float minSwipeTime = 0.75f;

    BoxCollider2D collider;
    Rigidbody2D rb;
    const float jumpPower = 1175f;


    public void Jump()
    {
        collider.enabled = false;
        rb.AddForce(Vector2.up * jumpPower);
        animator.SetBool("jumpchk", true);
        StartCoroutine(ResetCollision());

    }

    void GoDown()
    {
        collider.enabled = false;
        StartCoroutine(ResetCollision());
    }

    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
        yield break;
    }

    void Start()
    {
        score = floor = 0;
        highScoreText.text = "" + PlayerPrefs.GetFloat("Highscore", 0);
        touchStarted.AddRange(new bool[10]);
        touchStartTime.AddRange(new float[10]);
        animator = Player.GetComponent<Animator>();

        collider = Player.GetComponent<BoxCollider2D>();
        rb = Player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (living)
        {
            score += 100f * Time.deltaTime;
            if (Player.transform.position.y >= 1.5f)
            {
                float offset = Player.transform.position.y - 1.5f;
                Player.transform.Translate(Vector2.down * offset);
                bg1.transform.Translate(Vector2.down * offset);
                bg2.transform.Translate(Vector2.down * offset);
            }

            bg1.transform.Translate(Vector2.down * 6.0f * Time.deltaTime);
            bg2.transform.Translate(Vector2.down * 6.0f * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
                if (animator.GetBool("jumpchk") == false)
                    Jump();
            if (Input.GetKeyDown(KeyCode.DownArrow))
                if (animator.GetBool("jumpchk") == false)
                    GoDown();

            scoreText.text = "" + (int)score;
            floorText.text = "Floor " + floor;
            touchEvent();
        }
        if (Player.transform.position.y <= -9.5f)
        {
            if (score > PlayerPrefs.GetFloat("HighScore", 0))
                PlayerPrefs.SetFloat("Highscore", (int)score);
            SceneManager.LoadScene(2);
        }
    }

    private void touchEvent()
    {
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
                if (animator.GetBool("jumpchk") == false)
                {
                    GoDown();
                    Ingame.floor -= 1;
                }
            }
            else if (angle < 270)
            {
                // left
            }
            else
            {
                // up
                if (animator.GetBool("jumpchk") == false)
                    Jump();

            }
        }
    }


void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            animator.SetBool("jumpchk", false);
        }
        else
        {
            animator.SetBool("jumpchk", true);
        }

    }
}
