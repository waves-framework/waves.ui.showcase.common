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
[WavesViewModel(typeof(TestUserControlViewModel2))]
public class TestUserControlViewModel2 : WavesViewModelBase<string, int>
{
    private readonly IWavesNavigationService _navigationService;

    /// <summary>
    /// Creates new instance of <see cref="TestUserControlViewModel2"/>.
    /// </summary>
    /// <param name="navigationService">Navigation service.</param>
    /// <param name="logger">Logger.</param>
    public TestUserControlViewModel2(
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

    /// <inheritdoc />
    public override Task Prepare(string t)
    {
        var a = t;
        return Task.CompletedTask;
    }

    private async Task OnNextControl()
    {
        Result = 10;
        OnResultApproved();
        await _navigationService.GoBackAsync(this);
    }

    private async Task OnPreviousControl()
    {
        await _navigationService.GoBackAsync(this);
    }
}
