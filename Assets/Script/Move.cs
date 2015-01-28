using UnityEngine;
using System.Collections;

//	ランダムで動き回るテスト
public class Move : MonoBehaviour {

	//	ランダムでｘ軸ｙ軸に対して数値を随時追加していって移動させる.
	//	画面の幅を指定して画面からはみ出ないようにする必要がある
	//	壁にあたったら向きを反転する

	//	動く速さの指定
	private float moveSpeed;

	//	ランダムで方向を切り替えるための変数
	[SerializeField]
	public int direction;



	[SerializeField]
	//	タイマー
	private float timer = 4.0f;
	private float addTimer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		characterMove ();
	}

	void characterMove()
	{
		//	移動方向は数秒ごとに切り替え
		//	移動方向のパターンとしては
		//	右,左,上,下,右下,右上,左上,左下
		moveSpeed = Random.Range(0.1f,0.5f);
		addTimer = Random.Range(1.0f,5.0f);

		timer -= Time.deltaTime;
		if(0.0f >= timer)
		{
			//	リセットする
			resetTime();
			timer = addTimer;
		}

		//	現在地の取得
		Vector2 newPosition = transform.position;

		switch(direction)
		{
			//	ステートパターンで切り替え可能とか（リファクタリング時参考）

			//	上
		case 0:
			newPosition.y += moveSpeed * Time.deltaTime;
			break;
			
			//	下
		case 1:
			newPosition.y -= moveSpeed * Time.deltaTime;
			break;
			
			//	右
		case 2:
			newPosition.x += moveSpeed * Time.deltaTime;
			break;
			
			//	左
		case 3:
			newPosition.x -= moveSpeed * Time.deltaTime;
			break;
			
			//	右下
		case 4:
			newPosition.x += moveSpeed * Time.deltaTime;
			newPosition.y -= moveSpeed * Time.deltaTime;
			break;
			
			//	右上
		case 5:
			newPosition.x += moveSpeed * Time.deltaTime;
			newPosition.y += moveSpeed * Time.deltaTime;
			break;
			
			//	左下
		case 6:
			newPosition.x -= moveSpeed * Time.deltaTime;
			newPosition.y -= moveSpeed * Time.deltaTime;
			break;
			
			//	左上
		case 7:
			newPosition.x -= moveSpeed * Time.deltaTime;
			newPosition.y += moveSpeed * Time.deltaTime;
			break;
		}

		//	移動後のポジション７書き換え
		transform.position = newPosition;
	}


	void resetTime()
	{
		//	数秒ごとに移動を変える
		direction = Random.Range (0, 8);
		//direction = null;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//	右の壁とぶつかったら
		if(coll.gameObject.tag == "RightWall")
		{
			direction = 3;
		}
		
		//	左の壁とぶつかったら
		if(coll.gameObject.tag == "LeftWall")
		{
			direction = 2;
		}
		
		//	上の壁
		if(coll.gameObject.tag == "UpWall")
		{
			direction = 1;
		}

		//	下の壁
		if(coll.gameObject.tag == "DownWall")
		{
			direction = 0;
		}

		//	右上
		
		//	右下
		
		//	左上
		
		//	左下
		
	}
}
