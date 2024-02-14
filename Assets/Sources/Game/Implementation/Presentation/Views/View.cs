using UnityEngine;

namespace Sources.Implementation.Presentation.Views
{
    public abstract class View : MonoBehaviour
    {
        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void Destroy() =>
            Destroy(gameObject);
    }
}