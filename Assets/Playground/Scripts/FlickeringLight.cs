using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light lightSource;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;

    private float targetIntensity;

    void Start()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    void Update()
    {
        lightSource.intensity = Mathf.Lerp(lightSource.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

        if (Mathf.Abs(lightSource.intensity - targetIntensity) < 0.01f)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}
