using Leopotam.Ecs;

namespace Utilities.RigidbodyFixer
{
    public class RigidbodyFixerSystem : IEcsRunSystem
    {
        private EcsFilter<RigidbodyFixerComponent> _filter = null;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var rigidbodyFixerComponent = ref _filter.Get1(i);
                var rb = rigidbodyFixerComponent.Rb;
                if (rb == null) continue;

                rb.position = FixVector(rb.position);
                rb.rotation = FixQuaternion(rb.rotation);
                rb.velocity = FixVector(rb.velocity);
                rb.angularVelocity = FixVector(rb.angularVelocity);
            }
        }

        private Vector3 FixVector(Vector3 vector3)
        {
            var result = vector3;
            if(float.IsNaN(result.x))
                result.x = 0f;
            if(float.IsNaN(result.y))
                result.y = 0f;
            if(float.IsNaN(result.z))
                result.z = 0f;
            return result;
        }
        
        private Quaternion FixQuaternion(Quaternion quaternion)
        {
            var result = quaternion;
            if(float.IsNaN(result.x))
                result.x = 0f;
            if(float.IsNaN(result.y))
                result.y = 0f;
            if(float.IsNaN(result.z))
                result.z = 0f;
            if(float.IsNaN(result.w))
                result.w = 0f;
            return result;
        }
    }
}