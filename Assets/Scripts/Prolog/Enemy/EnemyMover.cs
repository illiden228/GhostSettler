﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}
