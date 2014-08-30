/*************************************************
*	フィールド＆壁生成	
*
*	吉岡広樹
*************************************************/
using UnityEngine;
using System.Collections;

public class CreateField : MonoBehaviour {

	//フィールド
	public GameObject FieldBlue;    
	public GameObject FieldSkyBlue; 
	public Vector3    Field_Position;

	//左壁
	public GameObject LeftWall;
	public Vector3    LeftWallPosition;

	//右壁
	public GameObject RightWall;
	public Vector3	  RightWallPosition;
	
	//GUI
	private bool toggleState;

	//	private bool visibleWindow = false;
	private Rect windowRect = new Rect(5, 5, 250, 100);

	private int nFieldNum;

	/*************************************************
	*	初期化処理	
	*************************************************/
	void Start () {
		nFieldNum = 0;
		Field_Position    = new Vector3(0,0,0);
		LeftWallPosition  = new Vector3(0,0,0);
		RightWallPosition = new Vector3(0,0,0);
	}
	
	
	/*************************************************
	*	更新処理	
	*************************************************/
	void Update () {
	
	}

	/*************************************************
	*	GUI表示	
	*************************************************/
	void OnGUI(){
		
		GUI.BeginGroup(new Rect(0, 100, 255, 300));
		drawGUI();
		GUI.EndGroup();
		
	}

	/*************************************************
	*	GUI描画処理	
	*************************************************/
	private void drawGUI(){
		//Box表示
		GUI.Box(new Rect(5, 30, 250, 400), "3x3FieldTest"); 
		
		//フィールド生成ボタン
		if(GUI.Button(new Rect(10, 60, 100, 30), "Create Field")){
			Debug.Log("Click Button!");

			float StartX,StartY,AnswerY;

			for(int i = 0; i < 3; i++)
			{
				StartY = -0.3f * i;
				for(int j = 0; j < 3; j++)
				{
					//X
					StartX = 0.5f * i;
					StartX += -0.5f * j;

					//Y
					AnswerY = StartY + (-0.3f * j);

					Field_Position = new Vector3(StartX,AnswerY,0);

					if(nFieldNum % 2 == 0)
					{
						Instantiate(FieldBlue, Field_Position,Quaternion.identity);
					}
					else
					{
						Instantiate(FieldSkyBlue, Field_Position,Quaternion.identity);
					}
					nFieldNum++;
				}
			}
			nFieldNum = 0;
		}
		
		//フィールド破棄ボタン
		if (GUI.Button (new Rect (120, 60, 100, 30), "Delete Field")) 
		{
			//タグがプレーンプレファブのもの（ゲーム中に作られたもの）を呼び、動的な配列に入れる
			var ReleseObjPlane = GameObject.FindGameObjectsWithTag("FieldBlue");
			
			//削除処理
			for(int nCount = 0; nCount < ReleseObjPlane.Length; nCount++)
			{
				Destroy(ReleseObjPlane[nCount]);//作った分だけ削除
			}
			
			ReleseObjPlane = GameObject.FindGameObjectsWithTag("FieldSkyBlue");
			//削除処理
			for(int nCount = 0; nCount < ReleseObjPlane.Length; nCount++)
			{
				Destroy(ReleseObjPlane[nCount]);//作った分だけ削除
			}
			
			Field_Position = new Vector3(0,0,0);
			nFieldNum = 0;
		}

		//左壁生成ボタン
		if (GUI.Button (new Rect (10, 100, 100, 30), "Create Wall_Left")) {

			float StartX,StartY,AnswerY;

			for(int i = 0; i < 3; i++){
				StartY  = 0.3f;
				StartY += 0.3f * i;

				for(int j = 0; j < 3; j++){
					StartX  =  -0.25f + ( -0.5f * j);
					AnswerY = StartY + ( -0.3f * j);
					LeftWallPosition = new Vector3(StartX ,AnswerY, 0);

					Instantiate(LeftWall, LeftWallPosition,Quaternion.identity);
				}
			}
		}
		//左壁破棄ボタン
		if (GUI.Button (new Rect (120, 100, 100, 30), "Delete Wall_Left")) {

			//タグがプレーンプレファブのもの（ゲーム中に作られたもの）を呼び、動的な配列に入れる
			var ReleseObjPlane = GameObject.FindGameObjectsWithTag ("Wall_Left");

			//削除処理
			for(int nCount = 0; nCount < ReleseObjPlane.Length; nCount++)
			{
				Destroy(ReleseObjPlane[nCount]);//作った分だけ削除
			}
		}
		//右壁生成ボタン
		if (GUI.Button (new Rect (10, 140, 100, 30), "Create Wall_Right")) {
			
			float StartX,StartY,AnswerY;
			
			for(int i = 0; i < 3; i++){
				StartY  = 0.3f;
				StartY += 0.3f * i;
				
				for(int j = 0; j < 3; j++){
					StartX  =  0.25f + (  0.5f * j);
					AnswerY = StartY + ( -0.3f * j);
					RightWallPosition = new Vector3(StartX ,AnswerY, 0);
					
					Instantiate(RightWall, RightWallPosition,Quaternion.identity);
				}
			}
		}
		//右壁破棄ボタン
		if (GUI.Button (new Rect (120, 140, 100, 30), "Delete Wall_Right")) {
			
			//タグがプレーンプレファブのもの（ゲーム中に作られたもの）を呼び、動的な配列に入れる
			var ReleseObjPlane = GameObject.FindGameObjectsWithTag ("Wall_Right");
			
			//削除処理
			for(int nCount = 0; nCount < ReleseObjPlane.Length; nCount++)
			{
				Destroy(ReleseObjPlane[nCount]);//作った分だけ削除
			}
		}

		//End Appri Button
		if(GUI.Button(new Rect(10, 200, 100, 30), "End Appri")){
			Debug.Log("Click Button!");
			Application.Quit();
		}
	}
}
