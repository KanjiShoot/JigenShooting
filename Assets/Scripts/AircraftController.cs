using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using F4;

namespace AirCraft{
    public class AircraftController : MonoBehaviour
    {
        private Vector2 screenPos;
        [SerializeField] Vector2 prevPos;
        public GameObject bulletPrefab;
        private int frameCount = 0;
        const int LOWER_FRAMECOUNT = 10;
        public void Update()
        {
            screenPos = Input.mousePosition;
            prevPos = Camera.main.ScreenToWorldPoint(screenPos);
            prevPos.y = -4;
            //Debug.Log(screenPos.y);
            if (Input.GetMouseButton(0)) OnClick();//クリックしたとき、場所を移動
            if (Input.GetMouseButtonUp(0)) OnReleased();//離したとき、銃を発射
            frameCount++;

            if (Input.GetKeyDown(KeyCode.RightArrow)) ShowLogs();

        }
        public void OnClick()
        {
        //クリックしているとき、ロケットを移動させる
            if(prevPos.x<=-2f)prevPos.x=-2f;
            if(prevPos.x>=2f)prevPos.x=2f;
            transform.position = prevPos;
            //Debug.Log("Laoded");
        }
        public void OnReleased()
        {
            if(LOWER_FRAMECOUNT <= frameCount ){
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);   
            }
            //離した瞬間に弾を発射する
            Count2Zero();   
        }
        
        void Count2Zero()
        {
            frameCount = 0;
        }

        //ログ確認のために作ったスクリプト
        void ShowLogs(){
            Debug.Log("waveQty: " + ShootGlobal.waveQty);
            Debug.Log("enemyQty: " + ShootGlobal.enemyQty);
            Debug.Log("correctEnemyQty: " + ShootGlobal.correctEnemyQty);
            Debug.Log("currentCorrectEnemyQty: " + ShootGlobal.currentCorrectEnemyQty);
            Debug.Log("currentEnemyQty: " + ShootGlobal.currentEnemyQty);
            Debug.Log("currentWaveQty: " + ShootGlobal.currentWaveQty);
            Debug.Log("ifFall: " + ShootGlobal.ifFall);
            Debug.Log("F4.ShootGlobal.superList.Count:"+F4.ShootGlobal.superList.Count);
        }
    }
}