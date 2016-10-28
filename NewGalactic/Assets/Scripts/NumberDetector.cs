using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberDetector : Photon.PunBehaviour {

	char[] nums = new char[]{'0','1','2','3','4','5','6','7','8','9'};
	public Text fieldText;
	public bool isResolved;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void CheckForNums(){
		string s = GetComponent<InputField> ().text.ToString ();
		Debug.Log ("CHecking string: " + s);
		char[] chars = s.ToCharArray();
		string sNew = "";
		for (int i = 0; i < chars.Length; i++) {
			for (int j = 0; j < nums.Length; j++) {
				if(chars[i] == nums[j]){
					sNew += "" + nums [j];
					break;
				}
			}
		}

		fieldText.text = sNew;
		this.GetComponent<InputField> ().text = sNew;
		if(isResolved){
			GameObject.FindObjectOfType<ScoringManager> ().SetResolvedNum (int.Parse (sNew));
		} else {
			GameObject.FindObjectOfType<ScoringManager> ().SetUnresolvedNum (int.Parse (sNew));

		}
	}
}
