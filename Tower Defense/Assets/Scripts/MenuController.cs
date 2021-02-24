using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject panelHUD;
    public GameObject panelPause;
    public GameObject panelJugar;
    public GameObject panelReiniciar;
    public GameObject panelReanudar;

    void Start()
    {
        panelHUD.SetActive(false);
        panelPause.SetActive(false);
        panelJugar.SetActive(true);
        panelReiniciar.SetActive(false);
        panelReanudar.SetActive(false);
    }

    public void Jugar()
    {
        panelJugar.SetActive(false);
        panelHUD.SetActive(true);
    }

    public void HUD()
    {
        panelHUD.SetActive(false);
        panelPause.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);

    }

    public void Reanudar()
    {

        Time.timeScale = 1;
        panelPause.SetActive(false);
        panelHUD.SetActive(true);
    }

    public void Sound()
    {



    }

    public void Reiniciar()
    {
        panelReiniciar.SetActive(false);
        panelHUD.SetActive(true);

    }

    public void Salir()
    {



    }

    public void Unidad1()
    {



    }

    public void Unidad2()
    {



    }



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
