using UnityEngine;
using System.Collections;

//	アイテムをリスポーンさせるスクリプト
//	オブジェクトは子ども化する
public class ItemRespawn : MonoBehaviour {

	//	----------------------------------------------------
	//	オブジェクト
	//	----------------------------------------------------
	//	親のオブジェクト
	public GameObject respawnArea;
	public GameObject ItemObject;
	//public GameObject a;
	//	子オブジェクト用の空のオブジェクト
	GameObject instant_Object;

	//	取得用

	private ItemBehavior _item;

	//	----------------------------------------------------
	//	判定とか時間
	//	----------------------------------------------------
	//	アイテム再出現までの時間
	float respawnTime = 1.0f;
	bool Respawn = false;

	// Use this for initialization
	void Start ()
	{
		//_item = ItemObject.GetComponent<ItemBehavior> ();
		//ItemObject = GameObject.Find("Item");
		instant_Object = (GameObject) Instantiate(ItemObject,new Vector2(transform.position.x,transform.position.y), Quaternion.identity);
		//RespawnItems ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void Awake()
	{

	}

	public void StartOn()
	{
		InvokeRepeating ("RespawnItems", respawnTime, respawnTime);
		Respawn = true;
	}

	void RespawnItems()
	{
		if(Respawn)
		{
			instant_Object = (GameObject) Instantiate(ItemObject,new Vector2(transform.position.x,transform.position.y), Quaternion.identity);
			//	子オブジェクトとして生成


			Respawn = false;
		}
	}
}
