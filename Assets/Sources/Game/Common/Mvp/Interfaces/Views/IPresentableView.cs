namespace Sources.Common.Mvp.Interfaces.Views
{
    public interface IPresentableView<in T> where T : class, IPresenter
    {
        void Construct(T presenter);
    }
}