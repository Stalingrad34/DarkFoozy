using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCloud : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] clouds;
    public float minX;
    public float maxX;
    public float timeSpawn;
    private float time;
    

    void Start()
    {
        Player = GameObject.Find("Player");      
    }
    
    void Update()
    {
        if (Player.transform.position.y > 0)
        {
            time += (Time.deltaTime*Player.transform.position.y);
            if (time > timeSpawn)
            {
                Spawn();
                time = 0;
            }

            
            
        }
        

    }
    void Spawn()
    {      
        Vector2 pos = new Vector2(Random.Range(minX, maxX), 7.5f);
        GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)], pos, Quaternion.identity) as GameObject;
        Destroy(cloud, 10f);
    }
}
