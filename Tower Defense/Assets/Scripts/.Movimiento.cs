using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody _rb;
    public bool andando=false;
    public float velocidad=1;
    RaycastHit hit;
    bool colisiona;
    int layerColision;
    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
        andando = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.white);
        if (gameObject.layer == 9)
        {
            layerColision = 8;
        }
        else
        {
            layerColision = 9;
        }
        colisiona =Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1, layerColision);
        if (!colisiona)
        {
            andando = true;
            _rb.velocity = transform.forward * velocidad;
            Debug.Log("choco", hit.transform.gameObject);
        }
        else
        {
            andando = false;
            _rb.velocity = Vector3.zero;
        }
    }

}
