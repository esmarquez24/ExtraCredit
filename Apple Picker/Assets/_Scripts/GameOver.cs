using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    public void OnTryAgainButton()
    {
        SceneManager.LoadScene("Scene_0");
    }
}
