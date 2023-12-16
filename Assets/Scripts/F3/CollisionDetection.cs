using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using F3;

public class CollisionDetection : MonoBehaviour
{
	private Collider2D mycollider;
    void OnTriggerEnter2D(Collider2D collider)
    {
		/*
		1,当たったらエフェクトを出す 
		2,ShootGlobalのstateをF4に変える
		3,TargetとTargetPronを消す
		*/

		EventManager.DeleteTarget?.Invoke();//targetが無い状態であると示している
		mycollider=collider;

		Destroy(collider.gameObject);
		Destroy(gameObject);

    }
}