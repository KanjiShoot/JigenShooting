/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
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
