using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    
    void Start()
    {
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        //destroy all of the falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        //destroy one of the baskets
        //get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;

        //get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];

        //remove the Basket form the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);


        //if there are no Baskets left, load Game Over scene
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
