using UnityEngine;
using System.Collections;

//	アイテムの挙動
//	アイテムのリスポン→空のオブジェクトを配置してそこからクリエイトする
//	アイテムをドラック,タップしながら移動してプレイヤーに当たったら消去
//	プレイヤーに当たった時に経験値を発生させる

//	アイテムの判定用にマウスカーソル的なのを作る

//	形態によってアイテム画像が替わる

public class ItemBehavior : MonoBehaviour {

	//	アイテムが出現しているかの判定
	//public bool Exist = false;

	public GameObject AriaObject;
	private ItemRespawn _item;

	// Use this for initialization
	void Start () {
		_item = AriaObject.GetComponent<ItemRespawn> ();

		//Exist = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		//	プレイヤーと衝突したら
		if(coll.gameObject.tag == "Player")
		{
			//Exist = false;
			//	指で持っていった場所に移動する
			Invoke("DeleteObject",0.5f);

		}
	}

	/*void OnTriggerStay2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Mouse")
		{

		}
	}*/

	//	オブジェクトを消すだけ
	void DeleteObject()
	{
		Destroy (gameObject);
		_item.StartOn();
	}



}
