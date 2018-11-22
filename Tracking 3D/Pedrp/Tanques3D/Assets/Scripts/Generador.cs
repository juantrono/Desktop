using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {

	public Transform generadorBala;
	public GameObject bala;
	public float potencia;
	public string jugador = "";


	void Start () {

	}

	void Update (){
		if (Input.GetButtonDown ("FireTank" + jugador)) {
			Disparar ();
		}
	}

	void Disparar (){
		GameObject balaNueva;
		Rigidbody rbBalaNueva;
		balaNueva = Instantiate (bala, generadorBala.position, generadorBala.rotation);
		rbBalaNueva = balaNueva.GetComponent<Rigidbody>();
		rbBalaNueva.AddForce (balaNueva.transform.forward * potencia);
	}
}
