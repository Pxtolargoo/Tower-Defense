using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnidades : MonoBehaviour
{
    public int equipo;
    public GameObject[] unidades;
    //GameObject[] seleccion = new GameObject[] { };
    List<GameObject> seleccion = new List<GameObject>();
    int contSpawn = 0;
    int contCola = 0;
    public int recursos = 10;
    public Text recursosG;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("Spawn");
        if (gameObject.name == "SpawnPointIA")
        {
            StartCoroutine("PruebaDelay");
        }
        StartCoroutine(RescursosPasivos());
    }

    // Update is called once per frame
    void Update()
    {
        recursosG.text = recursos.ToString();
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
        //Debug.Log("Unidad Añadida");
    }

    public IEnumerator RescursosPasivos()
    {
        while (true)
        {
            recursos += 1;
            yield return new WaitForSeconds(3);
        }
    }
    public IEnumerator Spawn()
    {
        GameObject spawned;
        while (true)
        {
            if (contCola > 0 && contSpawn < seleccion.Count)
            {
                //Debug.Log("Unidad Spawneada");
                //Debug.Log("Indice Spwan "+contSpawn);
                //Debug.Log("Longitud Lista " + seleccion.Count);
                spawned=Instantiate(seleccion[contSpawn], transform.position, transform.rotation);
                if (equipo==1)
                {
                    spawned.layer = 8;
                }
                else
                {
                    spawned.layer = 9;
                }
                contSpawn++;
                yield return new WaitForSeconds(2);
            }
            else
            {
                //Debug.Log("Unidad No Spawneada");
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
                if (recursos >= 10)
                {
                    AddToSpawn("PjGrande");
                    recursos -= 10;
                }
                
            }
            else
            {
                if (recursos >= 5)
                {
                    AddToSpawn("PjPequeno");
                    recursos -= 5;
                }
            }
        }
        
    }
}
