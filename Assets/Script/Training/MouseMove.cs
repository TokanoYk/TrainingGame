using UnityEngine;
using System.Collections;

//	マウスでドロップアンドドロップ
public class MouseMove : MonoBehaviour {

	public bool OnClick = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ClickMouse ();
	}

	private Vector3 screenPoint;
	private Vector3 offset;

	void ClickMouse()
	{
		if(Input.GetMouseButton(0))
		{
			OnClick = true;
		}
		else
		{
			OnClick = false;
		}
	}

	void OnMouseDown()
	{
		this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag()
	{
		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
		transform.position = currentPosition;
	}
}
