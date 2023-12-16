using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using F3;

public class EventSubscribe : MonoBehaviour
{

    public GameObject TextTargetPrefab;
    public GameObject TextTargetPronPrefab;
    private Canvas canvas;


    public GameObject TargetParticle;
    void Start()
    {
        // Canvasを新しいシーンで取得
        canvas = FindObjectOfType<Canvas>();

        EventManager.PlaceTarget += PlaceTargets;
        EventManager.CreateTarget+=CreateTarget;
        EventManager.DeleteTarget+=DeleteTarget;

        EventManager.SpawnAndPlayParticle+=SpawnAndPlayParticle;
        EventManager.DestroyParticle+=DestroyParticle;
    }

    //Target及び読みの配置を行う
    public void PlaceTargets(string target,string pron){


        Vector3 _targetLocation= new Vector3(0,125f,0);
        Vector3 _pronLocation= new Vector3(0,-130f,0);

		GameObject _target=Instantiate(TextTargetPrefab,_targetLocation,Quaternion.identity);
		_target.GetComponent<TextTargetController>().Initialize(target);
        if(canvas==null)Debug.Log("canvas==null");
		_target.transform.SetParent(canvas.transform, false);

        GameObject _targetPron=Instantiate(TextTargetPronPrefab,_pronLocation,Quaternion.identity);
		_targetPron.GetComponent<TextTargetController>().Initialize(pron);
		_targetPron.transform.SetParent(_target.transform, false);

	}

    //ターゲットが存在するか否かの情報を書き換えるメソッド
    public void DeleteTarget(){
        ShootGlobal.targetExist=false;

    }
    public void CreateTarget(){
        ShootGlobal.targetExist=true;
    }

    //パーティクル関係
    public GameObject particlePrefab; // プレハブ化されたParticle Systemを指定するための変数
    private GameObject spawnedParticle; // インスタンス化されたParticle Systemの参照

    public void SpawnAndPlayParticle()
    {
        if (particlePrefab == null) return;

        // プレハブからParticle Systemをインスタンス化
        spawnedParticle = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // Particle Systemの再生
        ParticleSystem ps = spawnedParticle.GetComponent<ParticleSystem>();
        ps.Play();
    }

    public void DestroyParticle()
    {
        if (spawnedParticle != null)
        {
            Destroy(spawnedParticle);
        }
    }



}
