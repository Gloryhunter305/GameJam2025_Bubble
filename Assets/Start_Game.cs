using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
