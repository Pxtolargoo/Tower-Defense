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
    Animator animacion;


    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
        animacion = GetComponent<Animator>();
        andando = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+1,transform.position.z) , transform.TransformDirection(Vector3.forward), Color.white);
        colisiona =Physics.Raycast(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1);
        if (!colisiona)
        {
            if(andando==false){
                animacion.SetTrigger("Andar");
            }
            andando = true;
            _rb.velocity = transform.forward * velocidad;
            //Debug.Log("choco", hit.transform.gameObject);
        }
        else
        {
            
            andando = false;
            _rb.velocity = Vector3.zero;
        }
    }
}
