using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth; //Should be the blank part between BG images
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; //Grab the midpoint of this objects background collider box
        Debug.Log("StartPosition is " + this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
