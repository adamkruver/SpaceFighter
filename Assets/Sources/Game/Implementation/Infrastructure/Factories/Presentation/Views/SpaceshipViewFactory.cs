﻿using System;
using System.Threading.Tasks;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Controllers;
using Sources.Implementation.Presentation.Views;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Sources.Implementation.Infrastructure.Factories.Presentation.Views
{
    public class SpaceshipViewFactory
    {
        private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IPhysicsMovementViewFactory<PhysicsMovementView> _physicsMovementViewFactory;
        private readonly IPhysicsTorqueViewFactory<PhysicsTorqueView> _physicsTorqueViewFactory;
        private readonly IWeaponViewFactory _weaponViewFactory;

        public SpaceshipViewFactory(
            SpaceshipPresenterFactory spaceshipPresenterFactory,
            IDependencyResolver dependencyResolver,
            IPhysicsMovementViewFactory<PhysicsMovementView> physicsMovementViewFactory,
            IPhysicsTorqueViewFactory<PhysicsTorqueView> physicsTorqueViewFactory,
            IWeaponViewFactory weaponViewFactory
            )
        {
            _spaceshipPresenterFactory = spaceshipPresenterFactory ??
                                         throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
            _physicsMovementViewFactory = physicsMovementViewFactory ??
                                          throw new ArgumentNullException(nameof(physicsMovementViewFactory));
            _physicsTorqueViewFactory = physicsTorqueViewFactory ?? throw new ArgumentNullException(nameof(physicsTorqueViewFactory));
            _weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
        }

        public async Task<SpaceshipView> Create(Spaceship spaceship)
        {
            GameObject prefab = await LoadSpaceshipView();
            SpaceshipView view = UnityEngine.Object.Instantiate(prefab.GetComponent<SpaceshipView>()); 
                //_dependencyResolver.InstantiateComponentFromPrefab(prefab);
            var presenter = _spaceshipPresenterFactory.Create(spaceship, view);
            view.Construct(presenter);
            
            _physicsMovementViewFactory.Create(spaceship.Movement, view.PhysicsMovementView);
            _physicsTorqueViewFactory.Create(spaceship.Torque, view.PhysicsTorqueView);
            _weaponViewFactory.Create(view.WeaponView);
            
            return view;
        }

        private async Task<GameObject> LoadSpaceshipView()
        {
            AsyncOperationHandle<GameObject> handle =  Addressables.LoadAssetAsync<GameObject>("SpaceshipView");
            await handle.Task;
            return handle.Result;
        }
    }
}