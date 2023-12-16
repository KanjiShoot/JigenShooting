using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using System;

using F4;
using F3ToF4;

public class CreateDataSet:MonoBehaviour
{
    
    ShootContext _shootContext;

    const int TSUKURI=1;
    const int DAMMY=3;
    const int MADE=0;

    int MAX_FALL=2;
    int MIN_FALL=3;

    private int _waveQty;
    private int _enemyQty;

    public void Start()
    {
        F3ToF4.EventManager.HandleDataReady += HandleDataReady;

    }
    public void HandleDataReady(ShootContext shootContext){
        /*
        F4のsuperListを作成するためのプログラム*/

        //マジックナンバー回避
        int WAVE_QTY=4;
        int ENEMY_QTY=5;
        int ORDER_METHOD=6;


        _waveQty=int.Parse(shootContext.StageInfo[WAVE_QTY]);
        _enemyQty=int.Parse(shootContext.StageInfo[ENEMY_QTY]);


        F4.EventManager.SetWaveQty.Invoke(_waveQty);
        F4.EventManager.SetEnemyQty.Invoke(_enemyQty);

        _shootContext=shootContext;

        for(int i=0;i<_waveQty;i++){
            CreateWaveList(i);
        }
    }

    void CreateWaveList(int currentWaveQty){
        /*
        superListの1配列を作る*/
        List<object[]> waveList=new List<object[]>();

        var rand = new System.Random();
        HashSet<int> usedNumbers = new HashSet<int>(); //
 
        string tsukuri=_shootContext.EnemyInfo[currentWaveQty+1][TSUKURI];
        int correctEnemyQty=tsukuri.Length;
        int enemyAll=_enemyQty+correctEnemyQty;

        for(int i=0;i<enemyAll;i++){
            object[] enemyArray=new object[5];

            int randInt;
            do
            {
                randInt = rand.Next(enemyAll); // 0からenemyAll-1までのランダムな整数を生成
            }
            while (usedNumbers.Contains(randInt)); // 既に使用された整数なら再生成
            usedNumbers.Add(randInt);

            enemyArray=CreateEnemyArray(currentWaveQty+1,i,correctEnemyQty,randInt);
            waveList.Add(enemyArray);
        }
        
        F4.EventManager.AddWaveList?.Invoke(waveList);
    }

    private object[] CreateEnemyArray(int currentWaveQty,int currentEnemyQty,int correctEnemyQty,int randInt){
        /*enemy1つのデータ配列を作るためのメソッド
        引数は残りの問題数,1waveの中の番目,waveが含む正解のenemy数
        */
        object[] enemyArray=new object[5];
        string enemyText;
        string madeText;
        float fallSpeed;

        float maxFall=float.Parse(_shootContext.StageInfo[MAX_FALL]);
        float minFall=float.Parse(_shootContext.StageInfo[MIN_FALL]);

        fallSpeed=CreateFallSpeed(maxFall,minFall);

        Vector3 location;
        location=SettleLocation(_enemyQty+correctEnemyQty,currentEnemyQty,randInt);

        //まずは参照するenemyが旁なのかダミー1or2なのかを調べる
        if(correctEnemyQty==1){
            if(currentEnemyQty==0){
                enemyText=_shootContext.EnemyInfo[currentWaveQty][TSUKURI];
                madeText=_shootContext.EnemyInfo[currentWaveQty][MADE];

                enemyArray[0]=enemyText;
                enemyArray[1]=madeText;
                enemyArray[2]=true;
                enemyArray[3]=fallSpeed;
                enemyArray[4]=location;

            }else{
                enemyText=_shootContext.EnemyInfo[currentWaveQty][DAMMY+currentEnemyQty-1];//CSVからダミーの場所を特定
                madeText=null;

                enemyArray[0]=enemyText;
                enemyArray[1]=madeText;
                enemyArray[2]=false;
                enemyArray[3]=fallSpeed;
                enemyArray[4]=location;
                
            }
        }//正解の数が複数だったときの場合分けはまた後で
        return enemyArray;
    }

    
    private Vector3 SettleLocation(int enemyAllQty,int enemyCount,int randInt){
        /*enemyの配置場所を決めるメソッド
        引数は正解を含めたwave中のenemyの数、wave中のenemyの番目
        戻り値は配置場所
        */
        float posX=105;
        float posY=180;

        Vector3 location =new Vector3(posX,posY,0);

        if(enemyAllQty==3){
            switch(randInt){
                case 0:
                    break;
                case 1:
                    location.x=-posX;
                    break;
                case 2:
                    location.x=0;
                    break;
            }
        }
        return location;
    }
    private float CreateFallSpeed(float maxFall,float minFall){
        return UnityEngine.Random.Range(minFall,maxFall);
    }
}
