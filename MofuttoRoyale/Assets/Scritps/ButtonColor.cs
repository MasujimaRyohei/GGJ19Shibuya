using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour {
	public Color normalColor = new Color32(255, 173, 173, 255);
	public Color pressedColor = new Color32(255, 0, 0, 255);
	public Color defColor = new Color32(255, 255, 255, 255);
	public Button startBtn;
	public Button exitBtn;
	ColorBlock startCbBtn;
	ColorBlock exitCbBtn;
	public bool flag;
	public static bool useFlag = false;

	// Use this for initialization
	void Start () {
		startCbBtn = startBtn.colors;
		exitCbBtn = exitBtn.colors;
	}
	
	// Update is called once per frame
	void Update () {
		if(useFlag == true){
			if (Input.GetKey (KeyCode.LeftArrow) || (Input.GetAxis("Horizontal1") < 0)) {
				startCbBtn.normalColor = normalColor;
                
                startBtn.colors = startCbBtn;
				exitCbBtn.normalColor = defColor;
				exitBtn.colors = exitCbBtn;
				flag = true;
			} else if(Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("Horizontal1") > 0))
            {
				startCbBtn.normalColor = defColor;
				startBtn.colors = startCbBtn;
				exitCbBtn.normalColor = normalColor;
				exitBtn.colors = exitCbBtn;
				flag = false;
			}

			if (flag == true) {
				if (Input.GetKey (KeyCode.Return) || Input.GetButtonDown("Attack1")) {
					startCbBtn.normalColor = pressedColor;
					startBtn.colors = startCbBtn;

				}
			} else if(flag ==false) {
				if (Input.GetKey (KeyCode.Return) || Input.GetButtonDown("Attack1")) {
					exitCbBtn.normalColor = pressedColor;
					exitBtn.colors = exitCbBtn;
				}
			}
		}
	}
}
