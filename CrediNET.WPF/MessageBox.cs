using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace CrediNET
{
    public class MessageBox
    {
        public static void Show(string msg, string title = "", System.Windows.MessageBoxButton btn = System.Windows.MessageBoxButton.OK)
        {
            ModernDialog.ShowMessage(msg, title, btn);
        }
    }

    public class InputBox
        : ModernDialog
    {
        /*/// <summary>
        /// Identifies the BackgroundContent dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(InputBox));
        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register("Buttons", typeof(IEnumerable<Button>), typeof(InputBox));

        private ICommand closeCommand;

        private Button okButton;
        private Button cancelButton;
        private Button yesButton;
        private Button noButton;
        private Button closeButton;

        private MessageBoxResult messageBoxResult = MessageBoxResult.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBox"/> class.
        /// </summary>
        public InputBox()
        {
            this.DefaultStyleKey = typeof(InputBox);
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.closeCommand = new RelayCommand(o =>
            {
                var result = o as MessageBoxResult?;
                if (result.HasValue)
                {
                    this.messageBoxResult = result.Value;

                    // sets the Window.DialogResult as well
                    if (result.Value == MessageBoxResult.OK || result.Value == MessageBoxResult.Yes)
                    {
                        this.DialogResult = true;
                    }
                    else if (result.Value == MessageBoxResult.Cancel || result.Value == MessageBoxResult.No)
                    {
                        this.DialogResult = false;
                    }
                    else
                    {
                        this.DialogResult = null;
                    }
                }
                Close();
            });

            this.Buttons = new Button[] { this.CloseButton };

            // set the default owner to the app main window (if possible)
            if (Application.Current != null && Application.Current.MainWindow != this)
            {
                this.Owner = Application.Current.MainWindow;
            }
        }

        private Button CreateCloseDialogButton(string content, bool isDefault, bool isCancel, MessageBoxResult result)
        {
            return new Button
            {
                Content = content,
                Command = this.CloseCommand,
                CommandParameter = result,
                IsDefault = isDefault,
                IsCancel = isCancel,
                MinHeight = 21,
                MinWidth = 65,
                Margin = new Thickness(4, 0, 0, 0)
            };
        }

        /// <summary>
        /// Gets the close window command.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return this.closeCommand; }
        }

        /// <summary>
        /// Gets the Ok button.
        /// </summary>
        public Button OkButton
        {
            get
            {
                if (this.okButton == null)
                {
                    this.okButton = CreateCloseDialogButton(FirstFloor.ModernUI.Resources.Ok, true, false, MessageBoxResult.OK);
                }
                return this.okButton;
            }
        }

        /// <summary>
        /// Gets the Cancel button.
        /// </summary>
        public Button CancelButton
        {
            get
            {
                if (this.cancelButton == null)
                {
                    this.cancelButton = CreateCloseDialogButton(FirstFloor.ModernUI.Resources.Cancel, false, true, MessageBoxResult.Cancel);
                }
                return this.cancelButton;
            }
        }

        /// <summary>
        /// Gets the Yes button.
        /// </summary>
        public Button YesButton
        {
            get
            {
                if (this.yesButton == null)
                {
                    this.yesButton = CreateCloseDialogButton(FirstFloor.ModernUI.Resources.Yes, true, false, MessageBoxResult.Yes);
                }
                return this.yesButton;
            }
        }

        /// <summary>
        /// Gets the No button.
        /// </summary>
        public Button NoButton
        {
            get
            {
                if (this.noButton == null)
                {
                    this.noButton = CreateCloseDialogButton(FirstFloor.ModernUI.Resources.No, false, true, MessageBoxResult.No);
                }
                return this.noButton;
            }
        }

        /// <summary>
        /// Gets the Close button.
        /// </summary>
        public Button CloseButton
        {
            get
            {
                if (this.closeButton == null)
                {
                    this.closeButton = CreateCloseDialogButton(FirstFloor.ModernUI.Resources.Close, true, false, MessageBoxResult.None);
                }
                return this.closeButton;
            }
        }

        public string Input
        {
            get { return ""; }
        }

        /// <summary>
        /// Gets or sets the background content of this window instance.
        /// </summary>
        public object BackgroundContent
        {
            get { return GetValue(BackgroundContentProperty); }
            set { SetValue(BackgroundContentProperty, value); }
        }

        /// <summary>
        /// Gets or sets the dialog buttons.
        /// </summary>
        public IEnumerable<Button> Buttons
        {
            get { return (IEnumerable<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        /// <summary>
        /// Gets the message box result.
        /// </summary>
        /// <value>
        /// The message box result.
        /// </value>
        public MessageBoxResult MessageBoxResult
        {
            get { return this.messageBoxResult; }
        }*/

        /// <summary>
        /// Displays a messagebox.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <param name="button">The button.</param>
        /// <param name="owner">The window owning the messagebox. The messagebox will be located at the center of the owner.</param>
        /// <returns></returns>
        public static string Show(string text, string title, Window owner = null)
        {
            StackPanel pnl = new StackPanel();
            TextBox t = new TextBox { Margin = new Thickness(0, 0, 0, 8) };
            BBCodeBlock blc = new BBCodeBlock { BBCode = text, Margin = new Thickness(0, 0, 0, 8) };
            pnl.Children.Add(blc);
            pnl.Children.Add(t);
            var dlg = new InputBox
            {
                Title = title,
                Content = pnl,
                MinHeight = 0,
                MinWidth = 0,
                MaxHeight = 480,
                MaxWidth = 640,
            };
            if (owner != null)
            {
                dlg.Owner = owner;
            }

            dlg.Buttons = new List<Button> { dlg.OkButton };
            dlg.ShowDialog();
            return t.Text;
        }

        
    }
}
