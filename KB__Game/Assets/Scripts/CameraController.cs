using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 0.2f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    private bool startZoom = false;
    [SerializeField] private new Camera camera;
    void Start()
    {
        zoom = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (startZoom)
        {
            zoom -= zoomMultiplier;
            camera.orthographicSize = Mathf.SmoothDamp(zoom, zoom * zoomMultiplier, ref velocity, smoothTime);
            if (zoom <= 2.5f)
            {
                startZoom = false;
                GameControl.LOAD_COMBAT();
            }
        }
    }

    public void ENCOUNTER_ZOOM()
    {
        startZoom = true;
    }
}
