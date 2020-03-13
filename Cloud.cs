using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{   
    public int speed;
    public GameObject Player;

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
        transform.Translate(Vector2.down * speed * Time.deltaTime * (Player.transform.position.y/3));
    }
   

}
