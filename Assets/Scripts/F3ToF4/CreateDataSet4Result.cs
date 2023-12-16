using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Result;

public class CreateDataSet4Result : MonoBehaviour
{
    // Start is called before the first frame update
    private int _waveQty;
    private ShootContext _shootContext;
    void Start()
    {
        Result.EventManager.HandleDataReady+=HandleDataReady;
    }
    public void HandleDataReady(ShootContext shootContext){
        _shootContext=shootContext;

        int WAVE_QTY=4;
        _waveQty=shootContext.EnemyInfo.Count;
        for(int i=0;i<_waveQty;i++){
            CreateWaveList(i);
        }
        Result.ResultGlobal.resultList[0][2]=true;
        Result.ResultGlobal.resultList[0][3]=true;
    }
    public void CreateWaveList(int currentWaveQty){

        object[] resultArray=new object[5];

        int MADE=0;
        int MEAN=5;
        int PRON=2;
        string madeText=_shootContext.EnemyInfo[currentWaveQty][MADE];
        string madeMean=_shootContext.EnemyInfo[currentWaveQty][MEAN];
        string madePron=_shootContext.EnemyInfo[currentWaveQty][PRON];

        resultArray[0]=madeText;
        resultArray[1]=madeMean;
        resultArray[2]=false;//madeTextに出会ったかどうか
        resultArray[3]=false;//madeTextに正解したか
        resultArray[4]=madePron;

        Result.ResultGlobal.resultList.Add(resultArray);
        

    }
}
