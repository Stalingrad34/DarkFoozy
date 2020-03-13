using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    private bool toLeft;
    private bool toRight;
    public float speed;
    public SpriteRenderer sr;

    void Start()
    {
        
    }


    void Update()
    {
        if (toRight)
        {
            if (transform.position.x <= 3f)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                sr.flipX = false;
            }

        }
        if (toLeft)
        {
            if (transform.position.x >= -3f)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                sr.flipX = true;
            }
        }
    }

    public void MoveToLeft(bool left)
    {
        toLeft = left;
    }

    public void MoveToRight(bool right)
    {
        toRight = right;
    }
}
