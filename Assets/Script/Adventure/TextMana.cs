using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using UnityEngine.UI;


public class TextMana : MonoBehaviour {
	
	public bool clear = false;
	
	
	//	画像表示順
	public int Depth = 0;
	
	//	-------------------------------------------
	//	GetComponentとか用
	//	-------------------------------------------
	/// <summary>GUIStyleの宣言</summary>
	//public GUIStyle LabelStyle;

	//	-------------------------------------------
	//	テキスト表示用
	//	-------------------------------------------
	//	文字列を格納する
	private string storage = string.Empty;//currentTextと同じ

	//	なん文字目を追加してるか
	private int currentNum = 0;
	//	String配列
	private int textLine = 0;


	//	-------------------------------------------
	//	テキスト
	//	-------------------------------------------
	//	読み込み
	public TextAsset _text;
	//	uGUIのテキスト機能
	[SerializeField]Text uiText;
	public IEnumerable<string> layoutInfo;
	public IEnumerable<string> LineBreak;
	
	private int insertNum;

	//	--------------------------------
	//	テキストの機能とかの
	//	--------------------------------
	[SerializeField][Range(0.001f,0.3f)]//	バー？
	/// <summary>１文字の表示にかかる時間</summary>
	float intervalForCharacterDisplay = 0.05f;
	/// <summary>表示にかかる時間</summary>
	private float timeUntilDisplay = 0f;
	/// <summary>文字列の表示を開始した時間</summary>
	private float timeElapsed = 1f;
	/// <summary>表示中の文字数</summary>
	private int lastUpdateCharacter = -1;
	//	-------------------------------------------
	//	データ管理
	//	-------------------------------------------
	/// <summary>キャラ名</summary>
	public string characterName;
	/// <summary>キャラグラフィック</summary>
	public string textureId;
	/// <summary>背景</summary>
	public string backgroundName;
	/// <summary>BGM</summary>
	public string backMusic;
	/// <summary>SE</summary>
	public string se;
	/// <summary>セリフ</summary>
	private string useText;
	
	//layoutInfo.elemtnat(textline) == string text[textline]; 


	//	文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText
	{
		get{ return Time.time > timeElapsed + timeUntilDisplay; }
	}

	// Use this for initialization
	void Start()
	{
		this.readText ();
		
		textLine = 0;
		
		currentNum = 0;
		
		insertNum = 0;
		
		var data = layoutInfo.ElementAt(textLine).Split(',');
		characterName = data[0];
		textureId = data[1];
		backgroundName = data[2];
		backMusic = data [3];
		se = data [4];
		//	増えるたびに数字は繰り上がり
		useText = data[5];
		
		textLine++;
	}

	//	テキストの読み込み
	void readText()
	{
		//	ファイルを１行ずつ分割する
		layoutInfo = _text.text.Split ('\n');
	}
	
	// Update is called once per frame
	void Update () {

			NextText ();

		//	クリックから経過した時間が想定表示時間の何％か確認し,表示文字数を出す
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * storage.Length);

		//	表示文字数が前回の表示文字数と異なるならテキストを更新する
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = storage.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		} 
	}


	void NextText()
	{
		//	全文字を表示していたら次の行へ行く
		if(IsCompleteDisplayText)
		{
			if(textLine < storage.Length && Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
			{
				if(useText.Count() <= storage.Count())
				{
					//　次の行の準備
					//	UseTextに１行追加する
					if(textLine < layoutInfo.Count())
					{
						//IEnumerable<string> test = layoutInfo.ElementAt(textLine).Split(',');
						var data = layoutInfo.ElementAt(textLine).Split(',');
						characterName = data[0];
						textureId = data[1];
						backgroundName = data[2];
						backMusic = data[3];
						se = data[4];
						useText = data[5];
					}
					//　表示するTEXTを初期化する
					storage = string.Empty;
					
					//　usetextからstorageに対して追加する文字の番号を初期化
					currentNum = 0;
					insertNum = 0;
					//次に読み込む行を指定
					textLine++;
				}
			}
		}
		else
		{
			//	完了していなかったら全文字を表示する
			if(Input.GetMouseButtonDown(0))
			{
				timeUntilDisplay = 0;
			}
		}

		if(currentNum < useText.Count())
		{
			//　storageに対してusetextから一文字を追加する
			storage += useText[currentNum];

			//	想定表示時間と現在の時刻をキャッシュ
			timeUntilDisplay = storage.Length * intervalForCharacterDisplay;
			timeElapsed = Time.time;

			//　次の文字を追加するための準備
			currentNum++;
			insertNum++;
		}
	}

	
}
