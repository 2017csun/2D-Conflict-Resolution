using UnityEngine;
using System.Collections;

public class ApplyCharacterScript :  Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
        var sr = gameObject.GetComponentInChildren<SpriteRenderer>();
		//if ((bool)PhotonNetwork.player.customProperties["isp1"] == true) {


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

		if (stream.isWriting) {
			Debug.Log ("WRITING STREAM");

			stream.SendNext (GameObject.FindObjectOfType<CharManager>().redChar1);
			stream.SendNext (GameObject.FindObjectOfType<CharManager>().greenChar1);
			stream.SendNext (GameObject.FindObjectOfType<CharManager>().blueChar1);
		} else {
			Debug.Log ("READING STREAM");
			GameObject.FindObjectOfType<CharManager>().redChar2 = (float) stream.ReceiveNext();
			GameObject.FindObjectOfType<CharManager>().greenChar2 = (float) stream.ReceiveNext();
			GameObject.FindObjectOfType<CharManager>().blueChar2 = (float) stream.ReceiveNext();

		}
	}
}
