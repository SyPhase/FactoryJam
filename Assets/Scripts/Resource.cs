using System;
using UnityEngine;

public class Resource : MonoBehaviour
{
    // New event, can be subscribed to from anywhere
    public static event Action<int> OnResourceSelected;

    // Variable to set this resource's value (in inspector or through code)
    [SerializeField] int resourceValue = 10;

    // A public function that when called triggers the OnResourceSelected event
    public void SelectResource()
    {
        // Invokes the event
        OnResourceSelected?.Invoke(resourceValue);

        // Removes the resource (could be replaced with object pooling system)
        Destroy(gameObject);
    }

    /* // To set new resourceValue through code
    public void SetResourceValue(int newValue)
    {
        resourceValue = newValue;
    }
     */


    /* // Another way to communicate with the ResourceManager script
    public void SelectResource(int resourceAmount)
    {
        ResourceManager.Instance.AddToResourceTotal(resourceAmount);
    }
    */
}