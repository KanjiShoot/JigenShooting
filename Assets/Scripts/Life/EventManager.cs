using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Life{
    public class EventManager
    {
        public static UnityAction ReduceLifePoint;
        public static void Init(){
            ReduceLifePoint=null;
        }
    }

}
