using System.Collections;
using Leopotam.Ecs;
using UnityEngine;

namespace Utilities.RigidbodyFixer
{
    public class RigidbodyFixerLauncher : MonoBehaviour
    {
        [SerializeField] private LayerMask dynamicLayers;
        
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private bool _initialized;

        private void Start()
        {
            StartCoroutine(InitializationCoroutine());
        }

        private IEnumerator InitializationCoroutine()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems.Add(new RigidbodyFixerSystem());
            
            yield return null; // or another delay of loading scene objects

            foreach (var item in FindObjectsOfType<Rigidbody>())
            {
                if (!item.gameObject.layer.WithinMask(dynamicLayers)) continue;
                var entity = _world.NewEntity();
                var rigidbodyFixerComponent = entity.Get<RigidbodyFixerComponent>();
                rigidbodyFixerComponent.Rb = item;
            }
            
            _systems?.Init();
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized) return;
            _systems?.Run();
        }

        private void OnDestroy()
        {
            _systems?.Destroy();
            _world?.Destroy();
        }
    }
}