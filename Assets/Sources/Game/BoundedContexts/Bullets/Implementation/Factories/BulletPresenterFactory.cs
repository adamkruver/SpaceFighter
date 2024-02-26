using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Models;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
    public class BulletPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IFixedUpdateService _fixedUpdateService;

        public BulletPresenterFactory(IUpdateService lateUpdateService, IFixedUpdateService fixedUpdateService)
        {
            _updateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
        }

        public BulletPresenter Create(Bullet model, IBulletView view) =>
            new BulletPresenter(model, view, _updateService, _fixedUpdateService);
    }
}