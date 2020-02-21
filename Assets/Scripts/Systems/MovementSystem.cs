using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[AlwaysSynchronizeSystem]
// TODO rename/refactor to be 2D top down movement system
// TODO unit testing
public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref PhysicsVelocity velocity, ref Translation position, ref Rotation rotation, in MovementData data) =>
        {
            position.Value.z = 0;
            rotation.Value = Quaternion.identity;
            velocity.Linear = data.speed * data.direction * deltaTime;
            velocity.Angular = Vector3.zero;
        }).Run();

        return default;
    }
}
