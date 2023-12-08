using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingText : MonoBehaviour
{
    Transform maincam;
    Transform unit;
    Transform worldSpacecanvas;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        maincam = Camera.main.transform;
        unit = transform.parent;
        worldSpacecanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(worldSpacecanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - maincam.transform.position);
        transform.position = unit.position + offset;
    }
}
