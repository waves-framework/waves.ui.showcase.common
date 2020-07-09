using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Base;
using Waves.UI.Commands;
using Waves.UI.Modality.Base;
using Waves.UI.Modality.Presentation;
using Waves.UI.Modality.Presentation.Enums;
using Waves.UI.Services.Interfaces;
using Waves.UI.Showcase.Common.Presentation.ModalWindow;
using Waves.UI.Showcase.Common.Services.Interfaces;

namespace Waves.UI.Showcase.Common.ViewModel.Tabs
{
    /// <summary>
    ///     Configuration tab view model.
    /// </summary>
    public class ConfigurationTabViewModel : ShowcaseTabViewModel
    {
        private readonly object _locker = new object();

        /// <inheritdoc />
        public ConfigurationTabViewModel(Core core) : base(core)
        {
        }

        /// <summary>
        ///     Gets whether configuration is changed.
        /// </summary>
        public bool IsConfigurationChanged { get; private set; }

        /// <summary>
        ///     Gets or sets selected property.
        /// </summary>
        public IProperty SelectedProperty { get; set; }

        /// <summary>
        ///     Gets collection of propeties.
        /// </summary>
        public ObservableCollection<IProperty> Properties { get; } = new ObservableCollection<IProperty>();

        /// <summary>
        ///     Gets core configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets collection synchronization service.
        /// </summary>
        public ICollectionSynchronizationService CollectionSynchronizationService { get; private set; }

        /// <summary>
        ///     Gets "Add new property" command.
        /// </summary>
        public ICommand AddPropertyCommand { get; private set; }

        /// <summary>
        ///     Gets "Show property" command.
        /// </summary>
        public ICommand ShowPropertyCommand { get; private set; }

        /// <summary>
        ///     Gets "Edit property" command.
        /// </summary>
        public ICommand EditPropertyCommand { get; private set; }

        /// <summary>
        ///     Gets "Save All" command.
        /// </summary>
        public ICommand SaveAllCommand { get; private set; }

        /// <summary>
        ///     Gets "Remove property" command.
        /// </summary>
        public ICommand RemovePropertyCommand { get; private set; }

        /// <summary>
        ///     Gets "Double click" command.
        /// </summary>
        public ICommand PropertiesDoubleClickCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            CollectionSynchronizationService = Core.GetService<ICollectionSynchronizationService>();

            Configuration = (IConfiguration) Core.Configuration.Clone();

            InitializeCollection();
            SubscribeEvents();
            InitializeCommands();
        }

        /// <summary>
        ///     Initializes collection synchronization.
        /// </summary>
        private void InitializeCollection()
        {
            CollectionSynchronizationService?.EnableCollectionSynchronization(Properties, _locker);

            Properties.Clear();

            foreach (var property in Configuration.GetProperties()) Properties.Add(property);
        }

        /// <summary>
        ///     Subscribe events.
        /// </summary>
        private void SubscribeEvents()
        {
            Configuration.PropertyChanged += OnConfigurationPropertyChanged;

            foreach (var property in Configuration.GetProperties())
                property.PropertyChanged += OnConfigurationPropertyChanged;

            Properties.CollectionChanged += OnPropertyCollectionCollectionChanged;
        }

        /// <summary>
        ///     Notifies when property collection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPropertyCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IsConfigurationChanged = !Configuration.Equals(Core.Configuration);
        }

        /// <summary>
        ///     Notifies when configuration property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnConfigurationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsConfigurationChanged = !Configuration.Equals(Core.Configuration);
        }

        /// <summary>
        ///     Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            AddPropertyCommand = new SimpleCommand(OnAddProperty);
            ShowPropertyCommand = new SimpleCommand(OnShowProperty);
            EditPropertyCommand = new SimpleCommand(OnEditProperty);
            RemovePropertyCommand = new SimpleCommand(OnRemoveProperty);
            SaveAllCommand = new SimpleCommand(OnSaveAll);
            PropertiesDoubleClickCommand = new SimpleCommand(OnPropertiesDoubleClick);
        }

        /// <summary>
        ///     Actions for "Add property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnAddProperty(object obj)
        {
            var service = Core.GetService<IConfigurationWindowsService>();
            if (service == null) return;

            var presentation = new AddPropertyModalWindowPresentation(Core, Properties, Configuration);
            presentation.SetView(service.GetAddPropertyPresentationView());

            Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        ///     Actions for "Show property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnShowProperty(object obj)
        {
            var service = Core.GetService<IConfigurationWindowsService>();
            if (service == null) return;

            var presentation = new ShowPropertyModalWindowPresentation(Core, SelectedProperty);
            presentation.SetView(service.GetShowPropertyPresentationView());

            Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        ///     Actions for "Edit property".
        /// </summary>
        /// <param name="obj"></param>
        private void OnEditProperty(object obj)
        {
            var service = Core.GetService<IConfigurationWindowsService>();
            if (service == null) return;

            var presentation = new EditPropertyModalWindowPresentation(Core, SelectedProperty, Configuration);
            presentation.SetView(service.GetEditPropertyPresentationView());

            // Hack for next exception:
            // System.Private.CoreLib: An exception was received:
            // An item with the same key has already been added. Key: System.Windows.Controls.ItemsControl+ItemInfo.
            SelectedProperty = null;

            Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        ///     Actions for "Remove property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnRemoveProperty(object obj)
        {
            var presentation = new MessageModalWindowPresentation(
                Core,
                "Remove property",
                "Do you want to remove property \"" + SelectedProperty.Name + "\"?",
                MessageIcon.Question);

            var actions = ModalWindowAction.YesNo(
                new Action(() =>
                {
                    Configuration.RemoveProperty(SelectedProperty.Name);

                    Properties.Remove(SelectedProperty);

                    Core.HideModalityWindow(presentation);
                }), new Action(() => { Core.HideModalityWindow(presentation); }));

            presentation.InitializeActions(actions);

            Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        ///     Actions for "Save all".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnSaveAll(object obj)
        {
            var presentation = new MessageModalWindowPresentation(
                Core,
                "Save configuration",
                "Do you really want to save configuration?",
                MessageIcon.Warning);

            var actions = ModalWindowAction.YesNo(
                new Action(() =>
                {
                    Configuration.RewriteConfiguration(Configuration);

                    Core.HideModalityWindow(presentation);
                }), new Action(() => { Core.HideModalityWindow(presentation); }));

            presentation.InitializeActions(actions);

            Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        ///     Actions for double click.
        /// </summary>
        /// <param name="obj"></param>
        private void OnPropertiesDoubleClick(object obj)
        {
            OnShowProperty(null);
        }
    }
}