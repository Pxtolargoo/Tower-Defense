using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody _rb;
    public bool andando=false;
    public float velocidad=1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        andando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (andando)
        {
            _rb.velocity = transform.forward * velocidad;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        andando = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        andando = true;
    }
}
