using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;


public class LevelManager : Photon.PunBehaviour {

	public Image fadePanel;

	private float fadeSpeed = 1f;
	private Color currentColor = new Color(0f,0f,0f,0f);
	public bool shouldFadeToBlack = false;
	string sceneNameVar;
	private bool thisOneWasTrigger = false;
	private bool breakFade = false;

	public void Start(){
		//DontDestroyOnLoad (this.gameObject);
		PhotonNetwork.automaticallySyncScene = true;
	}

	public void LoadScene(string sceneName)
	{
		this.photonView.RPC("LoadSceneRPC", PhotonTargets.MasterClient, sceneName);
		/*if (PhotonNetwork.isNonMasterClientInRoom) {
			Hashtable someCustomPropertiesToSet = new Hashtable () { { "isp1", "true" } };
			PhotonNetwork.player.SetCustomProperties (someCustomPropertiesToSet);
		} else {
			Hashtable someCustomPropertiesToSet = new Hashtable () { { "isp1", "false" } };
			PhotonNetwork.player.SetCustomProperties (someCustomPropertiesToSet);
		}*/



		/*PhotonPlayer[] players = PhotonNetwork.playerList;
		foreach(PhotonPlayer p in players){
			if (p.isLocal) {
				Hashtable someCustomPropertiesToSet = new Hashtable () { { "isp1", "true" } };
				PhotonNetwork.player.SetCustomProperties (someCustomPropertiesToSet);
			} else {
				Hashtable someCustomPropertiesToSet = new Hashtable () { { "isp1", "false" } };
				PhotonNetwork.player.SetCustomProperties (someCustomPropertiesToSet);
			}
		}*/
		ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
		ApplyCharacterScript.isReadyToNextLevel = false;
	}



	public void ResetGame(){
		LoadScene ("MainMenu");
		//TODO: more logic here when multiple players are involved. 
		// prompt user to confirm, then if they decide to exit, alert the other player.
	}

	[PunRPC]
	public void LoadSceneRPC(string sceneName)
	{
		PhotonNetwork.LoadLevel(sceneName);
	}

	public void CheckForOtherPlayer(string sceneName){
		if (ApplyCharacterScript.isReadyToNextLevel == false) {
			ApplyCharacterScript.isReadyToNextLevel = true;
			GameObject.FindObjectOfType<CameraManagerS> ().BlurCamera ();
		}

		if (ApplyCharacterScript.otherPlayerIsReadyToNextLevel) {
			/*NumberDetector[] dets = GameObject.FindObjectsOfType<NumberDetector> ();
				if (dets != null) {
					foreach (NumberDetector n in dets) {
						n.CheckForNums ();
					}
				}*/

			ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
			ApplyCharacterScript.isReadyToNextLevel = false;

			//LoadScene (sceneName);
			if (fadePanel != null) {
				PhotonView photonView = this.photonView;
				photonView.RPC("FadeToBlack", PhotonTargets.All, sceneName);

				thisOneWasTrigger = true;
				//shouldFadeToBlack = true;
				//fadePanel.gameObject.SetActive (true);
				// sceneNameVar = sceneName;
			} else {
				LoadScene (sceneName);
			}
		} else if (VotingEnable.isMaster && SceneManager.GetActiveScene ().buildIndex == 10) {
			NumberDetector[] dets = GameObject.FindObjectsOfType<NumberDetector> ();
			if (dets != null) {
				foreach (NumberDetector n in dets) {
					n.CheckForNums ();
				}
			}
			ApplyCharacterScript.otherPlayerIsReadyToNextLevel = false;
			ApplyCharacterScript.isReadyToNextLevel = false;
			//LoadScene (sceneName);
			if (fadePanel != null) {
				PhotonView photonView = this.photonView;
				photonView.RPC("FadeToBlack", PhotonTargets.All, sceneName);

				thisOneWasTrigger = true;
				//shouldFadeToBlack = true;
				//fadePanel.gameObject.SetActive (true);
				//sceneNameVar = sceneName;
			} else {
				LoadScene (sceneName);
			}

		}
	}

	[PunRPC]
	public void FadeToBlack(string sceneNameStr){
		shouldFadeToBlack = true;
		fadePanel.gameObject.SetActive (true);
		sceneNameVar = sceneNameStr;
	}

	void Update(){
		if (fadePanel != null && !breakFade) {
			if (shouldFadeToBlack && fadePanel.color.a < .95f) {
				float alphaChange = Time.deltaTime / fadeSpeed;
				currentColor.a += alphaChange;
				fadePanel.color = currentColor;
			} else if (shouldFadeToBlack && PhotonNetwork.player.isMasterClient) {
				//shouldFadeToBlack = false;
				breakFade = true;
				LoadScene (sceneNameVar);
			}
		}
	}

}