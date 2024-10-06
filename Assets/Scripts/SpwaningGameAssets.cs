using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningGameAssets : MonoBehaviour
{
    public List<GameObject> _gameObjects;
    int RandomEnemy;
    public GameObject boos;
    public bool _Stop = false;

    public Vector3 _SpawnValue;
    public float _SpawnWait;
    public float _SpawnMost;
    public float _SpawnLeastWait;
    public int _StartsWait;


    [SerializeField] ScoreManager scoremanager;

    private void Start()
    {
        StartCoroutine(waitSpawner());
        var scoremanager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {

        _SpawnWait = Random.Range(_SpawnLeastWait, _SpawnMost);

        if (_gameObjects.Count != 4)
        {
            if (scoremanager.diffeclty == 3)
            {
                _gameObjects.Add(boos);
            }
            else
            {
                return;
            }
        }
        if (scoremanager.diffeclty != 31)
        {
            if (scoremanager.diffeclty == 30)
            {
                _SpawnWait = 3;
                _SpawnMost = 3;
                _SpawnLeastWait = 1;
            }
            else
            {
                return;
            }
        }
    }

    public IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(_StartsWait);

        while (!_Stop)
        {
            RandomEnemy = Random.Range(0, _gameObjects.Count);
            Vector3 spwanPos = new Vector3(Random.Range(-_SpawnValue.x, _SpawnValue.x), _SpawnValue.y, Random.Range(-_SpawnValue.z, _SpawnValue.z));
            Instantiate(_gameObjects[RandomEnemy], spwanPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(_SpawnWait);
        }

    }
}
