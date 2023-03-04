using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    // Accessible anywhere, single instance (static)
    public static ResourceManager Instance;

    // Tracks total resources
    [SerializeField] int resourceTotal = 0;

    // Text box to display resource count
    [Tooltip("(Canvas) UI timer text")]
    [SerializeField] TMP_Text resourceText;

    void Awake()
    {
        // Sets this script to be the static instance called Instance or ResourceManager
        Instance = this;

        // Subscribe to the Resource's OnResourceSelected event Action, calls AddToResourceTotal when triggered
        Resource.OnResourceSelected += AddToResourceTotal;
    }

    void OnDestroy()
    {
        // Unsubscribe to event
        Resource.OnResourceSelected -= AddToResourceTotal;
    }

    // Called OnResourceSelected
    public void AddToResourceTotal(int resourceToAdd)
    {
        // Adds to total
        resourceTotal += resourceToAdd;

        // Update UI
        resourceText.text = resourceTotal.ToString();
    }
}