using Sources.Game.BoundedContexts.Common.Interfaces;

namespace Sources.Game.Interfaces.Presentation.Views
{
    public interface IPresentableView<in T> where T : class, IPresenter
    {
        void Construct(T presenter);
    }
}