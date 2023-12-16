using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Result{
    public class EventManager
    {
        public static UnityAction<ShootContext> HandleDataReady;
        public static void Init(){
            HandleDataReady=null;
        }
    }
}
