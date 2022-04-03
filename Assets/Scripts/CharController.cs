using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    //public Transform sprite;
    public Vector3 hiddenPosition;
    public Vector3 shownPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = hiddenPosition;
    }

    public void moveToShownPosition() {
        transform.position = Vector3.MoveTowards(transform.position, shownPosition, speed * Time.deltaTime);
    }

    public void moveToHiddenPosition() {
        transform.position = Vector3.MoveTowards(transform.position, hiddenPosition, speed * Time.deltaTime);
    }
}