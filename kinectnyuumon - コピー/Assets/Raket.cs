using UnityEngine;
using System.Collections;
		
public class Raket : MonoBehaviour {
	float kakudo;
	float power;
	Vector3 pos;
	Vector3 zpos;
	public static bool bhf;
	public static Vector3 movePower;
	GameObject ballp;
	Vector3 sca;
	public bool PtoE;
	public static bool hf;
	GameObject dai;
	Vector3 point;
	Vector3 pointen;
	float si,co,kaku;
	float sa;

	float xsi;
	public GameObject yokoariBase;
	public GameObject yokoari;

	Animator animator;
	AnimatorStateInfo animInfo;
	// Use this for initialization
	void Start () {
		dai = GameObject.Find ("dai");
		point.z = dai.transform.position.z + dai.transform.localScale.z / 4;
		point.x = 0;
		pointen.z = dai.transform.position.z - dai.transform.localScale.z / 4;
		pointen.x = 0;
		ballp = GameObject.Find ("ball");
		sca = transform.localScale*2;
				power = 0;
				pos = Vector3.zero;
				zpos = Vector3.zero;
		movePower = Vector3.zero;
		hf = false;		
		Debug.Log (pointen);
		xsi = 0;
		if (PtoE == false) {
			animator = yokoari.GetComponent<Animator> ();
			animInfo = animator.GetCurrentAnimatorStateInfo (0);


		}
		bhf = false;
	}
			
