using UnityEngine;
using System.Collections;

//	キャラクターの経験値
//	２形態？
//	１形態目100expで２形態目は200expとかでいいかな

//	プレイヤーにコンポーネントする
//	アイテムにぶつかったらexpをGetするようにする
//	プレイヤーに判定で何の形態なのかという判定をもたせる

public class exp : MonoBehaviour {

	//	手に入れるexp
	public int form1_exp = 3;
	public int form2_exp = 2;
	public int form3_exp = 1;

	//	形態ごとのExpの量
	public int firstMax = 100;
	public int secondMax = 200;
	public int thirdMax = 300;
	

	private FormChange _player;
	public GameObject playerObject;

	private ExpImage _exp;
	public GameObject expObject;

	/// <summary>変身中は動かない</summary>
	//public bool ChangeForm = false;


	// Use this for initialization
	void Start ()
	{
		_player = playerObject.GetComponent<FormChange> ();
		_exp = expObject.GetComponent<ExpImage> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Item")
		{
			//	Expゲットの処理
			GetExp();
			_exp.DecreaseGauge();
		}
	}

	void GetExp()
	{
		if(_player.firstForm)
		{
			//	経験値の引き算
			firstMax -= form1_exp;
			if(firstMax <= 0)
			{
				Debug.Log("Form1Change");
				//	フォルムチェンジの処理
				_player.firstForm = false;
				_player.secondForm = true;

				//	アニメーションで画面真ん中に移動
				//ChangeForm = true;
				//GetComponent<Animator>().SetBool("Form",ChangeForm);
			}
		}

		if(_player.secondForm)
		{
			secondMax -= form2_exp;
			if(secondMax <= 0)
			{
				Debug.Log("Form2Change");
				_player.secondForm = false;
				_player.thirdForm = true;
			}
		}

		if(_player.thirdForm)
		{
			thirdMax -= form3_exp;
			if(thirdMax <= 0)
			{
				Debug.Log("Form3Change");
				_player.thirdForm = false;
			}
		}

	}

	//void FormReset()
	//{
	//	ChangeForm = false;
	//}


}
