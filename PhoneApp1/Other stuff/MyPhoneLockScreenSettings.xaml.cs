using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using MyPhoneLockScreen.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MyPhoneLockScreen
{
    public partial class MyPhoneLockScreenSettings : PhoneApplicationPage
    {
        private Popup p = new Popup();
        private PeriodicTask periodicTask;

        private string periodicTaskName = "MyPhoneLock-LockScreenChangerAgent";

        private void RemoveAgent(string name)
        {
            try
            {
                ScheduledActionService.Remove(name);
            }
            catch (Exception)
            {
            }
        }

        private void StartPeriodicAgent()
        {
            // Obtain a reference to the period task, if one exists
            periodicTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;

            // If the task already exists and background agents are enabled for the
            // application, you must remove the task and then add it again to update
            // the schedule
            if (periodicTask != null)
            {
                RemoveAgent(periodicTaskName);
            }

            periodicTask = new PeriodicTask(periodicTaskName);

            // The description is required for periodic agents. This is the string that the user
            // will see in the background services Settings page on the device.
            periodicTask.Description = "MyPhoneLockScreen Background Task for Setting Lock Screen Image";

            // Place the call to Add in a try block in case the user has disabled agents.
            try
            {
                ScheduledActionService.Add(periodicTask);

                // If debugging is enabled, use LaunchForTest to launch the agent in one 5 seconds.
                ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(5));
            }
            catch (InvalidOperationException exception)
            {
                if (exception.Message.Contains("BNS Error: The action is disabled"))
                {
                    MessageBox.Show("Background agents for this application have been disabled by the user.");
                }

                if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                {
                    // No user action required. The system prompts the user when the hard limit of periodic tasks has been reached.
                }
            }
            catch (SchedulerServiceException)
            {
                // No user action required.
            }
        }

        public MyPhoneLockScreenSettings()
        {
            InitializeComponent();
            this.BackKeyPress += MyPhoneLockScreenSettings_BackKeyPress;
        }

        private async void MyPhoneLockScreenSettings_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
            Application.Current.Terminate();
        }

        private async void DoneTemplate_Click(object sender, EventArgs e)
        {
            var vm = this.DataContext as MyPhoneLockScreen.ViewModel.TemplateViewModel;
            vm.SaveSetting();
            StartPeriodicAgent();
            try
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-lock:"));
                Application.Current.Terminate();
            }
            catch (Exception)
            {
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            e.Cancel = true;
        }

        private void Album_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.ApplicationBar.IsVisible = false;

            var actualheight = Application.Current.Host.Content.ActualHeight;
            var actualwidth = Application.Current.Host.Content.ActualWidth;

            ChoosePhotoAlbum albumChooser = new ChoosePhotoAlbum();
            albumChooser.ButtonClick += (s, args) => { p.IsOpen = false; this.ApplicationBar.IsVisible = true; };
            albumChooser.ListItemSelected += (s, args) =>
            {
                p.IsOpen = false;
                Album.Text = args.Data;
                Album.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.ApplicationBar.IsVisible = true;
            };

            albumChooser.DataContext = new ChooseAlbumViewModel();

            albumChooser.Height = actualheight;
            albumChooser.Width = actualwidth;

            albumChooser.Margin = new Thickness(10, 10, 10, 10);

            albumChooser.Background = new SolidColorBrush(Colors.LightGray);

            p.Child = albumChooser;

            p.VerticalOffset = 0;
            p.HorizontalOffset = 0;

            p.IsOpen = true;
        }

        private void Frequency_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.ApplicationBar.IsVisible = false;

            var actualheight = Application.Current.Host.Content.ActualHeight;
            var actualwidth = Application.Current.Host.Content.ActualWidth;

            ChooseFrequency albumChooser = new ChooseFrequency();
            albumChooser.ButtonClick += (s, args) => { p.IsOpen = false; this.ApplicationBar.IsVisible = true; };
            albumChooser.ListItemSelected += (s, args) =>
            {
                p.IsOpen = false;
                Frequency.Text = args.Data;
                Frequency.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.ApplicationBar.IsVisible = true;
            };

            albumChooser.DataContext = new ChooseFrequencyViewModel();

            albumChooser.Height = actualheight;
            albumChooser.Width = actualwidth;

            albumChooser.Margin = new Thickness(10, 10, 10, 10);

            albumChooser.Background = new SolidColorBrush(Colors.LightGray);

            p.Child = albumChooser;

            p.VerticalOffset = 0;
            p.HorizontalOffset = 0;

            p.IsOpen = true;
        }

        private void Template_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.ApplicationBar.IsVisible = false;

            var actualheight = Application.Current.Host.Content.ActualHeight;
            var actualwidth = Application.Current.Host.Content.ActualWidth;

            var albumChooser = new ChooseTemplate();
            albumChooser.ButtonClick += (s, args) => { p.IsOpen = false; this.ApplicationBar.IsVisible = true; };
            albumChooser.ListItemSelected += (s, args) =>
            {
                p.IsOpen = false;
                LockTemplate.Text = args.Data;
                LockTemplate.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                this.ApplicationBar.IsVisible = true;
            };

            albumChooser.DataContext = new ChooseTemplateViewModel();

            albumChooser.Height = actualheight;
            albumChooser.Width = actualwidth;

            albumChooser.Margin = new Thickness(10, 10, 10, 10);

            albumChooser.Background = new SolidColorBrush(Colors.LightGray);

            p.Child = albumChooser;

            p.VerticalOffset = 0;
            p.HorizontalOffset = 0;

            p.IsOpen = true;
        }

        private void Photo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += photoChooserTask_Completed;
            photoChooserTask.Show();
        }

        private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                PhotoPath.Text = e.OriginalFileName;
                var fSplit = e.OriginalFileName.Split('\\');
                Photo.Text = fSplit[fSplit.Length - 1];
                Photo.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                PhotoPath.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }
    }
}