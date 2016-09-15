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
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		player.transform.position = resetPos;
	}
}
