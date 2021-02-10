using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    public int ataque;
    public int velocidad;
    public int vida;
    private bool colisiona;
    RaycastHit hit;
    bool atacando = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
        colisiona = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1);
        if (colisiona)
        {
            if (hit.transform.gameObject.layer != gameObject.layer && !atacando)
            {
                atacando = true;
                StartCoroutine(Combatir(gameObject, hit.transform.gameObject));
            }
            
        }
        else
        {
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
            Atacar(atacante, defensor);
            yield return new WaitForSeconds(velocidad);
        }
        
    }

    public void Atacar(GameObject atacante, GameObject defensor) {
        defensor.GetComponent<Combate>().RecibirDmg(ataque);
    }

    public void RecibirDmg(int dmg)
    {
        vida -= dmg;
    }

}
