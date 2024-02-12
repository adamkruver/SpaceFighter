﻿using System;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories
{
    public class PhysicsTorqueViewFactory<T> : IPhysicsTorqueViewFactory<T>
        where T : IPhysicsTorqueView, IPresentableView<PhysicsTorquePresenter>
    {
        private readonly PhysicsTorquePresenterFactory _physicsTorquePresenterFactory;

        public PhysicsTorqueViewFactory(PhysicsTorquePresenterFactory physicsTorquePresenterFactory) =>
            _physicsTorquePresenterFactory = physicsTorquePresenterFactory ??
                                             throw new ArgumentNullException(nameof(physicsTorquePresenterFactory));

        public IPhysicsTorqueView Create(IPhysicsTorque torque, T view)
        {
            PhysicsTorquePresenter presenter = _physicsTorquePresenterFactory.Create(torque, view);
            view.Construct(presenter);

            return view;
        }
    }
}