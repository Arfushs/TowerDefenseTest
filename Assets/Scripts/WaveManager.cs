using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static event Action OnWaveStart;
    public static event Action OnWaveComplete;
    public float FirstInterval;

    [SerializeField] private List<Waypoint> _wayPointsList;
    [SerializeField] private List<WaveSO> _waveList;
    [SerializeField] private Transform _enemyContainer;
    
    private WaveSO _currentWave;
    private int _waveIndex =0;

    private void OnEnable()
    {
        OnWaveComplete += SpawnNextWave;
    }

    private void Start()
    {
        SpawnNextWave();
    }

    private void SpawnNextWave()
    {
        StartCoroutine(ManageWave());
    }

    private IEnumerator ManageWave()
    {
        if (_waveIndex ==0)
            yield return new WaitForSeconds(FirstInterval);
        else
            yield return new WaitForSeconds(_currentWave.IntervalAfterWave);
        
        StartCoroutine("SpawnWave");
    }

    private IEnumerator SpawnWave()
    {
        OnWaveStart?.Invoke();
        Debug.Log("Wave "+ _waveIndex + " Started !");
        
        _currentWave = _waveList[_waveIndex];
        _currentWave.SetupConfig();
        int totalEnemyInWave = _currentWave.EnemyCount;
        int enemyLeft = totalEnemyInWave;
        while (enemyLeft >0)
        {
            Enemy enemy = Instantiate(_currentWave.GetNextEnemy(),_enemyContainer);
            enemy.transform.position = _wayPointsList[_currentWave.PathIndex].GetStartPosition();
            enemy.InitializeEnemy(_wayPointsList[_currentWave.PathIndex].GetTransformArray());
            yield return new WaitForSeconds(_currentWave.WaveInterval);
            enemyLeft--;

        }
        
        Debug.Log("Wave "+ _waveIndex + " Finished !");
        _waveIndex++;
        OnWaveComplete?.Invoke();
    }
}
