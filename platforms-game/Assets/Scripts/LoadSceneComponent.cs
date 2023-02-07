using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneComponent : MonoBehaviour
{

    [Header("Scene Index")]
    [SerializeField]
    int _sceneBuildIndex;


    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneBuildIndex);
    }
}
