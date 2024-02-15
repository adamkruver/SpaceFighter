using System;
using Sources.Common.Mvp.Interfaces;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.Common.Mvp.Implememntation.Views
{
    public abstract class PresentableView<T> : View, IPresentableView<T> where T : class, IPresenter
    {
        protected T Presenter { get; private set; }

        private void OnEnable() => 
            Presenter?.Enable();

        private void OnDisable() => 
            Presenter?.Disable();
        
        public void Construct(T presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            Hide();
            Presenter = presenter;
            Show();
        }
    }
}