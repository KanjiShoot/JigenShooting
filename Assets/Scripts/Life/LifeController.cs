/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using F4;
using Life;
namespace Life{
    public class LifeController : MonoBehaviour
    {
        private int _maxLifePoint;//ライフの最大値
        private int _currentLifePoint;//ライフの現在値
        private int _numberOfObjects;//ライフの個数

        [SerializeField]
        GameObject LifePrefab;
        private List<GameObject> generateLifeOb = new List<GameObject>(); // 生成されたオブジェクトのリスト
        private List<GameObject> generateLifeObFilled= new List<GameObject>();//生成されたオブジェクトの子オブジェクト(filledHeart)
        private List<GameObject> generateLifeObHalf= new List<GameObject>();//生成されたオブジェクトの子オブジェクト(half_Heart)
        private List<GameObject> generateLifeObFrame= new List<GameObject>();//生成されたオブジェクトの子オブジェクト(flame_Heart)



        // Start is called before the first frame update
        void Start()
        {
            _maxLifePoint=LifeGlobal.maxlifePoint;
            _currentLifePoint=_maxLifePoint;
            Life.EventManager.ReduceLifePoint+=ReduceLifePoint;
            SetLife();
        }

        // Update is called once per frame
        void Update()
        {
            if(_currentLifePoint<=0)StartCoroutine(GameOver());
        }
        private IEnumerator GameOver(){
            int waitTime=1;
            F4.EventManager.CorrectEWrong2Delete?.Invoke();
            F4.EventManager.WrongECorrect2Delete?.Invoke();
		    yield return new WaitForSeconds(waitTime);
            F4.EventManager.ChangeStateToF5?.Invoke();
        }
        void ReduceLifePoint(){
            int previousLifePoint=_currentLifePoint;
            _currentLifePoint--;
            StartCoroutine(ReduceLifeUI(previousLifePoint,_currentLifePoint));
            //今は一瞬で減らしてるけど、ライフが減るアクションをここに追加する
        }
        IEnumerator ReduceLifeUI(int previousLifePoint,int currentLifePoint){

            for(int i=0;i<4;i++){
                SetLifeUI(previousLifePoint); 
                yield return new WaitForSeconds(0.3f);
                SetLifeUI(currentLifePoint); 
                yield return new WaitForSeconds(0.3f);
            }

        }

        void SetLife(){
            int filledLife=_maxLifePoint/2;
            int halfLife=_maxLifePoint%2;
            _numberOfObjects=filledLife+halfLife;
            Vector3 vec=new Vector3(1.7f,4.5f,0.0f);
            float dif=0.5f;

            for (int i = 0; i < _numberOfObjects; i++)
            {
                // オブジェクトを生成し、リストに追加
                GameObject generatedObject = Instantiate(LifePrefab, vec, Quaternion.identity);
                generateLifeOb.Add(generatedObject);
                vec.x=vec.x-dif;
                //子オブジェクトをリストに追加
                GameObject generatedObjectHeartFilled=generatedObject.transform.Find("HeartFilled").gameObject;
                GameObject generatedObjectHeartHalf=generatedObject.transform.Find("HeartHalf").gameObject;
                GameObject generatedObjectHeartFrame=generatedObject.transform.Find("HeartFrame").gameObject;

                generateLifeObFilled.Add(generatedObjectHeartFilled);
                generateLifeObHalf.Add(generatedObjectHeartHalf);
                generateLifeObFrame.Add(generatedObjectHeartFrame);

                
            }
            SetLifeUI(_maxLifePoint);

        }
        private void SetLifeUI(int lifePoint){
            int filledLife=lifePoint/2;
            int halfLife=lifePoint%2;
            int frameLife=_numberOfObjects-(filledLife+halfLife);
            for(int i=1;i<=_numberOfObjects;i++){
                if(filledLife>0){
                    generateLifeObFilled[_numberOfObjects-i].SetActive(true);
                    generateLifeObHalf[_numberOfObjects-i].SetActive(false);
                    generateLifeObFrame[_numberOfObjects-i].SetActive(false);

                    filledLife--;
                    continue;
                }else if(halfLife>0){
                    generateLifeObFilled[_numberOfObjects-i].SetActive(false);
                    generateLifeObHalf[_numberOfObjects-i].SetActive(true);
                    generateLifeObFrame[_numberOfObjects-i].SetActive(false);
                    halfLife--;
                    continue;
                }else if(frameLife>0){
                    generateLifeObFilled[_numberOfObjects-i].SetActive(false);
                    generateLifeObHalf[_numberOfObjects-i].SetActive(false);
                    generateLifeObFrame[_numberOfObjects-i].SetActive(true);
                    frameLife--;
                    continue;
                }
            }

        }
    }
}
