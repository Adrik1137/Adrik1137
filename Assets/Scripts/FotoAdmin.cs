using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FotoAdmin : MonoBehaviour
{
    Camera camara;
    //public CanvasGroup cvGroup;

    /************* Fotos ***************/

    /// <summary>
    /// Las fotos 360 en formato skybox, para su correcta visualización.
    /// </summary>
    public Material[] fotosSkybox;

    /// <summary>
    /// Sirve para mantener control de cual es el canvas actual activo, de manera que podamos desactivarlo al cambiar de foto
    /// </summary>
    int actual = 0;

    /// <summary>
    /// La vista inicial para cada fotografía
    /// </summary>
    public Vector3[] vistaInicial;

    /************* UI ***************/

    /// <summary>
    /// Canvas de cada foto con sus hotspots
    /// </summary>
    public Canvas[] hotspots;

    /// <summary>
	/// Image usada para la transición entre fotos
	/// </summary>
	[Tooltip("Image usada para la transición entre fotos.")]
    public Image FadeImage;

    /// <summary>
	/// Usado para controlar si habrá fade en el cambio o no
	/// </summary>
    [SerializeField]
    [Tooltip("Activar si se quiere que haya transición entre las fotos")]
    bool fade = false;

    /// <summary>
    /// Para visualizar las fotos y elegir en vez de las flechas
    /// </summary>
    [Tooltip("Canvas que contendrá la galería para cambiar por foto")]
    public Canvas galeria;

    public AudioSource musica;

    /************* Métodos ***************/

    // Use this for initialization
    void Start()
    {
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //		Application.targetFrameRate = 30;
      //  if (fade)
      //      StartCoroutine(FadeOut());

        camara.GetComponent<Skybox>().material = fotosSkybox[actual];
    }

    /************* Botones ***************/

    public void Cambiar(bool siguiente)
    {
        //if (fade)
         //   StartCoroutine(FadeIn());

        if (siguiente)
        {
            actual++;
            if (actual >= fotosSkybox.Length) actual = 0;
            camara.GetComponent<Skybox>().material = fotosSkybox[actual];
          //  if (fade)
          //      StartCoroutine(FadeOut());
        }
        else
        {
            actual -= 1;
            if (actual < 0) actual = fotosSkybox.Length -1;
            camara.GetComponent<Skybox>().material = fotosSkybox[actual];
          //  if (fade)
          //      StartCoroutine(FadeOut());
        }
    }

    public void Cambiar(int foto)
    {
        hotspots[actual].gameObject.SetActive(false);
        camara.GetComponent<Skybox>().material = fotosSkybox[foto];
        camara.transform.rotation = Quaternion.Euler(vistaInicial[foto]);
        actual = foto;
        hotspots[actual].gameObject.SetActive(true);
    }

    public void Galeria(bool open)
    {
        if(open)
            galeria.gameObject.SetActive(true);
        else
            galeria.gameObject.SetActive(false);
    }

    public void Mostrar(GameObject Canvas)
    {
        if(Canvas.active == false)
            Canvas.SetActive(true);
        else
            Canvas.SetActive(false);

    }

    public void Music()
    {
        if(musica.isPlaying)
            musica.Pause();
        else
            musica.Play();
    }
    /*

    IEnumerator FadeIn()
    {
        while (cvGroup.alpha < 1)
        {
            cvGroup.alpha += 0.02f;
            yield return null;
        }
        
    }

    IEnumerator FadeOut()
    {
        while (cvGroup.alpha > 0)
        {
            cvGroup.alpha -= 0.02f;
            yield return null;
        }
    }
    */
}
