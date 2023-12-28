using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoad : MonoBehaviour
{
    private const string LOAD_SCENE = "LoadScene";

    private void Start()
    {
        SceneManager.LoadScene(LOAD_SCENE, LoadSceneMode.Additive);
    }
}
