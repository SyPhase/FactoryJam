using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] float productionTime = 10f;

    [SerializeField] GameObject resourcePrefab;

    [SerializeField] Transform resourceSpawnPosition;

    float currentTime = 0f;

    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime >= productionTime)
        {
            SpawnResource();
            ResetCurrentTime();
        }
    }

    void SpawnResource()
    {
        Instantiate(resourcePrefab, resourceSpawnPosition.position, Quaternion.identity);
    }

    void ResetCurrentTime()
    {
        currentTime = 0;
    }
}