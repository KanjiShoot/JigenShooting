using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace F3ToF4{
    public class EventManager
    {
        public static UnityAction<ShootContext> HandleDataReady;
        public static void Init(){
            HandleDataReady=null;
        }
    }
}
