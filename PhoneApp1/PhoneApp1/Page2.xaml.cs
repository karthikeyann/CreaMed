using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using System.Windows.Media;
using System.Threading;
//using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Tasks;

namespace PhoneApp1
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
            tappee();
            tuppee();
            R29.Fill = new SolidColorBrush(Colors.Purple);

        }


        private void tuppee()
        {
            R1.StrokeThickness /= 2;
            R2.StrokeThickness /= 2;
            R3.StrokeThickness /= 2;
            R4.StrokeThickness /= 2;
            R5.StrokeThickness /= 2;
            R6.StrokeThickness /= 2;
            R7.StrokeThickness /= 2;
            R8.StrokeThickness /= 2;
            R9.StrokeThickness /= 2;
            R10.StrokeThickness /= 2;
            R11.StrokeThickness /= 2;
            R12.StrokeThickness /= 2;
            R13.StrokeThickness /= 2;
            R14.StrokeThickness /= 2;
            R15.StrokeThickness /= 2;
            R16.StrokeThickness /= 2;
            R17.StrokeThickness /= 2;
            R18.StrokeThickness /= 2;
            R19.StrokeThickness /= 2;
            R20.StrokeThickness /= 2;
            R21.StrokeThickness /= 2;
            R22.StrokeThickness /= 2;
            R23.StrokeThickness /= 2;
            R24.StrokeThickness /= 2;
            R25.StrokeThickness /= 2;
            R26.StrokeThickness /= 2;
            R27.StrokeThickness /= 2;
            R28.StrokeThickness /= 2;
            R29.StrokeThickness /= 2;
            R30.StrokeThickness /= 2;
            R31.StrokeThickness /= 2;
            R32.StrokeThickness /= 2;
            R33.StrokeThickness /= 2;
            R34.StrokeThickness /= 2;
            R35.StrokeThickness /= 2;
        }

        private void tappee()
        {
            R1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R2.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R3.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R4.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R5.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R6.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R7.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R8.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R9.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R10.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R11.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R12.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R13.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R14.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R15.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R16.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R17.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R18.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R19.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R20.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R21.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R22.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R23.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R24.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            //R29.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black); --> Present date
            R26.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R27.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R28.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R25.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R30.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R31.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R32.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R33.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R34.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
            R35.Fill = new SolidColorBrush(System.Windows.Media.Colors.Black);
        }

        private void Grid_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R1.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            //TextBlock HorizontalAlignment="Left" Margin="429,32,0,0" TextWrapping="Wrap" Text="Sat" VerticalAlignment="Top" Grid.Row="1"/>
            R1.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "29th December 2013";

        }

        private void Grid_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R2.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R2.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "30th December 2013";
        }

        private void Grid_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R3.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R3.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "31st December 2013";
        }

        private void Grid_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R4.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R4.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "1st January 2014";
        }

        private void Grid_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R5.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R5.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "2nd January 2014";
        }

        private void Grid_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R6.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R6.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "3rd January 2014";
        }

        private void Grid_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R7.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R7.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "4th January 2014";
        }

        private void Grid_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R8.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R8.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "5th January 2014";
        }

        private void Grid_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R9.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R9.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "6th January 2014";
        }

        private void Grid_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R10.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R10.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "7th January 2014";
        }

        private void Grid_Tap_11(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R11.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R11.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "8th January 2014";
        }

        private void Grid_Tap_12(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R12.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R12.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "9th January 2014";
        }

        private void Grid_Tap_13(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R13.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R13.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "10th January 2014";
        }

        private void Grid_Tap_14(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R14.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R14.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "11th January 2014";
        }

        private void Grid_Tap_15(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R15.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R15.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "12th January 2014";
        }

        private void Grid_Tap_16(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R16.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R16.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "13th January 2014";
        }

        private void Grid_Tap_17(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R17.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R17.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "14th January 2014";
        }

        private void Grid_Tap_18(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R18.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R18.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "15th January 2014";
        }

        private void Grid_Tap_19(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R19.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R19.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "16th January 2014";
        }

        private void Grid_Tap_20(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R20.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R20.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "17th January 2014";
        }
        private void Grid_Tap_21(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R21.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R21.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "18th January 2014";
        }

        private void Grid_Tap_22(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R22.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R22.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "19th January 2014";
        }

        private void Grid_Tap_23(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R23.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R23.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "20th January 2014";
        }

        private void Grid_Tap_24(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R24.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R24.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "21st January 2014";
        }

        private void Grid_Tap_29(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R29.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R29.Fill = new SolidColorBrush(System.Windows.Media.Colors.Purple);
            Doctor.Text = "";
            MedA.Text = "Dolo 650mg";
            MedB.Text = "";
            Dates.Text = "26th January 2014";
        }

        private void Grid_Tap_26(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R26.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R26.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "23rd January 2014";
        }

        private void Grid_Tap_27(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R27.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R27.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "24th January 2014";
        }

        private void Grid_Tap_28(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R28.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R28.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "No Appointments Today";
            MedA.Text = "No medicines Today";
            MedB.Text = "";
            Dates.Text = "25th January 2014";
        }

        private void Grid_Tap_25(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R25.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R25.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "Dr. Saptarshi Prakash Cardio";
            MedA.Text = "No medicines today";
            MedB.Text = "";
            Dates.Text = "22nd January 2014";
        }

        private void Grid_Tap_30(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R30.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R30.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "";
            MedA.Text = "Disprin 300mg";
            MedB.Text = "Paracetamol 200mg";
            Dates.Text = "27th January 2014";
        }

        private void Grid_Tap_31(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R31.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R31.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "";
            MedA.Text = "Disprin 300mg";
            MedB.Text = "Paracetamol 200mg";
            Dates.Text = "28th January 2014";
        }

        private void Grid_Tap_32(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R32.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R32.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "Dr. Karthikeyan Ortho";
            MedA.Text = "Disprin 300mg";
            MedB.Text = "Paracetamol 200mg";
            Dates.Text = "29th January 2014";
        }

        private void Grid_Tap_33(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R33.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R33.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "";
            MedA.Text = "No medicines today";
            MedB.Text = "";
            Dates.Text = "30th January 2014";
        }

        private void Grid_Tap_34(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R34.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R34.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "";
            MedA.Text = "No medicines today";
            MedB.Text = "";
            Dates.Text = "31st January 2014";
        }

        private void Grid_Tap_35(object sender, System.Windows.Input.GestureEventArgs e)
        {
            tappee();
            R35.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            Thread.Sleep(100);
            R35.Fill = new SolidColorBrush(System.Windows.Media.Colors.DarkGray);
            Doctor.Text = "";
            MedA.Text = "No medicines today";
            MedB.Text = "";
            Dates.Text = "1st February 2014";
        }

        private void Pivot_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                /*Reminder remind1 = new Reminder("One");
                //Uri navigationUri = new Uri("/Reminder1.xaml", UriKind.Relative);
                remind1.Title = "Please take your Medicine now";
                remind1.Content = "Click to see which tablets";
                remind1.BeginTime = DateTime.Parse("26/01/2014 9:30:00");
                //remind1.ExpirationTime = DateTime.Parse("26/01/2014 9:45:00");
                //remind1.RecurrenceType = 0;
                //remind1.NavigationUri = navigationUri;

                // Register the reminder with the system.
                ScheduledActionService.Add(remind1);

                Reminder remind2 = new Reminder("Two");
                //Uri navigationUri = new Uri("/Reminder1.xaml", UriKind.Relative);
                remind2.Title = "Please take your Medicine now";
                remind2.Content = "Click to see which tablets";
                remind2.BeginTime = DateTime.Parse("26/01/2014 9:30:00");
                //remind1.ExpirationTime = DateTime.Parse("26/01/2014 9:45:00");
                //remind1.RecurrenceType = 0;
                //remind1.NavigationUri = navigationUri;

                // Register the reminder with the system.
                ScheduledActionService.Add(remind2);

                Reminder remind3 = new Reminder("Three");
                //Uri navigationUri = new Uri("/Reminder1.xaml", UriKind.Relative);
                remind3.Title = "Please take your Medicine now";
                remind3.Content = "Click to see which tablets";
                remind3.BeginTime = DateTime.Parse("26/01/2014 9:30:00");
                //remind1.ExpirationTime = DateTime.Parse("26/01/2014 9:45:00");
                //remind1.RecurrenceType = 0;
                //remind1.NavigationUri = navigationUri;

                // Register the reminder with the system.
                ScheduledActionService.Add(remind3);
                /*
                Reminder remind2 = new Reminder("Time for your medicine");
                Uri navigationUri2 = new Uri("/Reminder2.xaml", UriKind.Relative);
                remind2.Title = "Please take your Medicine now";
                remind2.Content = "Click to see which tablets";
                remind2.BeginTime = DateTime.Parse("26/01/2014 9:30:00");
                remind2.ExpirationTime = DateTime.Parse("26/01/2014 9:45:00");
                remind2.RecurrenceType = 0;
                remind2.NavigationUri = navigationUri2;

                // Register the reminder with the system.
                ScheduledActionService.Add(remind2);


                Reminder remind3 = new Reminder("Time for your medicine");
                Uri navigationUri3 = new Uri("/Reminder3.xaml", UriKind.Relative);
                remind3.Title = "Time for your Doctors Appointment";
                remind3.Content = "Click to see which tablets";
                remind3.BeginTime = DateTime.Parse("26/01/2014 9:30:00");
                remind3.ExpirationTime = DateTime.Parse("26/01/2014 9:45:00");
                remind3.RecurrenceType = 0;
                remind3.NavigationUri = navigationUri3;

                // Register the reminder with the system.
                ScheduledActionService.Add(remind3);*/
                SaveAppointmentTask saveAppointmentTask = new SaveAppointmentTask();

                saveAppointmentTask.StartTime = DateTime.Now.AddHours(0);
                saveAppointmentTask.EndTime = DateTime.Now.AddHours(1);
                saveAppointmentTask.Subject = "Doctors Name";
                saveAppointmentTask.Location = "Name of Tablet";
                saveAppointmentTask.Details = "Appointment details";
                saveAppointmentTask.IsAllDayEvent = false;
                saveAppointmentTask.Reminder = Reminder.FiveMinutes;
                saveAppointmentTask.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;

                saveAppointmentTask.Show();


            }
            catch (Exception ee)
            {
                System.Diagnostics.Debugger.Log(1, "Gen", "Hen");
            }
        }
    }
}