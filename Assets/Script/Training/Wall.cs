using UnityEngine;
using System.Collections;

//	育成ゲームの壁にあたった時の動作
public class Wall : MonoBehaviour {
	/*

	//	壁にあたった時,その壁のタグの名前で判定する
	//	ぶつかったのがRightWallだったら左へLeftWallだったら右へ,UpWall,DownWallも同等
	//	同等に同時にぶつかった時のことを考えて右上,左下など斜めのも実装する

	//	後々プレイヤースプリクトに変更

	private Move _player;
	public GameObject playerObject;

	// Use this for initialization
	void Start () {
		_player = playerObject.GetComponent<Move> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//	右の壁とぶつかったら
		if(coll.gameObject.tag == "RightWall")
		{
			_player.direction = 3;
		}

		//	左の壁とぶつかったら
		if(coll.gameObject.tag == "LeftWall")
		{
			_player.direction = 2;
		}

		//	上の壁

		//	下の壁

		//	右上

		//	右下

		//	左上

		//	左下

	}

	*/
}
