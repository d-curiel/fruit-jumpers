using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStageFinished : MonoBehaviour
{
    [Header("Stage")]
    [SerializeField] private int _level;

    [Header("Components")]
    [SerializeField] CollectedWatcherComponent _collectablesWatcher;
    public void UpdateStageStatus()
    {
        int stageState = PlayerPrefs.GetInt("Stage" + _level);
        PlayerPrefs.SetInt("Stage" + _level, CalculateStageStatus(stageState, _collectablesWatcher.IsAllCollectablesCollected()));
    }

    private int CalculateStageStatus(int status, bool completed)
    {
        if(status == 2 || completed)
        {
            return status;
        }
        return 1;
    }
}
