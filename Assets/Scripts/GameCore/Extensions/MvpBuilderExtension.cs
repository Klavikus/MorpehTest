using Modules.UI.MVPPassiveView.Runtime.Presenters;
using Modules.UI.MVPPassiveView.Runtime.Views;
using VContainer;
using VContainer.Unity;

namespace GameCore.Extensions
{
    public static class MvpBuilderExtension
    {
        public static IContainerBuilder BindViewWithPresenter<TView, TPresenter>(
            this IContainerBuilder builder,
            TView viewInstance)
            where TView : IView
            where TPresenter : IPresenter
        {
            builder.RegisterComponent(viewInstance).As<TView>();
            builder.Register<TPresenter>(Lifetime.Transient);

            return builder;
        }

        public static IObjectResolver ConstructView<TView, TPresenter>(this IObjectResolver resolver)
            where TView : IView
            where TPresenter : IPresenter
        {
            TView view = resolver.Resolve<TView>();
            TPresenter presenter = resolver.Resolve<TPresenter>();
            view.Construct(presenter);

            return resolver;
        }
    }
}