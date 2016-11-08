using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {
	public GUIText plscotex;
	public GUIText enscotex;
	public static bool bounds;
	public static int plscore;
	public static int enscore;
	public static int mode;//0 練習 1簡単2難しい
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 95;
		plscore = 0;
		enscore = 0;
		bounds = true;
		mode = 2;
	}

	
	// Update is called once per frame
	void Update () {
		plscotex.text =plscore.ToString ();
		enscotex.text = enscore.ToString ();
	}
}
