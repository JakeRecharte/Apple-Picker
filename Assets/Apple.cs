using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public static float bottomY = -20f; // Bottom of the screen

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY){
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
            Destroy(this.gameObject);
        }
    }
}
