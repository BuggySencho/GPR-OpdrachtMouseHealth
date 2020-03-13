using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraListener : MonoBehaviour
{
    private CameraShake shake;

    private void Start()
    {
        shake = GetComponent<CameraShake>();
    }

    public void CallShake(float duration, float magnitude)
    {
        StartCoroutine(shake.Shake(duration, magnitude));
    }
}
