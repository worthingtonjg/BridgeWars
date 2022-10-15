using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public GameObject cameraTarget;
    public GameObject zoomInTarget;
    public GameObject zoomOutTarget;
    public float  moveSpeed = 25f;

    private bool zooming = false;
    private GameObject zoomTarget;

    // Start is called before the first frame update
    void Start()
    {
        ZoomIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(zooming)
        {
            cameraTarget.transform.position = Vector3.MoveTowards(cameraTarget.transform.position, zoomTarget.transform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(cameraTarget.transform.position, zoomTarget.transform.position) < 0.001f)
            {
                zooming = false;
                cameraTarget.SetActive(false);
            }
        }
    }

    public void ZoomOut()
    {
        cameraTarget.SetActive(true);
        zooming = true;
        zoomTarget = zoomOutTarget;
    }

    public void ZoomIn()
    {
        cameraTarget.SetActive(true);
        zooming = true;
        zoomTarget = zoomInTarget;
    }
}
