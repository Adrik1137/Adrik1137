using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarFotoScript : MonoBehaviour {

	[Tooltip("La foto a abrir con este botón.")]
	public Transform fotoEsfera;

	[Tooltip("La cámara del juego")]
	public Transform camara;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarFoto(){
		camara.position = fotoEsfera.position;
	}
}
