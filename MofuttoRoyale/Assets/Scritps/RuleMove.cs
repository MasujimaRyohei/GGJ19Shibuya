using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleMove : MonoBehaviour {
	
	[SerializeField] private GameObject RuleImage;
	//[SerializeField] private GameObject ButtonImage;
	[SerializeField] private GameObject btnController;


	float dx = 100.0f;
	float da = 0.1f;
	float ddx = 100.0f;
	float dda = 1f;
	float dxR, zR, rB, gB, bB, aB;
	public bool flag = true;
	public bool rFlag = false;
	public bool removeFlag = false;
	public bool rmFlag = false;

	// Use this for initialization
	void Start () {
		print("RuleMove読み込み");
		dxR = RuleImage.GetComponent<RectTransform> ().localPosition.x;
		zR = RuleImage.GetComponent<RectTransform> ().position.z;
		// rB = ButtonImage.GetComponent<Image> ().color.r;
		// gB = ButtonImage.GetComponent<Image> ().color.g;
		// bB = ButtonImage.GetComponent<Image> ().color.b;
		// aB = ButtonImage.GetComponent<Image> ().color.a;
	}

	// Update is called once per frame
	void Update () {
		if(rFlag == true){
			if (flag == true) {
                btnController.GetComponent<ButtonController>().useFlag = false;
                print (dxR);
				dxR -= dx;
				RuleImage.GetComponent<RectTransform> ().localPosition = new Vector3 (dxR, 0.0f, zR);
				if (dxR <10) {
					dx = 0f;
					flag = false;
				}

			} else if (flag == false) {
				aB += da;
				//ButtonImage.GetComponent<Image> ().color = new Vector4 (rB, gB, bB, aB);
				if (aB > 1) {
					da = 0f;
					removeFlag = true;
				}
			}
			if (removeFlag == true) {
				if (Input.GetKey (KeyCode.Return) || Input.GetButtonDown("Attack1")) {
					rmFlag = true;
				}
			}
			if(rmFlag == true){
				aB -= dda;
				//ButtonImage.GetComponent<Image> ().color = new Vector4 (rB, gB, bB, aB);
				if (aB < 0) {
					dda = 0f;

					dxR += ddx;
					RuleImage.GetComponent<RectTransform> ().localPosition = new Vector3 (dxR, 0.0f, zR);
					if (dxR > 3000) {
						ddx = 0f;
						rmFlag = false;
						rFlag = false;
						removeFlag = false;
						btnController.GetComponent<ButtonController> ().useFlag = true;
						flag = true;
						dx = 100.0f;
						da = 0.1f;
						ddx = 100.0f;
						dda = 1f;

					}
				}
			}

		}
	}		
}