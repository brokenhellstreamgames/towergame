using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ATBProcessor
{
    private static float _speedFactor = .25f;
    private float speed;
    private float value = 0;
    public int ID { get; private set; }
    public float Value => value;

    public ATBProcessor(int ID, float speed)
    {
        this.ID = ID;
        this.speed = speed;
    }

    public int Update(float deltaTime)
    {
        if(value < 1)
        {
            value += deltaTime * speed * _speedFactor;
            return -1;
        } else
        {
            return ID;
        }
    }
}
