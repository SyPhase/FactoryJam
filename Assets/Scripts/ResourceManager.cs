using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [SerializeField] int resourceTotal = 0;

    void Awake()
    {
        Instance = this;

        Resource.OnResourceSelected += AddToResourceTotal;
    }

    void OnDestroy()
    {
        Resource.OnResourceSelected -= AddToResourceTotal;
    }

    public void AddToResourceTotal(int resourceToAdd)
    {
        resourceTotal += resourceToAdd;
    }
}