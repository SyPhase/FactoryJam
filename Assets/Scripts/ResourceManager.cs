using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public static event Action<int> OnSelectResource;

    [SerializeField] int resourceTotal = 0;

    void Awake()
    {
        Instance = this;
    }

    public void SelectResource(int resourceAmount)
    {
        OnSelectResource?.Invoke(resourceAmount);
    }

    public void AddToResourceTotal(int resourceToAdd)
    {
        resourceTotal += resourceToAdd;
    }
}