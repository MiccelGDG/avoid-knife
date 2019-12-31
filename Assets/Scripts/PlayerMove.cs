 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer sr;
    private GameObject _gameObject;
    private Transform _transform;

    private float speed = 3.0f;
    private float xMin = -2.7f;
    private float xMax = 2.7f;
    private int time = 0;

    public Text timerText;


    private void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(CountTime());
    }

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _gameObject = gameObject;
        _transform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void FixedUpdate()
    {
        PlayerBounds();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 temp = _transform.position;

        if(h < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("ToWalk", true);
        }
        else if (h > 0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false ;
            anim.SetBool("ToWalk", true);
        }
        else if(h == 0)
        {
            anim.SetBool("ToWalk", false);
        }

        _transform.position = temp;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1.0f);
        time++;

        timerText.text = "Timer: " + time;

        StartCoroutine(CountTime());
    }

    void PlayerBounds()
    {
        Vector2 temp = _transform.position;

        if(temp.x < xMin)
        {
            temp.x = xMin;
        }
        else if(temp.x > xMax)
        {
            temp.x = xMax;
        }

        _transform.position = temp;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Knife")
        {
            Time.timeScale = 0f;
            StopCoroutine(CountTime());
            StartCoroutine(RestartGame());
        }
    }

}
