﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnidades : MonoBehaviour
{
    public GameObject[] unidades;
    //GameObject[] seleccion = new GameObject[] { };
    List<GameObject> seleccion = new List<GameObject>();
    int contSpawn = 0;
    int contCola = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
        StartCoroutine("PruebaDelay");
        AddToSpawn("PjGrande");
        AddToSpawn("PjPequeno");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToSpawn(string tipo)
    {
        if (tipo == "PjGrande")
        {
            seleccion.Add(unidades[1]);
        }
        else if(tipo == "PjPequeno")
        {
            seleccion.Add(unidades[0]);
        }
        contCola++;
        Debug.Log("Unidad Añadida");
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            if (contCola > 0 && contSpawn < seleccion.Count)
            {
                Debug.Log("Unidad Spawneada");
                Debug.Log("Indice Spwan "+contSpawn);
                Debug.Log("Longitud Lista " + seleccion.Count);
                Instantiate(seleccion[contSpawn], transform.position, transform.rotation);
                contSpawn++;
                yield return new WaitForSeconds(2);
            }
            else
            {
                Debug.Log("Unidad No Spawneada");
                yield return null;
            }
        }
        
    }

    public IEnumerator PruebaDelay()
    {
        while (true)
        {
            int randomTime=(int)Random.Range(0.0f, 10.0f);
            yield return new WaitForSeconds(randomTime);
            int randomPj=(int)Random.Range(0.0f, 2.0f);
            if (randomPj == 1)
            {
                AddToSpawn("PjGrande");
            }
            else
            {
                AddToSpawn("PjPequeno");
            }
            
        }
        
    }
}
