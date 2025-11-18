using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apple : MonoBehaviour
{
    public static float     bottomY = -20f;

    public int apple = 100;
    public int goldenApple = 200;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            //get a reference to the ApplePicker component on Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            //call the public AppleMissed() method apScript
            apScript.AppleMissed();
        }
    }
}
