using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class BridgeShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform bridgeTransform;

    // How long the object should shake for.
    public float shakeDuration = 2.5f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 5f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (bridgeTransform == null)
        {
            bridgeTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = bridgeTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            bridgeTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            bridgeTransform.localPosition = originalPos;
        }
    }

    public void setDuration(float time)
    {
        shakeDuration = time;
    }
}