			// Update is called once per frame
	void Update () {

		pos = transform.position;
		//Debug.Log (xsi + ";" + pos.x + ";" + zpos.x);


		if (PtoE) {

			if (Input.GetKey (KeyCode.W)) {
				pos.z += 0.1f;
			}
			if (Input.GetKey (KeyCode.S)) {
				pos.z += -0.1f;
			}
			if (Input.GetKey (KeyCode.D)) {
				pos.x += 0.1f;
			}
			if (Input.GetKey (KeyCode.A)) {
				pos.x += -0.1f;
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				pos.y += 0.1f;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				pos.y += -0.1f;
			}
		} else {
			if(ballp.transform.position.z > 5) {
				if(ballp.transform.position.x > pos.x+sca.x/2 ){
					pos.x+=0.2f;
				}
				else if(ballp.transform.position.x < pos.x-sca.x/2 ){
					pos.x-=0.2f;
				}
				if(ballp.transform.position.y > pos.y+sca.y/2 ){
					pos.y+=0.2f;
				}
				else if(ballp.transform.position.y < pos.y-sca.y/2 ){
					pos.y-=0.2f;
				}

				if(ballp.transform.position.z > pos.z+sca.z/2 ){
					pos.z+=0.05f;
				}
				else if(ballp.transform.position.z < pos.z-sca.z/2 ){
				pos.z-=0.05f;
				}
			}else {
				if(pos.z < 20)
				pos.z += 0.05f;
			}
			yokoariBase.transform.position = new Vector3(yokoariBase.transform.localScale.x + pos.x,-2,20);
		}
		if (movePower.x > 0) {
			///Debug.Log ("ookii");
			if(pos.x < zpos.x){
				movePower.x = 0;
			}
		}
		else if (movePower.x < 0) {
			//Debug.Log ("tiisai");
			if(pos.x > zpos.x){
				movePower.x = 0;
			}
		}
		if (movePower.y > 0) {
			///Debug.Log ("ookii");
			if(pos.y < zpos.y){
				movePower.y = 0;
			}
		}
		else if (movePower.y < 0) {
			//Debug.Log ("tiisai");
			if(pos.y > zpos.y){
				movePower.y = 0;
			}
		}
		if (movePower.z > 0) {
			///Debug.Log ("ookii");
			if(pos.z < zpos.z){
				movePower.z = 0;
			}
		}
		else if (movePower.z < 0) {
			//Debug.Log ("tiisai");
			if(pos.z > zpos.z){
				movePower.z = 0;
			}
		}
		movePower.x += pos.x - zpos.x;
		movePower.y += pos.y - zpos.y;
		movePower.z += pos.z - zpos.z;

		if (pos.x- 0.05f <  zpos.x && pos.x + 0.05f >  zpos.x && 
		    pos.y- 0.05f <  zpos.y && pos.y + 0.05f >  zpos.y && 
		    pos.z- 0.05f <  zpos.z && pos.z + 0.05f >  zpos.z) {
			if(movePower.x > 0.8f) {
				movePower.x-= 0.5f;
			}else if(movePower.x < -0.8f) {
				movePower.x += 0.5f;
			}else {
				movePower.x = 0;
			}
			if(movePower.y > 0.8f) {
				movePower.y-= 0.5f;
			}else if(movePower.y < -0.8f) {
				movePower.y += 0.5f;
			}else {
				movePower.y = 0;
			}
			if(movePower.z > 0.8f) {
				movePower.z-= 0.5f;
			}else if(movePower.z < -0.8f) {
				movePower.z += 0.5f;
			}else {
				movePower.z = 0;
			}
			//movePower = Vector3.zero;
					//bc.size = new Vector3(2,2,2);
		} else {
			//bc.size = size
		}
		/*if(movePower.x > 0.1f) {
			movePower.x = 0.1f;
		}*/


		if (hit (ballp.transform.position, ballp.transform.localScale)) {
			if (hf==false && GM.bounds == PtoE) {
				bhf = true;
			if(PtoE == false) {
				kaku = Mathf.Atan2 (ballp.transform.position.x - pointen.x , ballp.transform.position.z - pointen.z)
				*180/3.14f+180;
					animator.Play ("s", 0);
			}else {
				kaku = Mathf.Atan2 (ballp.transform.position.x - point.x , ballp.transform.position.z - point.z)
					*180/3.14f+180;

			}
				si = Mathf.Sin(kaku * 3.14f/180);
			co = Mathf.Cos(kaku * 3.14f/180);

			int cnt = 1;
			if(PtoE == false) {

				sa = Mathf.Sqrt((ballp.transform.position.x - pointen.x) *
				                (ballp.transform.position.x - pointen.x)+
				                (ballp.transform.position.z - pointen.z) *
				                (ballp.transform.position.z - pointen.z));

			}else {

				sa = Mathf.Sqrt((ballp.transform.position.x - point.x) *
				                (ballp.transform.position.x - point.x)+
				                (ballp.transform.position.z - point.z) *
				                (ballp.transform.position.z - point.z));

			}

			



				/*if(PtoE) {
				movePower = new Vector3(sa/cnt*co*(movePower.x/0.5f),movePower.y*0.001f+0.1f,sa/cnt*co*(movePower.z/0.5f));
				
				}else {*/


				//if(GM.mode == 0)
				movePower.z = 0.4f;



				Vector3 mP = movePower;

				if(mP.y > -0.3f) {
					mP.y+=1.7f;
				}else {
					mP.y = -1f;
					mP.y-=0.5f;
					mP.z += 0.5f;
				}
				if(mP.y > 4) {
					mP.y = 4;
				}
				if(PtoE) {
					if(mP.y > -0.5f) {
				if(mP.z > 0.39f-(mP.y-1.4f)/15) {
					mP.z = 0.39f-(mP.y-1.4f)/15;
				}else if(mP.z <  0.39f-((mP.y-1.4f)/15)-0.15f) {
					mP.z = 0.39f-((mP.y-1.4f)/15)-0.15f;
				}
					}
				}
				mP.x = mP.x* 0.5f;
				if(mP.x > 0.3f) {
					mP.x = 0.3f;
				}else if(mP.x < -0.3f){
					
					mP.x = -0.3f;
				}

				mP.z *= 0.9f;

				/*mP.z = 0.39f;
				mP.y = 1.4f;
				mP.x = 0;*/



				movePower = mP;

				float boundVectorY = movePower.y*0.001f+0.1f;
				float boundHeight = ballp.transform.position.y;
				float boundGravity = ball.gra;
				if(PtoE == false) {
					boundVectorY= 0.1f;
					
					
				}
				
				while(!( 
				        boundHeight - ballp.transform.localScale.y/2 < dai.transform.position.y + dai.transform.localScale.y/2)) {
					boundHeight += boundVectorY;
					boundVectorY -= 0.001f + boundGravity;
					boundGravity += 0.00008f;
					cnt++;
					//Debug.Log (boundHeight);
				}
				if(PtoE == false) {
					if(GM.mode  == 1) {
						float ran = Random.Range(0,2)*0.1f;
						float ranx = (float)(Random.Range(0,20)-10)/40;
					movePower = new Vector3(ranx,1.4f,0.4f-ran);
					}
					else if(GM.mode == 2) {
						float ran = Random.Range(0,2)*0.1f;
						float ranx = si  + (float)(Random.Range(0,20)-10)/60;
						float y;
						if(ballp.transform.position.y > 5) {
							y = -0.4f;
							ran -= 0.4f;
						}else {
							y = 1.4f + 2.6f;//Random.Range(0,13)/10*2;
							ran += (y-1.4f)/24 + (y - 1.4f) / 18;
						}
						//movePower = new Vector3(ranx,y,0.4f-ran);
						movePower = new Vector3(0,1.4f,0.4f);

					}
				}
				//Debug.Log (movePower);
				if(!PtoE) 
					Debug.Log(movePower);
				if(PtoE)
					movePower = new Vector3(sa/cnt*(movePower.x),movePower.y*0.1f,sa/cnt*(movePower.z/0.4f));
				else
					movePower = new Vector3(movePower.x*sa/cnt,movePower.y*0.1f,-sa/cnt*(movePower.z/0.4f));
					//movePower = new Vector3(si*sa/cnt,0.2f,-sa/cnt*0.75f*(movePower.z/0.4f));
				//}
				float v= ball.vect.z;
				ball.vect = movePower;
				if(movePower.z == 0)
				ball.vect.z += -0.5f*v;
				ball.height = 0;

				//Debug.Log (ball.vect);
				hf = true;
			}
			ball.cnt = 0;
		} else {

		}

		

				//movePower = (int)movePower^(1/3);
				
				

				zpos = transform.position;
	
		transform.position = pos;
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
}

