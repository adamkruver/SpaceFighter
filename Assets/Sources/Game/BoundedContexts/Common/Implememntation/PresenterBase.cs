using Sources.Game.BoundedContexts.Common.Interfaces;

namespace Sources.Game.BoundedContexts.Common.Implememntation
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