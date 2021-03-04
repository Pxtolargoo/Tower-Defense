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
    public GameObject vidaPlayerG;
    int vidaPlayer;
    public GameObject spawnerPlayer;


    void Start()
    {
        //panelHUD.SetActive(false);
        panelPause.SetActive(false);
        panelJugar.SetActive(false);
        panelReiniciar.SetActive(false);
        panelReanudar.SetActive(false);
    }
    public void LoseOrWin()
    {
        Time.timeScale = 0;
        panelJugar.SetActive(true);
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
        if (spawnerPlayer.GetComponent<SpawnUnidades>().recursos >= 5)
        {
            spawnerPlayer.GetComponent<SpawnUnidades>().recursos -= 5;
            spawnerPlayer.GetComponent<SpawnUnidades>().AddToSpawn("PjPequeno");
        }
    }

    public void Unidad2()
    {
        if (spawnerPlayer.GetComponent<SpawnUnidades>().recursos >= 10)
        {
            spawnerPlayer.GetComponent<SpawnUnidades>().recursos -= 10;
            spawnerPlayer.GetComponent<SpawnUnidades>().AddToSpawn("PjGrande");
        }
       
    }



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
