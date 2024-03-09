using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.2f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPosition;
        }
    }
}
