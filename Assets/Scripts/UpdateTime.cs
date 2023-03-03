using UnityEngine;
using TMPro;

public class UpdateTime : MonoBehaviour
{
    [Tooltip("(Canvas) UI timer text")]
    [SerializeField] TMP_Text timeText;

    [SerializeField] Light directionalLight;
    [SerializeField] Transform sunParent;
    [SerializeField] float sunRotationSpeed = 0.01f;

    float gameTime = 0f;

    void Start()
    {
        directionalLight.transform.LookAt(sunParent);
    }

    void FixedUpdate()
    {
        gameTime += Time.fixedDeltaTime;

        UpdateUI();
        RotateDirectionalLight();
    }

    void UpdateUI()
    {
        string temp = gameTime.ToString();
        temp = temp.Substring(0, temp.IndexOf(",")); // sometimes "." or "," because localization bug...

        // TODO : Format timer like 00:00

        timeText.text = temp;
    }

    void RotateDirectionalLight()
    {
        sunParent.Rotate(0f, 0f, sunRotationSpeed);

        float currentSunAngle = sunParent.rotation.eulerAngles.z;
        if (currentSunAngle > 90 && currentSunAngle < 270) // Turn OFF
        {
            print("OFF");
            directionalLight.gameObject.SetActive(false);
        }
        else // Turn ON
        {
            print("ON");
            directionalLight.gameObject.SetActive(true);
        }
    }

    void ResetGameTime()
    {
        gameTime = 0f;
    }
}