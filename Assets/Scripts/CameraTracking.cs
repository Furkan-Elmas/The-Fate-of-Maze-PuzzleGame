using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] public Camera camera;
    public Vector3 offset;

    private void Start()
    {
        offset = (- transform.position + camera.transform.position)*0.8f;
    }
    void Update()
    {
        
        camera.transform.position = transform.position + offset;
    }
}
