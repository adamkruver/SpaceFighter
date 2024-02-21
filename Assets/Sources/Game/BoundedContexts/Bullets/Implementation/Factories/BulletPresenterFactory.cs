using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Models;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
    public class BulletPresenterFactory
    {
        private readonly ILateUpdateService _lateUpdateService;

        public BulletPresenterFactory(ILateUpdateService lateUpdateService) =>
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));


        public BulletPresenter Create(Bullet model, IBulletView view) =>
            new BulletPresenter(model, view, _lateUpdateService);
    }
}