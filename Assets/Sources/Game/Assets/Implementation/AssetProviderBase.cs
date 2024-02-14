using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sources.Assets.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sources.Assets.Implementation
{
	public abstract class AssetProviderBase : IAssetProvider
	{
		private readonly List<GameObject> _gameObjects = new List<GameObject>();

		public abstract Task LoadAsync();

		public void Release()
		{
			foreach (GameObject gameObject in _gameObjects)
				Addressables.ReleaseInstance(gameObject);
		}

		protected async Task<T> Load<T>(string key) where T : MonoBehaviour
		{
			GameObject gameObject = await Addressables.LoadAssetAsync<GameObject>(key).Task;

			if (gameObject.TryGetComponent(out T component) == false)
				throw new NullReferenceException(nameof(component));

			_gameObjects.Add(gameObject);

			return component;
		}
	}
}