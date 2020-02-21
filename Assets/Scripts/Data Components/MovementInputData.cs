using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct MovementInputData : IComponentData
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode upRightKey;
    public KeyCode downRightKey;
    public KeyCode upLeftKey;
    public KeyCode downLeftKey;
}
