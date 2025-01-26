using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry_Game : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
    }
}