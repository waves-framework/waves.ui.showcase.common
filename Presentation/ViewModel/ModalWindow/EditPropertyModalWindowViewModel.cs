using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ReactiveUI;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.Base.Interfaces;
using Waves.UI.Modality.ViewModel;

namespace Waves.UI.Showcase.Common.Presentation.ViewModel.ModalWindow
{
    /// <summary>
    /// </summary>
    public class EditPropertyModalWindowViewModel : ModalWindowPresenterViewModel
    {
        private IModalWindowAction _action;
        private Type _type = typeof(int);
        private object _value;

        /// <summary>
        /// Creates new instance of <see cref="EditPropertyModalWindowViewModel"/>
        /// </summary>
        /// <param name="core"></param>
        /// <param name="property">Property.</param>
        public EditPropertyModalWindowViewModel(IWavesCore core, IWavesProperty property) : base(core)
        {
            Name = property.Name;
            Value = property.GetValue();
        }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        ///     Gets whether property can be deleted.
        /// </summary>
        public bool CanBeDeleted { get; set; }

        /// <summary>
        ///     Gets whether property is read only.
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        ///     Gets or sets name.
        /// </summary>
        public override string Name { get; set; } = "New property";

        /// <summary>
        ///     Gets or sets value.
        /// </summary>
        public object Value
        {
            get => _value;
            set
            {
                _value = value;

                try
                {
                    ConvertedValue = Convert.ChangeType(_value, Type);
                }
                catch (Exception e)
                {
                    OnMessageReceived(this,new WavesMessage(e, false));
                }

                this.RaiseAndSetIfChanged(ref _value, value);
            }
        }

        /// <summary>
        ///     Gets or sets converted value.
        /// </summary>
        public object ConvertedValue { get; set; }

        /// <summary>
        ///     Gets or sets type.
        /// </summary>
        public Type Type
        {
            get => _type;
            set
            {
                _type = value;

                try
                {
                    ConvertedValue = Convert.ChangeType(_value, Type);
                }
                catch (Exception e)
                {
                    OnMessageReceived(this,new WavesMessage(e, false));
                }

                this.RaiseAndSetIfChanged(ref _type, value);
            }
        }

        /// <summary>
        ///     Gets or sets collection of types.
        /// </summary>
        public ObservableCollection<Type> Types { get; } = new ObservableCollection<Type>
        {
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),
            typeof(string)
        };

        /// <inheritdoc />
        public override void Initialize()
        {
            PropertyChanged += OnPropertyChanged;

            InitializeAction();
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <summary>
        ///     Gets result property.
        /// </summary>
        /// <returns>Property.</returns>
        public IWavesProperty GetResultProperty()
        {
            var type = typeof(WavesProperty<>).MakeGenericType(Type);
            var args = new[] {Name, ConvertedValue, IsReadOnly, CanBeDeleted};
            var property = (IWavesProperty) Activator.CreateInstance(type, args);

            return property;
        }

        /// <summary>
        ///     Notifies when property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InitializeAction();

            var isEnabled = true;

            if (e.PropertyName == "Name" || e.PropertyName == "Value")
            {
                if (string.IsNullOrEmpty(Name)) isEnabled = false;

                if (ConvertedValue == null) isEnabled = false;

                if (_action == null) return;

                _action.IsEnabled = isEnabled;
            }
        }

        /// <summary>
        /// </summary>
        private void InitializeAction()
        {
            if (_action != null) return;
            if (Actions == null) return;

            foreach (var action in Actions)
                if (action.Caption == "Save")
                    _action = action;
        }

        /// <summary>
        ///     Converts object to current type.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="input">Input.</param>
        /// <returns>Converted object.</returns>
        private T ConvertObject<T>(object input)
        {
            return (T) Convert.ChangeType(input, typeof(T));
        }
    }
}