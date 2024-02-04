using System;
using Sources.BoundedContexts.Common.Interfaces;
using Sources.Interfaces.Presentation.Views;

namespace Sources.Implementation.Presentation.Views
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