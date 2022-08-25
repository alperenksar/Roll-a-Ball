using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField] public GameObject _powerPrefab;
    [SerializeField] private Vector3 _spawnPos = new Vector3(0, 0, 6);
    [SerializeField] private float _spawnRange;
    public TextMeshProUGUI _levelText;
    private int _level = 1;



    public int enemyCount;
    public int wavenumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_powerPrefab, GenerateRandomPos(), _powerPrefab.transform.rotation);
        //InvokeRepeating("SpawnPowerUpPrefab", 1f, 15f);
        SpawnWaweEnemy(wavenumber);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        _levelText.text = "LEVEL : " + _level;
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wavenumber++;
            Instantiate(_powerPrefab, GenerateRandomPos(), _powerPrefab.transform.rotation);
            SpawnWaweEnemy(wavenumber);
            _level++;
        }
    }

    Vector3 GenerateRandomPos()
    {
        float _spawnX = Random.Range(-_spawnRange, _spawnRange);
        float _spawnZ = Random.Range(-_spawnRange, _spawnRange);

        Vector3 spawnPos = new Vector3(_spawnX, 0, _spawnZ);
        return spawnPos;
    }

    void SpawnWaweEnemy(int enemywawe)
    {
        for (int i = 0; i < enemywawe; i++)
        {
            Instantiate(_enemyPrefab, GenerateRandomPos(), _enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUpPrefab()
    {
        Instantiate(_powerPrefab, GenerateRandomPos(), _powerPrefab.transform.rotation);
    }
}
