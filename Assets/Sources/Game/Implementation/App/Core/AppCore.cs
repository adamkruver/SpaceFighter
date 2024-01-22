using UnityEngine;
using Zenject;

namespace Sources.Game.Implementation.App.Core
{
    public class AppCore : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}