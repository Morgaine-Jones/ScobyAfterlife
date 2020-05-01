using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;

    Vector3 pos;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6.0f, 6.0f);
        transform.position = pos;
    }
}
