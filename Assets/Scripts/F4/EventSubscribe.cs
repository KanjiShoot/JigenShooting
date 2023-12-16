using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using F4;

namespace F4{
    public class EventSubscribe : MonoBehaviour
    {

        public GameObject TextEnemyPrefab;
        public Canvas canvas;


        public GameObject TargetParticle;
        
        void Start()
        {
            EventManager.Wave +=Wave;
        }
        //データの準備をできるだけしておく

        //問題をランダムにするためのリスト
        
        public void PlaceEnemy(string textEnemy,string madeText,bool ifCorrect,float fallSpeed,Vector3 vector)
	    {
            //textEnemyの漢字、正解か、落ちる速度、場所を与えられて漢字が配置される
            GameObject _textEnemy=Instantiate(TextEnemyPrefab,vector,Quaternion.identity);
            _textEnemy.GetComponent<TextEnemyController>().Initialize(textEnemy,madeText,ifCorrect,fallSpeed);
            _textEnemy.transform.SetParent(canvas.transform, false);
        }
        public void Wave(int count,int correctEnemyQty){

            EventManager.SetCorrectEnemyQty.Invoke(correctEnemyQty);
            EventManager.SetCurrentCorrectEnemyQty.Invoke(correctEnemyQty);
            EventManager.SetCurrentEnemyQty.Invoke(ShootGlobal.enemyQty+correctEnemyQty);
            EventManager.SetCurrentWaveQty.Invoke(ShootGlobal.superList.Count-count);
            EventManager.SetFallQty.Invoke();//落下数を0に戻す

            const int MADE=0;
            const int TSUKURI=1;
            const int READ=2;
            const int DUMMY1=3;
            const int DUMMY2=4;

            for(int i=0;i<ShootGlobal.enemyQty+correctEnemyQty;i++){

                string textEnemy=(string)ShootGlobal.superList[count][i][0];
                string madeText=(string)ShootGlobal.superList[count][i][1];
                bool ifCorrect=(bool)ShootGlobal.superList[count][i][2];
                float fallSpeed =(float)ShootGlobal.superList[count][i][3];
                Vector3 location = new Vector3();
                location =(Vector3)ShootGlobal.superList[count][i][4];

                PlaceEnemy(textEnemy,madeText,ifCorrect,fallSpeed,location);
                

            }
        }

    }
}
