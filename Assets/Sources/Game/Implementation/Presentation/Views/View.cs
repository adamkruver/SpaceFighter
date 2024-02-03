using UnityEngine;

namespace Sources.Game.Implementation.Presentation.Views
{
    public abstract class View : MonoBehaviour
    {
        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);
    }
}