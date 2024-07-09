using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // public GameObject Circle;
    bool moveAllowed;
    Collider2D col;
    
    public GameObject selectionEffect;
    public GameObject deathEffect;

    private GameMaster gm;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {


                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    source.Play();
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            source.Play();
            gm.GameOver();
        }
    }
}