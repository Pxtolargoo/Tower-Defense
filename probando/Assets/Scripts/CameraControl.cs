using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float orbitSpeed;

    public float panSpeed;

    public float zoomSpeed;

    Vector3 camaraOriginalpos;
    Quaternion camaraOriginalRotation;


    // Start is called before the first frame update
    void Start()
    {
        if(target!= null) transform.LookAt(target);

        if(target == null) Debug.LogWarning("Cuidado que se te ha olvidado el objetivo");

        camaraOriginalpos = transform.position;
        camaraOriginalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        float zoom = Input.GetAxis("Mouse ScrollWheel");
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");

        // Orbit Camera
        if(Input.GetMouseButton(0)){
            if (target != null) transform.RotateAround(target.position, Vector3.up, mousex * orbitSpeed);
            if (target != null) transform.RotateAround(target.position, transform.right, -mousey* orbitSpeed);
          
        }

        // Pan Camera
        if (Input.GetMouseButton(1))
        {
            Vector3 movimiento = transform.right * -mousex * panSpeed + transform.up * -mousey * panSpeed;
            transform.position += movimiento;

        }
       
        // Zoom Camera
        transform.position += transform.forward * zoom * zoomSpeed;
    }

    public void CentrarObjetivo()
    {
        if (target != null) transform.LookAt(target);
    }

    public void ReseteaCamara()
    {
        transform.position = camaraOriginalpos;
        transform.rotation = camaraOriginalRotation;
    }

}
