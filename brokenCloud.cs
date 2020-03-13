using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenCloud : MonoBehaviour
{
    
    public GameObject Player;
    private Vector2 moveDown = new Vector2(0, -1);
    public int speed;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Player.transform.position.y > 0)
        {
            MoveCloudDown();
        }
    }
    void MoveCloudDown()
    {
        transform.Translate(moveDown * speed * Time.deltaTime);
    }
    
}
