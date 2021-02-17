using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject panelHUD;
    public GameObject panelPause;
    void Start()
    {
        panelHUD.SetActive(false);
        panelPause.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);




    }

   

    public void Reanudar()
    {



    }

    public void Salir()
    {



    }

    public void Jugar()
    {



    }

    public void Sound()
    {



    }

    public void Reiniciar()
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
