using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] Transform _goalPlatform;
    [SerializeField] Transform _bottomPlatform;
    [SerializeField] float[] _precentages;
    [SerializeField] GameObject[] _platformPrefabs;    
    private float _hightOfTower;

    // Start is called before the first frame update
    void Start()
    {
        _hightOfTower = _goalPlatform.localPosition.y - _bottomPlatform.localPosition.y;

        CreatePlatforms();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreatePlatforms()
    {
        float _platformHight = 0.5f;
        for (int i = 0; i < (int)_hightOfTower; i++)
        {
            int randomNumber = Random.Range(0, (int)_hightOfTower);
            Vector3 spawnPosition = new Vector3(_bottomPlatform.localPosition.x, _platformHight, _bottomPlatform.localPosition.z);
            Instantiate(_platformPrefabs[GetRandomPlatform()], spawnPosition, Quaternion.identity, transform);
            _platformHight += 0.6f;
        }
    }

    private int GetRandomPlatform() 
    {
        float random = Random.Range(0f, 1f);
        float numberForAdding = 0;
        float totalPrecentages = 0;
        for (int i = 0; i < _precentages.Length; i++)
        {
            totalPrecentages += _precentages[i];
        }

        for (int i = 0; i < _platformPrefabs.Length; i++)
        {
            if(_precentages[i] / totalPrecentages + numberForAdding >= random)
            {
                return i;
            }
            else
            {
                numberForAdding += _precentages[i] / totalPrecentages;
            }
        }
        return 0;
    }
}
