using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	public static int boundNum;
	public static float height;
	public GUIText text;
	AudioSource audioSource;
	public AudioClip daihansha;
	public AudioClip rakhansha;
	public AudioClip maiSco;
	public AudioClip pluSco;

	GameObject dai;
	GameObject net;
	GameObject raket;

	float x,z;
	Vector3 pos;
	Vector3 sca;
	public static Vector3 vect;
	bool hif;
	public static float gra;
	bool fallf = false;
	bool df = false;
	Vector3 point;
	public static int cnt;
	float tim;
	bool play;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		dai = GameObject.Find ("dai");
		net = GameObject.Find ("net");
		raket = GameObject.Find ("raket");

		tim = 0;
		auto ();

		cnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (play) {
			pos += vect;

			if (pos.x > 15 || pos.x < -15 ||
				pos.z > 25 || pos.z < -15
		    ) {
				auto (true);

			}
			/**/
			/*if (pos.z > 18) {
			vect.z = -0.3f;
			//vect.x = (Random.Range(0,100)-50) * 0.001f;
			vect.y = 0.2f;
			GM.bounds=false;
		}*/
			if (vect == Vector3.zero) {
				auto (true);
			}
			if (height < pos.y) {

			
				height = pos.y;
				/*} else {
				height = 0;
			}*/
			
			} 
			if (pos.y + sca.y / 2 < 0f) {
				if (fallf == false) {
					pos.y = 0f;
					fallf = true;
				}
			}
			if (pos.y + sca.y / 2 < -5) {
				auto (true);

			}

			if (hit (dai.transform.position, dai.transform.localScale)) {
				audioSource.PlayOneShot (daihansha,0.3f);

				Raket.hf = false;

				fallf = false;
				if (hif == false) {
					vect.y = -vect.y / 3.1f;
					height = 0;
					pos.y = dai.transform.position.y + sca.y / 2 + dai.transform.localScale.y / 2 + 0.1f;


					//Debug.Log (height);
					hif = true;
				}
				if (pos.z > dai.transform.position.z) {
					//Debug.Log ("ballcnt:" + cnt + "gra;" + gra);
					if (GM.bounds == false) {
						audioSource.PlayOneShot (pluSco,0.3f);
						GM.plscore ++;
						auto ();
					
					} else {
						GM.bounds = false;
					}
				} else {
				
					if (GM.bounds) {
						audioSource.PlayOneShot (maiSco,0.3f);
						GM.enscore ++;
						auto ();
					
					} else {
						GM.bounds = true;
					}
				}
				gra = 0;
				cnt = 0;
			} else {
				hif = false;
				vect.y -= 0.001f + gra;
				gra += 0.00008f;
				cnt++;
			}
			if (hit (net.transform.position, net.transform.localScale)) {
				vect.x = 0;
				vect.z = 0;
				vect.y = 0;
			}
			if(Raket.bhf) {
				audioSource.PlayOneShot (rakhansha,0.3f);
				Raket.bhf = false;
			}
			//Debug.Log (GM.bounds);
			//Debug.Log (GM.bounds);
			//Debug.Log (GM.bounds);
			//Debug.Log (vect.z);
			transform.position = pos;
		} else {
			if(stopTim()) {
				play = true;
			}
		}
	}
	bool hit(Vector3 p,Vector3 s) {
		bool ret = false;
		if (pos.x + sca.x/2 > p.x - s.x/2 && 
		    pos.x - sca.x/2 < p.x + s.x/2 && 
		    pos.y + sca.y/2 > p.y - s.y/2 && 
		    pos.y - sca.y/2 < p.y + s.y/2 && 
		    pos.z + sca.z/2 > p.z - s.z/2 && 
		    pos.z - sca.z/2 < p.z + s.z/2) {
			ret =true;
		}
		return ret;
	}
	void auto(bool sc = false) {
		//Debug.Log (GM.bounds);
		tim = 0;
		play = false;
		pos = new Vector3(0,4,6);
		vect = new Vector3 (0, 0.3f/2, -0.0375f*2);
		boundNum = 0;
		gra = 0;
		height = 0;

		fallf = false;
		if (sc == true) {
			if(!GM.bounds) {
				audioSource.PlayOneShot (pluSco,0.3f);
				GM.plscore++;
			}else {
				audioSource.PlayOneShot (maiSco,0.3f);
				GM.enscore++;
			}
		}
		GM.bounds = false;
		cnt = 0;
		play = false;
		text.text = "アウト";
		
		//Debug.Log ("a");
	}
	bool stopTim() {
		bool ret = false;
		if (tim > 1) {
			ret = true;
			text.text = "";
		} else {
			tim += Time.deltaTime;

		}
		return ret;
	}
}
