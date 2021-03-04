using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atalaya : MonoBehaviour
{
    public int vida=300;
    public string propietario = "IA";
    public MenuController menus;

    public Text vidaT; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vidaT.text = vida.ToString();
        if (vida <= 0)
        {
            StartCoroutine(AbrirReset());
            
        }
    }

    IEnumerator AbrirReset()
    {
        yield return new WaitForSeconds(2);
        menus.LoseOrWin();
    }
}
