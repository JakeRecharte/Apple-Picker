using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos; 
    }

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple"){
            Destroy(collidedWith);
            scoreCounter.score += 100;
        }
    }

    public void DestroySelf(){
        Destroy(this.gameObject);
    }
}
