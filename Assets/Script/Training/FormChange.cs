using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//	プレイヤーの形態を管理するスクリプト
public class FormChange : MonoBehaviour {

	//	アニメーションでキャラクター切り替え

	//	形態
	public bool firstForm = true;
	public bool secondForm = false;
	public bool thirdForm = false;


	//	取得用
	public GameObject PlayerObject;
	private exp _exp;


	// Use this for initialization
	void Start ()
	{
		_exp = PlayerObject.GetComponent<exp> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//	expが貯まったら次のフォルムへ変更

		if(_exp.secondFormAnimation)
		{
			//	セカンドフォルムアニメーションの変数をアニメーションに送り込む
			GetComponent<Animator>().SetBool("Form2",_exp.secondFormAnimation);
			_exp.firstFormAnimation = false;
		}

		if(_exp.thirdFormAnimation)
		{
			GetComponent<Animator>().SetBool("Form3",_exp.thirdFormAnimation);
			_exp.secondFormAnimation = false;
		}

	}

}
