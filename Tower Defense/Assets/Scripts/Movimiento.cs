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
    int layer;
    public Combate combateScript;

    // Start is called before the first frame update
    void Start()
    {
        combateScript = gameObject.GetComponent<Combate>();
        _rb = GetComponent<Rigidbody>();
        animacion = GetComponent<Animator>();
        andando = true;
        if (gameObject.layer == 9)
        {
            layer = 9;
        }
        else
        {
            layer = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+1,transform.position.z) , transform.TransformDirection(Vector3.forward), Color.white);
        colisiona =Physics.Raycast(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 1);
        if (!colisiona)
        {
            if(!andando){
                animacion.SetTrigger("Andar");
                animacion.SetInteger("Idle", -1);
            }
            andando = true;
            _rb.velocity = transform.forward * velocidad;
            Debug.Log("Nochoco ");
        }
        else
        {
            if (hit.transform.gameObject.layer == layer)
            {
                //if (!combateScript.atacando){
                Debug.Log("Sichoco " + hit.transform.gameObject.name, hit.transform.gameObject);
                int idleRandom;
                idleRandom = (int)Random.Range(0f, 4f);
                if (andando)
                {
                    animacion.SetInteger("Idle", idleRandom);
                }
                    
                //}
                andando = false;
            }
            else
            {
                Debug.Log("choco pero no mi layer");
            }
            _rb.velocity = Vector3.zero;
        }
    }
}
