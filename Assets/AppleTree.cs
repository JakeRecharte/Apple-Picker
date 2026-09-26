using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;

    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;

    [Header("Difficulty Ramp")]
    public float treeSpeedRampRate = 0.05f; // fractional speed increase per second
    public float gravityRampRate = 0.2f; // added downward gravity per second


    void Start()
    {
        //Start Dropping Apples
        Invoke ("DropApple", 2f);

        
    }
    void DropApple(){
            GameObject apple  = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;

            Invoke("DropApple", appleDropDelay);
        }

    void Update()
    {
        // Difficulty Ramp: gradually speed up the tree and apple falling
        speed *= 1f + treeSpeedRampRate * Time.deltaTime;
        Physics.gravity += Vector3.down * gravityRampRate * Time.deltaTime;

        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }/*
        else if (Random.value < changeDirChance){
            speed *= -1;
        }*/
    }

    void FixedUpdate(){
        if ( Random.value < changeDirChance ){
            speed *= -1;
        }
    }
}
