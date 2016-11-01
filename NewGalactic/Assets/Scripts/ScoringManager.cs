using UnityEngine;
using System.Collections;

public class ScoringManager : Photon.PunBehaviour {

	public int resolvedNumRound = -49582740;
	public int unresolvedNumRound = -49582740;
	int resolvedNumTeam = 0;
	int unresolvedNumTeam = 0;

	int prosconsCorrectRound = 0;
	int prosconsIncorrectRound = 0;
	int prosconsCorrectTeam = 0;
	int prosconsIncorrectTeam = 0;

	public static ScoringManager instance = null;


	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SetResolvedNum(int num){
		resolvedNumRound = num;
	}

	public void SetUnresolvedNum(int num){
		unresolvedNumRound = num;
	}

	public void SetProsConsCorrect(int num){
		prosconsCorrectRound = num;
	}

	public void SetProsConsIncorrect(int num){
		prosconsIncorrectRound = num;
	}

	public int GetResolvedNumRound(){
		return resolvedNumRound;
	}

	public int GetUnresolvedNumRound(){
		return unresolvedNumRound;
	}

	public int GetProsConsCorrectRound(){
		return prosconsCorrectRound;
	}

	public int GetProsConsIncorrectRound(){
		return prosconsIncorrectRound;
	}

	public int GetResolvedNumTeam(){
		resolvedNumTeam += resolvedNumRound;
		return resolvedNumTeam;
	}

	public int GetUnresolvedNumTeam(){
		unresolvedNumTeam += unresolvedNumRound;
		return unresolvedNumTeam;
	}

	public int GetProsConsCorrectTeam(){
		prosconsCorrectTeam += prosconsCorrectRound;
		return prosconsCorrectTeam;
	}

	public int GetProsConsIncorrectTeam(){
		prosconsIncorrectTeam += prosconsIncorrectRound;
		return prosconsIncorrectTeam;
	}


}
