namespace CairoDesktop
{
    using System;
    using System.ComponentModel;
    using System.Windows.Media;

    /// <summary>
    /// TrayIcon class representing a notification icon in the system tray.
    /// </summary>
    public class TrayIcon : IEquatable<TrayIcon>, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the TrayIcon class with no hwnd.
        /// </summary>
        public TrayIcon() : this(IntPtr.Zero)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TrayIcon class with the specified hWnd.
        /// </summary>
        /// <param name="hWnd">The window handle of the icon.</param>
        public TrayIcon(IntPtr hWnd)
        {
            this.HWnd = hWnd;
        }

        private ImageSource _icon;

        /// <summary>
        /// Gets or sets the Icon's image.
        /// </summary>
        public ImageSource Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        private string _title;

        /// <summary>
        /// Gets or sets the Icon's title (tool tip).
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the pointer to the menu.
        /// </summary>
        public IntPtr Menu
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the owners handle.
        /// </summary>
        public IntPtr HWnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the callback message id.
        /// </summary>
        public int CallbackMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the UID of the Icon.
        /// </summary>
        public int UID
        {
            get;
            set;
        }

        #region IEquatable<TrayIcon> Members

        /// <summary>
        /// Checks the equality of the icon based on the hWnd and uID;
        /// </summary>
        /// <param name="other">The other TrayIcon to compare to.</param>
        /// <returns>Indication of equality.</returns>
        public bool Equals(TrayIcon other)
        {
            return this.HWnd.Equals(other.HWnd) && this.UID.Equals(other.UID);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        #endregion
    }
}
