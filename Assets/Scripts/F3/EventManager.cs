using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace F3{
    public class EventManager
    {
        public static UnityAction<string,string> PlaceTarget;

        //F3
        public static UnityAction DeleteTarget;
        public static UnityAction CreateTarget;
        public static UnityAction SpawnAndPlayParticle;
        public static UnityAction DestroyParticle;
    
        public static void Init(){
            // 変数にnullを代入
            PlaceTarget = null;
            DeleteTarget = null;
            CreateTarget = null;
            SpawnAndPlayParticle = null;
            DestroyParticle = null;
        }

    }
}
