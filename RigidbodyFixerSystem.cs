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
                
                var position = rb.position;
                if(float.IsNaN(position.x))
                    position.x = 0f;
                if(float.IsNaN(position.y))
                    position.y = 0f;
                if(float.IsNaN(position.z))
                    position.z = 0f;
                rb.position = position;
            
                var rotation = rb.rotation;
                if(float.IsNaN(rotation.x))
                    rotation.x = 0f;
                if(float.IsNaN(rotation.y))
                    rotation.y = 0f;
                if(float.IsNaN(rotation.z))
                    rotation.z = 0f;
                if(float.IsNaN(rotation.w))
                    rotation.w = 0f;
                rb.rotation = rotation;
            
                var velocity = rb.velocity;
                if(float.IsNaN(velocity.x))
                    velocity.x = 0f;
                if(float.IsNaN(velocity.y))
                    velocity.y = 0f;
                if(float.IsNaN(velocity.z))
                    velocity.z = 0f;
                rb.velocity = velocity;
            
                var angularVelocity = rb.angularVelocity;
                if(float.IsNaN(angularVelocity.x))
                    angularVelocity.x = 0f;
                if(float.IsNaN(angularVelocity.y))
                    angularVelocity.y = 0f;
                if(float.IsNaN(angularVelocity.z))
                    angularVelocity.z = 0f;
                rb.angularVelocity = angularVelocity;
            }
        }
    }
}