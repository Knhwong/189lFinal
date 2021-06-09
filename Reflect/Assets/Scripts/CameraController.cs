using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private GameObject CameraBounds;
    [SerializeField] private Vector2 Margin;
    [SerializeField] private Vector2 Smoothing;

    private Camera ManagedCamera;
    private Vector3 BoundMin;
    private Vector3 BoundMax;
    private bool IsFollowing;

    private void Start()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.BoundMin = this.CameraBounds.GetComponent<BoxCollider2D>().bounds.min;
        this.BoundMax = this.CameraBounds.GetComponent<BoxCollider2D>().bounds.max;
        this.IsFollowing = true;
    }

    //Use the LateUpdate message to avoid setting the camera's position before
    //GameObject locations are finalized.
    void Update()
    {
        var x = this.ManagedCamera.transform.position.x;
        var y = this.ManagedCamera.transform.position.y;
        var z = this.ManagedCamera.transform.position.z;
        var targetPosition = this.Target.transform.position;

        if (this.IsFollowing)
        {
            if (Mathf.Abs(x - targetPosition.x) > Margin.x)
            {
                x = Mathf.Lerp(x, targetPosition.x, Smoothing.x * Time.deltaTime);
            }

            if (Mathf.Abs(y - targetPosition.y) > Margin.y)
            {
                y = Mathf.Lerp(y, targetPosition.y, Smoothing.y * Time.deltaTime);
            }
        }

        var cameraHalfHeight = this.ManagedCamera.orthographicSize;
        var cameraHalfWidth = cameraHalfHeight * ((float) Screen.width / Screen.height);

        x = Mathf.Clamp(x, BoundMin.x + cameraHalfWidth, BoundMax.x - cameraHalfWidth);
        y = Mathf.Clamp(y, BoundMin.y + cameraHalfHeight, BoundMax.y - cameraHalfHeight);

        this.ManagedCamera.transform.position = new Vector3(x, y, z);
    }
}