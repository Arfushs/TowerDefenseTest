using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSO", menuName = "ScriptableObjects/WaveSO")]
public class WaveSO : ScriptableObject
{
    public List<Enemy> EnemyList;
    public List<int> EnemyCountList;
    
    public int EnemyCount { get; private set; }
    
    public int PathIndex;
    public float WaveInterval;
    public float IntervalAfterWave;

    private int _index =0;
    private int _enemyCount;

    public void SetupConfig()
    {
        _index = 0;
        EnemyCount = 0;
        _enemyCount = EnemyCountList[_index];
        
        foreach (var count in EnemyCountList)
        {
            EnemyCount += count;
        }
    }

    public Enemy GetNextEnemy()
    {
        if (_enemyCount <= 0)
        {
            _index++;
            _index = Math.Clamp(_index, 0, EnemyList.Count - 1);
            _enemyCount = EnemyCountList[_index];
        }

        _enemyCount--;
        return EnemyList[_index];
    }


    public float GetTotalWaveTime()
    {
        return WaveInterval * EnemyCount;
    }
}
