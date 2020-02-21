using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct MovementData : IComponentData
{
    public Vector3 direction;
    public float speed;
}
