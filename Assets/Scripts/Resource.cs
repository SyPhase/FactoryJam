using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] int resourceValue = 10;

    void Awake()
    {
        ResourceManager.OnSelectResource += SelectResource;
    }

    void OnDestroy()
    {
        ResourceManager.OnSelectResource -= SelectResource;
    }

    public void SelectResource(int resourceAmount)
    {
        ResourceManager.Instance.AddToResourceTotal(resourceAmount);
    }
}