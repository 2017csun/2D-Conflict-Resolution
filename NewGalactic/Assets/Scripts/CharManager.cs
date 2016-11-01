using UnityEngine;
using System.Collections;

public class CharManager : MonoBehaviour {

	public bool isChar1 = false;

	public string nameChar1 = "";
	public string nameChar2 = "";
	public float redChar1 = 0f;
	public float redChar2 = 1f;
	public float greenChar1 = 0f;
	public float greenChar2 = 1f;
	public float blueChar1 = 0f;
	public float blueChar2 = 1f;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
