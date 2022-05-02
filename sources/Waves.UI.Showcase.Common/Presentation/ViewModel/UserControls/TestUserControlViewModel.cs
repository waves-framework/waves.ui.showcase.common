using System.Windows.Input;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Waves.UI.Base.Attributes;
using Waves.UI.Presentation;
using Waves.UI.Services.Interfaces;
using Waves.UI.Showcase.Common.Presentation.ViewModel.Pages;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.UserControls;

/// <summary>
/// Test user control.
/// </summary>
[WavesViewModel(typeof(TestUserControlViewModel))]
public class TestUserControlViewModel : WavesViewModelBase
{
    private readonly IWavesNavigationService _navigationService;

    /// <summary>
    /// Creates new instance of <see cref="TestUserControlViewModel"/>.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    /// <param name="logger">Logger.</param>
    public TestUserControlViewModel(
        IWavesNavigationService navigationService,
        ILogger<TestUserControlViewModel> logger)
        : base(logger)
    {
        _navigationService = navigationService;

        NextControlCommand = ReactiveCommand.CreateFromTask(OnNextControl);
        PreviousControlCommand = ReactiveCommand.CreateFromTask(OnPreviousControl);
    }

    /// <summary>
    /// Command.
    /// </summary>
    public ICommand NextControlCommand { get; protected set; }

    /// <summary>
    /// Command.
    /// </summary>
    public ICommand PreviousControlCommand { get; protected set; }

    private async Task OnNextControl()
    {
        var a = await _navigationService.NavigateAsync<TestUserControlViewModel2, string, int>("asd");
    }

    private async Task OnPreviousControl()
    {
        await _navigationService.GoBackAsync(this);
    }
}
