using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	public GameObject player;
	public Vector3 resetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPlayer(){
		player.transform.position = resetPos;
	}
}
