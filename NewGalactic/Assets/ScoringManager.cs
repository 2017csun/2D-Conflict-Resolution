using UnityEngine;
using System.Collections;

public class ScoringManager : MonoBehaviour {

	int resolvedNum = 0;
	int unresolvedNum = 0;

	int prosconsCorrect = 0;
	int prosconsIncorrect = 0;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetResolvedNum(int num){
		resolvedNum = num;
	}

	public void SetUnresolvedNum(int num){
		unresolvedNum = num;
	}

	public void SetProsConsCorrect(int num){
		prosconsCorrect = num;
	}

	public void SetProsConsIncorrect(int num){
		prosconsIncorrect = num;
	}

	public int GetResolvedNum(){
		return resolvedNum;
	}

	public int GetUnresolvedNum(){
		return unresolvedNum;
	}

	public int GetProsConsCorrect(){
		return prosconsCorrect;
	}

	public int GetProsConsIncorrect(){
		return prosconsIncorrect;
	}


}
