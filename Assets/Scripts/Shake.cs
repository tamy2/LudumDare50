using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 1f;
    public float shakeRadius = 1f;
    private bool start = false;

    // Update is called once per frame
    void Update()
    {
        if (start) {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere * shakeRadius;
            yield return null;
        }

        transform.position = startPosition;
    }

    public void StartShake() {
        start = true;
    }
}
