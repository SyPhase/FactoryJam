using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public static event Action<int> OnResourceSelected;

    [SerializeField] int resourceValue = 10;

    public void SelectResource()
    {
        OnResourceSelected?.Invoke(resourceValue);
        Destroy(gameObject);
    }


    /*
    public void SelectResource(int resourceAmount)
    {
        ResourceManager.Instance.AddToResourceTotal(resourceAmount);
    }
    */
}