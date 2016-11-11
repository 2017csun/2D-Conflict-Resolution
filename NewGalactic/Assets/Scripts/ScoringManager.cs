using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ScoringManager : Photon.PunBehaviour {

	public int resolvedNumRound = -49582740;
	public int unresolvedNumRound = -49582740;
	int resolvedNumTeam = 0;
	int unresolvedNumTeam = 0;

	int prosconsCorrectRound = 0;
	int prosconsIncorrectRound = 0;
	int prosconsCorrectTeam = 0;
	int prosconsIncorrectTeam = 0;

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex == 3) {
			prosconsCorrectRound = 0;
			prosconsIncorrectRound = 0;
		}
	}

	public void SetResolvedNum(int num){
		resolvedNumRound = num;
	}

	public void SetUnresolvedNum(int num){
		unresolvedNumRound = num;
	}

	public void SetProsCorrect(int num){
		prosconsCorrectRound += num;
	}

	public void SetProsIncorrect(int num){
		prosconsIncorrectRound += num;
	}

	public void SetConsCorrect(int num){
		prosconsCorrectRound += num;
	}

	public void SetConsIncorrect(int num){
		prosconsIncorrectRound += num;
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
