using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Bullets.Implementation.Services
{
    public class BulletService
    {

        private readonly BulletFactory _bulletFactory;
        private readonly ObjectPool<BulletView> _viewObjectPool;

        private readonly BulletViewFactory _bulletViewFactory;


        public BulletService(BulletAssetProvider bulletAssetProvider,BulletFactory bulletFactory,BulletViewFactory bulletViewFactory)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
            _viewObjectPool = new ObjectPool<BulletView>(()=>Object.Instantiate(bulletAssetProvider.View));
        }

        public void Shoot(Vector3 position, Quaternion rotation, float speed)
        {
            Bullet model = _bulletFactory.Create(position, rotation, speed);
            
            BulletView view = _bulletViewFactory.Create(model,_viewObjectPool.Get());
        }
    }
}