using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Tanque : MonoBehaviour {
	Rigidbody rb;
	public string numero = "";

	public float velMov = 20f;
	public float velRotacion = 5f;
	float ejeHor;
	float ejeVer;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		ejeHor = Input.GetAxis ("Horizontal" + numero);
		ejeVer = Input.GetAxis ("Vertical" + numero);

		Debug.Log ("Vertical:" + ejeVer + "Horizontal" + ejeHor);
	}

	void FixedUpdate (){
		Mover ();
		Rotar ();
	}

	void Mover (){
		Vector3 posicionMovimiento = transform.forward * velMov * ejeVer * Time.deltaTime; 
		//Time.deltaTime es para ejecutar la funcion un número fijo de veces dependiendo del pc, el valor de Time.deltaTime irá cambiando para que en todos se ejecute por igual
		rb.MovePosition (transform.position + posicionMovimiento); //En coordenadas del mundo a donde quiero mover el tanque (posición del tanque + la posición del salto hacia adelante)
	}

	void Rotar (){
		float giro = ejeHor * velRotacion * Time.deltaTime;

		Quaternion rotacion = Quaternion.Euler (0f, giro * Mathf.Sign(ejeVer), 0f); //Los parámetros de Quaternion.Euler son los ejes

		rb.MoveRotation (transform.rotation * rotacion);
	}
}
