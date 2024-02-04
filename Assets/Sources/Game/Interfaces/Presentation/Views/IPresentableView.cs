using Sources.BoundedContexts.Common.Interfaces;

namespace Sources.Interfaces.Presentation.Views
{
    public interface IPresentableView<in T> where T : class, IPresenter
    {
        void Construct(T presenter);
    }
}