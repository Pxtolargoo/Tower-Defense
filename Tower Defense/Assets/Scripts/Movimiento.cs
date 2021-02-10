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
        colisiona =Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1);
        if (!colisiona)
        {
            andando = true;
            _rb.velocity = transform.forward * velocidad;
        }
        else
        {
            andando = false;
            _rb.velocity = Vector3.zero;
        }
    }

}
