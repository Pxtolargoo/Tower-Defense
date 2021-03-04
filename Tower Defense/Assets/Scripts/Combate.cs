﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    public int ataque;
    public int velocidad;
    public int vida;
    private bool colisiona;
    RaycastHit hit;
    public bool atacando = false;
    Animator animacion;
    int layer;
    bool muriendo = false;
    SpawnUnidades spawner;
    bool rompiendoAtalaya = false;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        if (gameObject.layer == 9)
        {
            layer = 8;
            spawner = GameObject.Find("SpawnPoint").GetComponent<SpawnUnidades>();

        }
        else
        {
            layer = 9;
            spawner = GameObject.Find("SpawnPointIA").GetComponent<SpawnUnidades>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (vida <= 0 && !muriendo)
        {
            spawner.recursos += 5;
            muriendo = true;
            StartCoroutine(Morir());
        }

        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.TransformDirection(Vector3.forward), Color.red);
        colisiona = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 0.01f);
        if (colisiona)
        {
            //if (gameObject.layer!=hit.transform.gameObject.layer)
            //{
            if (hit.transform.name != "Atalaya") {
                if (!atacando && gameObject.layer != hit.transform.gameObject.layer)
                {
                    //Debug.Log("ataca");
                    animacion.SetTrigger("Atacar");
                    animacion.SetInteger("Idle", -1);
                    animacion.speed = velocidad;
                    atacando = true;
                    gameObject.GetComponent<Movimiento>().andando = false;
                    StartCoroutine(Combatir(gameObject, hit.transform.gameObject));
                }
                else
                {
                    
                    //Debug.Log("asd");
                    //Debug.Log(gameObject.layer + " " + hit.transform.gameObject.layer);
                }
                //}
            }
            else
            {
                if (!rompiendoAtalaya)
                {
                    rompiendoAtalaya = true;
                    Debug.Log("ComeDaño");
                    animacion.SetTrigger("Atacar");
                    animacion.SetInteger("Idle", -1);
                    hit.transform.gameObject.GetComponent<Atalaya>().vida -= 50;
                    StartCoroutine(Destruir());
                }
                
            }

        }
        else
        {
            //Debug.Log("wtf");
            atacando = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //    if (collision.gameObject.layer != gameObject.layer)
    //    {
    //        StartCoroutine(Combatir(gameObject, collision.gameObject));
    //        Atacar(gameObject, collision.gameObject);
    //    }
    //}

    public IEnumerator Combatir(GameObject atacante, GameObject defensor)
    {
        while (defensor!=null)
        {
            yield return new WaitForSeconds(2.267f*velocidad);
            Atacar(atacante, defensor);
        }
        
    }

    public void Atacar(GameObject atacante, GameObject defensor) {
        defensor.GetComponent<Combate>().RecibirDmg(ataque);
    }

    public void RecibirDmg(int dmg)
    {
        vida -= dmg;
    }

    IEnumerator Morir()
    {
        animacion.SetTrigger("Morir");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
