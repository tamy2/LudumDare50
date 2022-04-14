using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public SpriteRenderer overlay;

    // Start is called before the first frame update
    void Start()
    {
        overlay.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        overlay.enabled = !SequencingManager.isGameRunning;
    }
}
