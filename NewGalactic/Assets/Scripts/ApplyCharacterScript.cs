using UnityEngine;
using System.Collections;

public class ApplyCharacterScript :  Photon.PunBehaviour {

	public static bool isReadyToNextLevel = false;
	public static bool otherPlayerIsReadyToNextLevel = false;

	// Use this for initialization
	void Start () {
		var sr = gameObject.GetComponentInChildren<SpriteRenderer>();
		//if ((bool)PhotonNetwork.player.customProperties["isp1"] == true) {

		if (sr != null) {
			if (GetComponentInParent<PhotonView> ().owner.isLocal) {
				var color = new Color (
					GameObject.FindObjectOfType<CharManager> ().redChar1,
					GameObject.FindObjectOfType<CharManager> ().greenChar1,
					GameObject.FindObjectOfType<CharManager> ().blueChar1,
					1.0f
				);
				sr.color = color;
			} else {
				var color = new Color (
					GameObject.FindObjectOfType<CharManager> ().redChar2,
					GameObject.FindObjectOfType<CharManager> ().greenChar2,
					GameObject.FindObjectOfType<CharManager> ().blueChar2,
					1.0f
				);
				sr.color = color;
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void ApplyColor(int num){
		var sr = gameObject.GetComponentInChildren<SpriteRenderer>();


		if (GetComponentInParent<PhotonView>().owner.isLocal) {
			var color = new Color (
				GameObject.FindObjectOfType<CharManager>().redChar1,
				GameObject.FindObjectOfType<CharManager>().greenChar1,
				GameObject.FindObjectOfType<CharManager>().blueChar1,
				1.0f
			);
			sr.color = color;
		} else {
			var color = new Color (
				GameObject.FindObjectOfType<CharManager>().redChar2,
				GameObject.FindObjectOfType<CharManager>().greenChar2,
				GameObject.FindObjectOfType<CharManager>().blueChar2,
				1.0f
			);
			sr.color = color;
		}
	}

	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info) {
		CharManager cm = GameObject.FindObjectOfType<CharManager> ();

		if (stream.isWriting) {
			Debug.Log ("WRITING STREAM");

			stream.SendNext (cm == null ? 0f : cm.redChar1);
			stream.SendNext (cm == null ? 0f : cm.greenChar1);
			stream.SendNext (cm == null ? 0f : cm.blueChar1);
			stream.SendNext ((isReadyToNextLevel ? "true" : "false"));
			stream.SendNext (GameObject.FindObjectOfType<ScoringManager> ().resolvedNumRound);
			stream.SendNext (GameObject.FindObjectOfType<ScoringManager> ().unresolvedNumRound);
			if (PhotonNetwork.player != null) {
				if (PhotonNetwork.player.isMasterClient) {
					stream.SendNext (GameObject.FindObjectOfType<GamePlanner> ().intentionOrder[(GameObject.FindObjectOfType<GamePlanner> ().currentRound + 2)% 5] );
					stream.SendNext (GameObject.FindObjectOfType<GamePlanner> ().intentionOrder[(GameObject.FindObjectOfType<GamePlanner> ().currentRound)% 5] );
					stream.SendNext (GameObject.FindObjectOfType<GamePlanner> ().conflictOrder[GameObject.FindObjectOfType<GamePlanner> ().currentRound % 8] );
				} else {
					stream.SendNext (0);
					stream.SendNext (0);
					stream.SendNext (0);
				}
			} else {
				stream.SendNext (0);
				stream.SendNext (0);
			}
			if (GameObject.FindObjectOfType<ScoringManager> () != null) {
				stream.SendNext (GameObject.FindObjectOfType<ScoringManager> ().prosconsCorrectRound);
			} else {
				stream.SendNext (0);
			}
			if (PlayerControl.LocalPlayerInstance.GetComponent<Rigidbody2D> ().velocity.x != 0) {
				stream.SendNext (1);
			} else {
				stream.SendNext (0);
			}
		} else {
			Debug.Log ("READING STREAM");
			if (cm != null) {
				cm.redChar2 = (float)stream.ReceiveNext ();
				cm.greenChar2 = (float)stream.ReceiveNext ();
				cm.blueChar2 = (float)stream.ReceiveNext ();
				otherPlayerIsReadyToNextLevel = (stream.ReceiveNext ().Equals ("true") ? true : false);
				int resolved = (int)stream.ReceiveNext ();
				int unresolved = (int)stream.ReceiveNext ();

				if (resolved > -49000000) {
					GameObject.FindObjectOfType<ScoringManager> ().resolvedNumRound = resolved;
				}
				if (unresolved != -49000000) {
					GameObject.FindObjectOfType<ScoringManager> ().unresolvedNumRound = unresolved;
				}
			} else {
				float temp = (float)stream.ReceiveNext ();
				float temp2 = (float)stream.ReceiveNext ();
				float temp3 = (float)stream.ReceiveNext ();
				otherPlayerIsReadyToNextLevel = (stream.ReceiveNext ().Equals ("true") ? true : false);
				int resolved = (int)stream.ReceiveNext ();
				int unresolved = (int)stream.ReceiveNext ();

				if (resolved > -49000000) {
					GameObject.FindObjectOfType<ScoringManager> ().resolvedNumRound = resolved;
				}
				if (unresolved != -49000000) {
					GameObject.FindObjectOfType<ScoringManager> ().unresolvedNumRound = unresolved;

				}
			}
			if (PhotonNetwork.player != null) {
				if (PhotonNetwork.player.isMasterClient) {
					int temp = (int)stream.ReceiveNext ();
					int temp3 = (int)stream.ReceiveNext ();
					int temp2 = (int)stream.ReceiveNext ();
				} else {
					GameObject.FindObjectOfType<GamePlanner> ().currentIntention = (int)stream.ReceiveNext ();
					GameObject.FindObjectOfType<GamePlanner> ().currentOtherPlayersIntention = (int)stream.ReceiveNext ();
					GameObject.FindObjectOfType<GamePlanner> ().currentConflict = (int)stream.ReceiveNext ();
				}
			} else {
				int temp = (int)stream.ReceiveNext ();
				int temp2 = (int)stream.ReceiveNext ();
			}
			if (GameObject.FindObjectOfType<ScoringManager> () != null) {
				GameObject.FindObjectOfType<ScoringManager> ().prosconsCorrectPartner = (int)stream.ReceiveNext ();
			} else {
				int temp = (int)stream.ReceiveNext ();
			}
			int ismov = (int)stream.ReceiveNext ();
			if (ismov == 1) {
				PlayerControl.nonLocalIsMoving = true;
			} else {
				PlayerControl.nonLocalIsMoving = false;

			}
		}
	}
}
