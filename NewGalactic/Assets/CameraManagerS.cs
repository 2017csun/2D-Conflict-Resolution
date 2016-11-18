using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CameraManagerS : Photon.PunBehaviour {

	public BlurOptimized bo;



	// Use this for initialization
	void Start () {
		bo.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BlurCamera(){
		bo.enabled = true;

	}
}
