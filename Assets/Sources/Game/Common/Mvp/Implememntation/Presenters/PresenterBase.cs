using Sources.Common.Mvp.Interfaces;

namespace Sources.Common.Mvp.Implememntation.Presenters
{
    public abstract class PresenterBase : IPresenter
    {
        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }
    }
}