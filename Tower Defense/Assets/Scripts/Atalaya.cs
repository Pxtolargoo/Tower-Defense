using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atalaya : MonoBehaviour
{
    public int vida=300;
    public string propietario = "IA";
    public MenuController menus;
    public Text textoResultado;
    public Text vidaT; 

    // Start is called before the first frame update
    void Start()
    {
        if (propietario == "IA")
        {
            vidaT = GameObject.Find("VidaIA").GetComponent<Text>(); 
        }
        else
        {
            vidaT = GameObject.Find("VidaPlayer").GetComponent<Text>();
        }
        textoResultado = GameObject.Find("Resultado").GetComponent<Text>();
        menus = GameObject.Find("CanvasGeneral").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        vidaT.text = vida.ToString();
        if (vida <= 0)
        {
            StartCoroutine(AbrirReset());
            if (gameObject.gameObject.name == "AtalayaIA") {
                textoResultado.text = "¡Victoria!";
            } else {
                textoResultado.text = "Derrota...";
            }
        }
    }

    IEnumerator AbrirReset()
    {
        yield return new WaitForSeconds(2);
        menus.LoseOrWin();
    }
}
