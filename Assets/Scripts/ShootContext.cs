using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootContext 
{
    private ShootIState _state;
    public  ShootStates CurrentEnumState{get ;set ;}
    public string Stage{get ;private set ;}//target漢字の符号
    public string[] StageInfo{get ; set ;}//target漢字のステージ情報
    public bool[] Correct{get ; set ;}//正解しているかの情報
    public List<string[]> EnemyInfo{get ; set ;}//target漢字符号.csvデータを読み取る
    public ShootContext(ShootIState initialState)
    {
        _state = initialState;

        //今はステージ選択を直接入力している
        Stage="U+065B9";
        EnemyInfo = new List<string[]>();
        CurrentEnumState = ShootStates.F1StageLoad;

    }

    public void SetState(ShootIState state){
        _state=state;
    }
    public IEnumerator Request(){
        return _state.Handle(this);
    }
}
