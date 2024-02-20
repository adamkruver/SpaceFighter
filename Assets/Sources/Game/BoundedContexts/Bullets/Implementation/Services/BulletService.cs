using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Bullets.Implementation.Services
{
    public class BulletService
    {
        private readonly ObjectPool<BulletView> _viewObjectPool;
        private readonly BulletViewFactory _bulletViewFactory;


        public BulletService(BulletAssetProvider bulletAssetProvider,BulletViewFactory bulletViewFactory)
        {
            _bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
            _viewObjectPool = new ObjectPool<BulletView>(()=>Object.Instantiate(bulletAssetProvider.View));
        }

        public void Shoot(Vector3 position, Quaternion rotation, float speed) =>
            _bulletViewFactory.Create(_viewObjectPool.Get(), position, rotation, speed);
    }
}