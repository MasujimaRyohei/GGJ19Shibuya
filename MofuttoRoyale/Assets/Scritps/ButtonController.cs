using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class ButtonController : MonoBehaviour {
	bool flag;
	public bool useFlag = true;
	[SerializeField] private GameObject RightButton;
	[SerializeField] private GameObject LeftButton;
	[SerializeField] private GameObject BtnController;
    [SerializeField] private GameObject SceneObj;
	//right get
	//右→flag=true,左→false
	//Enter -> bool ->
	//true -> right.OnClick

	AudioSource _audioSource;
	AudioClip _audioClipCursor;
	AudioClip _audioClipDecision;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (useFlag == true) {
			if(Input.GetKey(KeyCode.RightArrow) ||(Input.GetAxis("Horizontal1") > 0)){
				RightButton.GetComponent<Button>().Select();
                AudioManager.Instance.PlaySE("kettei001");
                flag = true;
			}else if(Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal1") < 0))
            {
                LeftButton.GetComponent<Button>().Select();
                AudioManager.Instance.PlaySE("kettei001");
               flag = false;
			}
			if (Input.GetKey (KeyCode.Return) || Input.GetButtonDown("joystick 1 button 1")) {
				AudioManager.Instance.PlaySE("kettei001");
				onClickButton ();

            }
		}
	}
	
	public void onClickButton(){
		if(flag == true){
			BtnController.GetComponent<RuleMove>().rFlag = true;
		}else if(flag == false){
			useFlag = false;
			SceneManager.LoadScene(GameConfig.SceneName.Main);
        }
	}
}
