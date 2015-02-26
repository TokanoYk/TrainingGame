using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//	アイテムを入手してEXPをGETするたびにEXPゲージを減少させていくスクリプト

public class ExpImage : MonoBehaviour {

	//	１から0.1ずつ引いていく感じ
	//	現状サエのEXPは１００なので１段階１００,２段階２００,３段階３００で引いていく？

	private Image _image;
	public GameObject ImageObject;

	private FormChange _player;
	public GameObject playerObject;

	//bool OnceForm = true;
	bool SecondFormGauge = true;
	bool ThirdFormGauge = true;

	// Use this for initialization
	void Start () {
		_image = ImageObject.GetComponent<Image> ();
		_player = playerObject.GetComponent<FormChange> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	/// <summary>ゲージの減少を管理する関数</summary>
	public void DecreaseGauge()
	{
		_image.fillAmount -= 0.03f;

		//	形態変化したらまたゲージを元に戻す
		if(_player.secondForm)
		{
			if(SecondFormGauge)
			{
				//	ゲージをMAXに戻す
				_image.fillAmount = 1f;
				SecondFormGauge = false;
			}
		}

		if(_player.thirdForm)
		{
			if(ThirdFormGauge)
			{
				_image.fillAmount = 1f;
				ThirdFormGauge = false;
			}
		}

	}

}
