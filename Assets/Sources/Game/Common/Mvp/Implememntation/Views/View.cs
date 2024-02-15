using UnityEngine;

namespace Sources.Common.Mvp.Implememntation.Views
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