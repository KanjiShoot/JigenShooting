/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using F4;

public class StateF4StartFall : ShootIState
{
    ShootContext shootContext;
    private int _waveCount;
    private bool _ifFall;
    private bool _endF4=false;
    void StartF4()
    {
        EventManager.ChangeStateToF5+=ChangeStateToF5;
        EventManager.EndWave+=EndWave;
        EventManager.AddResult+=AddResult;
        
    }
    public IEnumerator Handle(ShootContext shootContext){

        this.shootContext=shootContext;
        StartF4();

        for(int _waveCount=1;_waveCount<shootContext.EnemyInfo.Count;_waveCount++){
            _ifFall=true;//enemyの落下状態
            EventManager.IfFall2True.Invoke();
            const int TSUKURI=1;
            int correctEnemyQty=shootContext.EnemyInfo[_waveCount][TSUKURI].Length;
            EventManager.Wave?.Invoke(_waveCount-1,correctEnemyQty);
            while(_ifFall){//enemy落下中は待ち続ける
                yield return null;
                if(_endF4) yield break;
            }
            EventManager.SetCurrentWaveQty(shootContext.EnemyInfo.Count-_waveCount-1);
        }
        while(true){//enemy落下中は待ち続ける
            yield return null;
            if(_endF4) yield break;
        }   
    }
    public void ChangeStateToF5(){
        _endF4=true;
        shootContext.SetState(new StateF5End2Result());
    }

    public void EndWave(){
        _ifFall=false;
        EventManager.IfFall2False.Invoke();
    }

    public void AddResult(bool ifCorrect){
        bool[] _correct = shootContext.Correct;
        _correct = _correct.Concat(new bool[] { ifCorrect }).ToArray();
        shootContext.Correct=_correct;
    }




}
