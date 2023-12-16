/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using F4;
using Life;
using Result;

public class TextEnemyController : MonoBehaviour
{

	private float _fallSpeed=0;
	private string _textEnemy,_madeText;
	private bool _ifCorrect;
	private TextMeshProUGUI _textEnemyUI;
	private Collider2D collider;
	private Collider enemyCollider;
	private bool ifFall=false;


	public void Initialize(string textEnemy,string madeText,bool ifCorrect,float fallSpeed)
	{
		_textEnemyUI =GetComponent<TextMeshProUGUI>();
		_fallSpeed=fallSpeed*0.005f;
		_ifCorrect=ifCorrect;
		_madeText=madeText;
		_textEnemyUI.text=textEnemy;

		if(ifCorrect){
			F4.EventManager.CorrectEWrong2Delete+=CorrectEWrong2Delete;
		}else{
			F4.EventManager.WrongECorrect2Delete+=WrongECorrect2Delete;
			//EventManager.WrongECrash2Delete+=WrongECrash2Delete;
		}
		F4.EventManager.FallEnd2Delete+=FallEnd2Delete;
	}
	void Start(){
		enemyCollider= GetComponent<Collider>();
	}
	void Update()
	{
		transform.Translate(0, -_fallSpeed, 0, Space.World);
		if (transform.position.y < -5.5f&&ifFall==false)
		{
			StartCoroutine(Fall2Delete());
			ifFall=true;
		}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
		/*
		1,当たったらエフェクトを出す 、fallを止める
		2,made漢字を出す
		3,made漢字を消す
		4,エフェクトを消す
		*/
		Destroy(collider.gameObject);
		Hit();
    }

	void Hit(){

		
		if(_ifCorrect){
			//正解のときの処理
			StartCoroutine(CorrectECorrect2Delete());
		}else{
			//不正解のときの処理
			StartCoroutine(WrongEWrong2Delete());
		}
	}
	IEnumerator CorrectECorrect2Delete(){
		_textEnemyUI.text=_madeText;
		_fallSpeed=0;
		if(ShootGlobal.currentCorrectEnemyQty==1){//正解(CE)が一つの場合
			F4.EventManager.AddResult.Invoke(true);
			F4.EventManager.WrongECorrect2Delete.Invoke();
		}
		if (enemyCollider != null)enemyCollider.enabled = false;//当たり判定を消去する
		F4.EventManager.ReduceCurrentCorrectEnemyQty.Invoke();
		F4.EventManager.ReduceCurrentEnemyQty.Invoke();

		int _waveQty=F4.ShootGlobal.waveQty;
		int _currentWaveQty=F4.ShootGlobal.currentWaveQty;
		Result.ResultGlobal.resultList[1+(_waveQty-_currentWaveQty)][2]=true;//リザルトの書き込み
		Result.ResultGlobal.resultList[1+(_waveQty-_currentWaveQty)][3]=true;

		//エフェクト入れる
		int waitTime=1;
		yield return new WaitForSeconds(waitTime);
		F4.EventManager.ReflectSG.Invoke();
		CorrectEClearManager();
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		Destroy(gameObject);
	}
	IEnumerator WrongEWrong2Delete(){
		//正解を表示してから、ラグを設け、waveを次にする
		_textEnemyUI.text=_madeText;
		_fallSpeed=0;
		F4.EventManager.ReduceCurrentEnemyQty.Invoke();
		Life.EventManager.ReduceLifePoint.Invoke();

		int enemyQty=ShootGlobal.enemyQty;
		int currentEnemyQty=ShootGlobal.currentEnemyQty;
		int currentCorrectEnemyQty=ShootGlobal.currentCorrectEnemyQty;
		int fallQty=ShootGlobal.fallQty;

		int allowMistake=1;//ミスを許す回数、後で変数として外から制御したい
		if((enemyQty-(currentEnemyQty+fallQty-currentCorrectEnemyQty))>allowMistake){
			//ミスを許す回数より、enemyの数が減っているならば、correctEに正解を表示してweveを終える
            F4.EventManager.AddResult.Invoke(false);
            F4.EventManager.CorrectEWrong2Delete.Invoke();
		}
		if (enemyCollider != null)enemyCollider.enabled = false;//当たり判定除去
		//F4.EventManager.ReduceCurrentEnemyQty.Invoke();//wave中のenemyの数を減らす

		int _waveQty=F4.ShootGlobal.waveQty;
		int _currentWaveQty=F4.ShootGlobal.currentWaveQty;
		Result.ResultGlobal.resultList[1+(_waveQty-_currentWaveQty)][2]=true;//リザルトの書き込み
		Result.ResultGlobal.resultList[1+(_waveQty-_currentWaveQty)][3]=false;

		//エフェクト入れる
		int waitTime=1;
		yield return new WaitForSeconds(waitTime);
		F4.EventManager.ReflectSG.Invoke();
		WrongEClearManager();
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		Destroy(gameObject);
	}
	void CorrectEWrong2Delete(){
		StartCoroutine(CorrectEWrong2DeletePri());
	}
	IEnumerator CorrectEWrong2DeletePri(){
		_textEnemyUI.text=_madeText;
		_fallSpeed=0;
		int waitTime=1;
		//エフェクト入れる
		yield return new WaitForSeconds(waitTime);
		F4.EventManager.ReduceCurrentCorrectEnemyQty.Invoke();
		CorrectEClearManager();
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		Destroy(gameObject);
	}
	void WrongECorrect2Delete(){
		StartCoroutine(WrongECorrect2DeletePri());
	}
	IEnumerator WrongECorrect2DeletePri(){
		_textEnemyUI.text=_madeText;
		_fallSpeed=0;
		int waitTime=1;
		//エフェクト入れる
		yield return "null";
		WrongEClearManager();
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		Destroy(gameObject);
	}
	IEnumerator Fall2Delete(){
		_fallSpeed=0;
		int waitTime=1;
		F4.EventManager.AddFallQty.Invoke();//FallQtyの数を増やし、allowMistakeに加算されないようにする
		F4.EventManager.ReduceCurrentEnemyQty.Invoke();//wave中の敵の数を減らす
		Life.EventManager.ReduceLifePoint.Invoke();
		yield return new WaitForSeconds(waitTime);
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		if(ShootGlobal.currentEnemyQty<=0)F4.EventManager.FallEnd2Delete?.Invoke();
		if(_ifCorrect){
			CorrectEClearManager();
		}else{
			WrongEClearManager();
		}
		if(ShootGlobal.currentEnemyQty<=0)F4.EventManager.ReflectSG.Invoke();
		Destroy(gameObject);
	}
	void FallEnd2Delete(){
		F4.EventManager.FallEnd2Delete-=FallEnd2Delete;
		F4.EventManager.ReduceCurrentEnemyQty.Invoke();
		Destroy(gameObject);
	}
	// void WrongECrash2Delete(){
	// 	Destroy(gameObject);
	// }
	private void CorrectEClearManager(){
		F4.EventManager.CorrectEWrong2Delete-=CorrectEWrong2Delete;
	}
	private void WrongEClearManager(){
		F4.EventManager.WrongECorrect2Delete-=WrongECorrect2Delete;
		//EventManager.WrongECrash2Delete-=WrongECrash2Delete;
	}
}