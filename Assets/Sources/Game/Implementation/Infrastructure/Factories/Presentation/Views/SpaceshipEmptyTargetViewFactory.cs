using System;
using Sources.Implementation.Controllers;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Controllers;
using Sources.Implementation.Presentation.Views;
using UniCtor.Builders;
using UnityEngine;

namespace Sources.Implementation.Infrastructure.Factories.Presentation.Views
{
	public class SpaceshipEmptyTargetViewFactory
	{
		private readonly EmptyTargetPresenterFactory _emptyTargetPresenterFactory;
		private readonly IDependencyResolver _dependencyResolver;

		public SpaceshipEmptyTargetViewFactory(EmptyTargetPresenterFactory emptyTargetPresenterFactory, IDependencyResolver dependencyResolver)
		{
			_emptyTargetPresenterFactory = emptyTargetPresenterFactory ?? throw new ArgumentNullException(nameof(emptyTargetPresenterFactory));
			_dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
		}

		public EmptyTargetView Create(EmptyTarget emptyTarget, SpaceshipView spaceshipView)
		{
			GameObject gameObject = new GameObject();
			GameObject senya = new GameObject("senyatipo");
			gameObject.transform.SetParent(spaceshipView.transform);
			senya.transform.SetParent(spaceshipView.transform);
			
			EmptyTargetView emptyTargetView = gameObject.AddComponent<EmptyTargetView>();
			_dependencyResolver.Resolve(emptyTargetView.gameObject);
            
			EmptyTargetPresenter presenter = _emptyTargetPresenterFactory.Create(emptyTarget, emptyTargetView);
			emptyTargetView.Construct(presenter);

			return emptyTargetView;
		} 
	}
}