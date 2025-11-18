using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    
    void Start()
    {
        // find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to push the mouse into 3D
        // If this line causes a nullReferenceException, select the Main Camera
        // in the hierarchy and set its tag to MainCamera in the Inspector
        mousePos2D.z = -Camera.main.transform.position.z;

        // convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }

    void OnCollisionEnter(Collision coll)
    {
        //find out what hit this basket
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);

            // increase the score
            scoreCounter.score += 100;

            HighScore.TRY_SET_HIGH_SCORE( scoreCounter.score );
        }

        else if (collidedWith.CompareTag("GoldenApple"))
        {
            Destroy( collidedWith);

            scoreCounter.score += 200;

            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
