using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class MovementInputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities.ForEach((ref MovementData moveData, in MovementInputData inputData) => {
            moveData.direction = Vector2.zero;
            moveData.direction.x += Input.GetKey(inputData.rightKey) ? 1 : 0;
            moveData.direction.x -= Input.GetKey(inputData.leftKey) ? 1 : 0;
            moveData.direction.y += Input.GetKey(inputData.upKey) ? 1 : 0;
            moveData.direction.y -= Input.GetKey(inputData.downKey) ? 1 : 0;
        }).Run();

        return default;
    }
}
