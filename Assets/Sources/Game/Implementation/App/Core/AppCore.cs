using UnityEngine;

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