using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public Transform target;
    public Transform fallback;
    public float distance = 15f;
    public float height = 15f;


    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        Debug.Assert(fallback);
    }
    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(fallback.position.x, fallback.position.y, fallback.position.z), 15f * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, fallback.rotation, 60f * Time.deltaTime);
            return;
        }
        transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - distance);
        transform.LookAt(target);

    }
}
