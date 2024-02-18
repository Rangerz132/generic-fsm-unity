using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObjects/Movement/BasicMovement", order = 1)]
public class MovementSO : ScriptableObject
{
    public float speed;
    public float rotationSpeed;
}
