using UnityEngine;
using System.Collections;

public class MovimientoCamara : MonoBehaviour {

	//Rotation Sensitivity
	public float RotationSensitivity = 35.0f;

	//Ángulos mínimos y máximos en Y
	public float minYAngle = -90.0f;
	public float maxYAngle = 90.0f;

	//Ángulos mínimos y máximos en X
	public float minXAngle = -60.0f;
	public float maxXAngle = 60.0f;


	//Valores de la rotación en ambos ejes
	float yRotate = 0.0f;
	float xRotate = 0.0f;

	//Para controlar si se limita la rotación en X o no, es pública para que pueda ser controlada desde CambiarFotoSkybox
	public bool clampX;

	// Update is called once per frame
	void Update () {
		//Si el usuario está dando click
		if (Input.GetMouseButton (0)) {
			//Rotar en Y (rotación horizontal)
			//Obtiene el movimiento del mouse en Y, y luego lo multiplica por la sensibilidad de rotación y el tiempo
			yRotate += Input.GetAxis ("Mouse Y") * RotationSensitivity * Time.deltaTime;
			//Limitamos la rotación a los ángulos mínimos y máximos  (-90 y 90 para que no ponga la imagen al revés)
			yRotate = Mathf.Clamp (yRotate, minYAngle, maxYAngle);

			//Rotar en X (rotación vertical)

			//Obtiene el movimiento del mouse en X, y luego lo multiplica por la sensibilidad de rotación y el tiempo,
			//después por -1 para que el movimiento sea inverso
			xRotate += Input.GetAxis ("Mouse X") * RotationSensitivity * Time.deltaTime * -1;
			//Sí estamos en una de las fotos en las que se limitará el movimiento (donde se ve la estación, para que no se vea en remodelación)
			//limitamos la rotación a los ángulos adecuados.
			if (clampX) {
				xRotate = Mathf.Clamp (xRotate, minXAngle, maxXAngle);


			}

			//Aplicamos la rotación
			transform.eulerAngles = new Vector3 (yRotate, xRotate, 0.0f);
		}
	}
}