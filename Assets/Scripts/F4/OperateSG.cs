using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using F4;
public class OperateSG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        EventManager.SetWaveQty+=SetWaveQty;
        EventManager.SetEnemyQty+=SetEnemyQty;
        EventManager.SetCorrectEnemyQty+=SetCorrectEnemyQty;

        EventManager.SetCurrentCorrectEnemyQty+=SetCurrentCorrectEnemyQty;
        EventManager.ReduceCurrentCorrectEnemyQty+=ReduceCurrentCorrectEnemyQty;
        EventManager.SetCurrentEnemyQty+=SetCurrentEnemyQty;
        EventManager.ReduceCurrentEnemyQty+=ReduceCurrentEnemyQty;
        EventManager.SetCurrentWaveQty+=SetCurrentWaveQty;
        EventManager.ReduceCurrentWaveQty+=ReduceCurrentWaveQty;
        EventManager.IfFall2True+=IfFall2True;
        EventManager.IfFall2False+=IfFall2False;
        EventManager.SetFallQty+=SetFallQty;
        EventManager.AddFallQty+=AddFallQty;
        

        //初期化されるときはCurrentの値も初期化される
        //EventManager.SetWaveQty+=SetCurrentWaveQty;

        EventManager.AddWaveList+=AddWaveList;

        EventManager.ReflectSG+=ReflectSG;        
    }
    

    public void SetWaveQty(int waveQty){
        F4.ShootGlobal.waveQty=waveQty;
    }
    public void SetEnemyQty(int enemyQty){
        ShootGlobal.enemyQty=enemyQty;
    }
    public void SetCorrectEnemyQty(int correctEnemyQty){
        ShootGlobal.correctEnemyQty=correctEnemyQty;
    }

    public void SetCurrentCorrectEnemyQty(int currentCorrectEnemyQty){
        ShootGlobal.currentCorrectEnemyQty=currentCorrectEnemyQty;
    }
    public void ReduceCurrentCorrectEnemyQty(){
        ShootGlobal.currentCorrectEnemyQty--;
    }

    public void SetCurrentEnemyQty(int enemyQty){
        ShootGlobal.currentEnemyQty=enemyQty;
    }
    public void ReduceCurrentEnemyQty(){
        ShootGlobal.currentEnemyQty--;
    }

    

    public void SetCurrentWaveQty(int waveQty){
        ShootGlobal.currentWaveQty=waveQty;
    }

    public void ReduceCurrentWaveQty(){
        ShootGlobal.currentWaveQty--;
    }

    public void IfFall2True(){
        ShootGlobal.ifFall=true;
    }

    public void IfFall2False(){
        ShootGlobal.ifFall=false;
    }

    public void AddWaveList(List<object[]> waveList){
        ShootGlobal.superList.Add(waveList);
    }
    public void SetFallQty(){
        ShootGlobal.fallQty=0;
    }
    public void AddFallQty(){
        ShootGlobal.fallQty++;
    }

   
   public void ReflectSG(){
        if(ShootGlobal.currentCorrectEnemyQty<=0 ||ShootGlobal.currentEnemyQty<=0){
                //正解がwave中に残っていないとき
            EventManager.ReduceCurrentWaveQty.Invoke();
            if(ShootGlobal.currentWaveQty==0){
                //問題がすべて終わったとき
                EventManager.EndWave.Invoke();
                EventManager.ChangeStateToF5.Invoke();
            }else{
                //残りのwaveがあったとき
                EventManager.EndWave.Invoke();
                EventManager.IfFall2False.Invoke();
            }
        }else{
            //正解が残っているとき
                
        }
   }

}
