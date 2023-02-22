using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlowComponent : MonoBehaviour
{
    [Header("Objects to activate or deactivate")]
    [SerializeField] GameObject[] _objectsToAffect;

    private void OnEnable()
    {
        Time.timeScale = 0;
        ChangeObjectsState(true);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        ChangeObjectsState(false);
    }

    private void ChangeObjectsState(bool state)
    {
        foreach (GameObject objectToAffect in _objectsToAffect)
        {
            objectToAffect.SetActive(state);
        }
    }
}
