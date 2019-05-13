using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Faseto.Word.ViewModel.Base;
using Faseto.Word.Window;
using Point = System.Windows.Point;

namespace Faseto.Word.ViewModel
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region PrivateMember

        /// <summary>
        /// The window the  viewModel controls
        /// </summary>
        private System.Windows.Window _window;

        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gives the width height of the window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// Gives the minimum height of the window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        public int InnerContentPadding { get; set; } = 10;


        /// <summary>
        /// The Height of the Title Bar / Caption Height of the Window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// Set's the outer margin based on  window state
        /// </summary>
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        ///  Set's the window radius based on  window state
        /// </summary>
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The size of the resize border around the windows
        /// </summary>
        public Thickness InnerContentPaddingThickness => new Thickness(InnerContentPadding);


        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        public Thickness OuterMarginThickness => new Thickness(OuterMarginSize);
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        #endregion


        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to Maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to show the system menu 
        /// </summary>
        public ICommand MenuCommand { get; set; }

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(System.Windows.Window window)
        {
            _window = window;
            _window.StateChanged += _window_StateChanged;

            //create commands
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
            var windowResizer = new WindowResizer(_window);
        }

        private void _window_StateChanged(object sender, System.EventArgs e)
        {
            //fire off event for all properties for when window resizes
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion


        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        public Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #endregion
    }
}