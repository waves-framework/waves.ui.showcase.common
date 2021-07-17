using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base.Interfaces;
using Waves.UI.Plugins.Services.Interfaces;
using Waves.UI.Presentation;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Pages;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.Tabs
{
    /// <summary>
    /// Tab view model abstraction.
    /// </summary>
    public abstract class TabViewModel : WavesViewModelBase
    {
        /// <summary>
        /// Creates new instance of <see cref="TabViewModel"/>.
        /// </summary>
        /// <param name="core">Instance of <see cref="IWavesCore"/>.</param>
        /// <param name="navigationService">Instance of <see cref="IWavesNavigationService"/>.</param>
        protected TabViewModel(
            IWavesCore core,
            IWavesNavigationService navigationService)
        {
            Core = core;
            NavigationService = navigationService;
        }

        /// <summary>
        /// Gets title.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Gets icon resource string.
        /// </summary>
        public abstract string Icon { get; }

        /// <summary>
        /// Gets collection of inner pages.
        /// </summary>
        [Reactive]
        public ObservableCollection<PageViewModel> Pages { get; protected set; }

        /// <summary>
        /// Gets core.
        /// </summary>
        protected IWavesCore Core { get; }

        /// <summary>
        /// Gets navigation service.
        /// </summary>
        protected IWavesNavigationService NavigationService { get; }

        /// <inheritdoc />
        public override Task InitializeAsync()
        {
            Pages = new ObservableCollection<PageViewModel>();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Adds tab to collection by current type.
        /// </summary>
        /// <typeparam name="T">Type of tab view model.</typeparam>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected async Task AddPage<T>()
            where T : PageViewModel
        {
            var viewModel = await Core.GetInstanceAsync<T>();
            await viewModel.InitializeAsync();
            Pages.Add(viewModel);
        }
    }
}
