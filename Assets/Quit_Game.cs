using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Game : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadSceneAsync(0);
    }
}