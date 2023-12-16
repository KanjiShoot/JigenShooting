/*
Copyright © 2023 Ishimaki Kazutoyo. All rights reserved.
This source code or any portion thereof must not be  
reproduced or used in any manner whatsoever.
*/
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using AirCraft;
public class BulletController : MonoBehaviour
{
    private float fallspeed = 0.10f;
    private GameObject enemy;
    void Update()
    {
        transform.Translate(0, fallspeed, 0);

        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }



    private void BulletDisposal()
    {
        Destroy(gameObject);
    }

}