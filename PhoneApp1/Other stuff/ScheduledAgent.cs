using Microsoft.Phone.Scheduler;
using Microsoft.Xna.Framework.Media;
using MyPhoneLockScreen.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyPhoneLockScreenHelperAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static Random randumNumber = new Random();
        private const string lockfileNameA = "LiveLockBackground_A.jpg";
        private const string lockfileNameB = "LiveLockBackground_B.jpg";

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            try
            {
                var isProvider = Windows.Phone.System.UserProfile.LockScreenManager.IsProvidedByCurrentApplication;
                if (isProvider)
                {
                    var setting = GetSetting();
                    if (RunNow(setting.Frequency))
                    {
                        IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;
                        if (iss.Contains("myPhoneLockScreenLockSettingsLastRun"))
                            iss.Remove("myPhoneLockScreenLockSettingsLastRun");
                        iss.Add("myPhoneLockScreenLockSettingsLastRun", DateTime.Now);
                        iss.Save();
                        var templates = GetTemplates();
                        var selectedTemplate = templates.Where(s => String.Equals(setting.Template, s.Name)).FirstOrDefault();
                        if (selectedTemplate == null)
                            selectedTemplate = templates.Where(s => String.Equals("Default", s.Name)).FirstOrDefault();

                        //Check for Album Selected
                        if (!String.IsNullOrEmpty(setting.Album))
                        {
                            //Check for Album
                            var ml = new MediaLibrary();
                            var album = GetAlbum(setting.Album, ml.RootPictureAlbum);
                            if (album != null)
                            {
                                //Check for Photos
                                List<Picture> pictures = new List<Picture>();
                                List<Picture> selectedPictures = new List<Picture>();

                                PopulatePictures(pictures, album, 3 * selectedTemplate.NoOfImages);
                                if (pictures.Count > 0)
                                {
                                    List<int> randomNumbers = new List<int>();
                                    var repeatCount = 0;
                                    while (randomNumbers.Count < selectedTemplate.NoOfImages)
                                    {
                                        repeatCount++;
                                        var nextNumber = randumNumber.Next(pictures.Count);
                                        if (!randomNumbers.Contains(nextNumber) || repeatCount > 3 * selectedTemplate.NoOfImages)
                                        {
                                            randomNumbers.Add(nextNumber);
                                        }
                                    }

                                    DynamicImageCanvas mainCanvas = null;
                                    bool isCompleted = false;

                                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                                    {
                                        var actualheight = Application.Current.Host.Content.ActualHeight;
                                        var actualwidth = Application.Current.Host.Content.ActualWidth + 100;

                                        actualheight = actualheight > 800 ? 800 : actualheight;
                                        actualwidth = actualwidth > 580 ? 580 : actualwidth;
                                        mainCanvas = new DynamicImageCanvas(actualheight, actualwidth);
                                        isCompleted = true;
                                    }
                                    );

                                    while (!isCompleted) ;

                                    var indexer = 0;
                                    for (int i = 0; i < selectedTemplate.NoOnVertical; ++i)
                                    {
                                        for (int j = 0; j < selectedTemplate.NoOnHorizontal; ++j)
                                        {
                                            isCompleted = false;
                                            Action<object> action = (object obj) =>
                                            {
                                                var data = obj as object[];
                                                TempPicture picture = (TempPicture)data[1];
                                                DynamicImageCanvas c = (DynamicImageCanvas)data[2];
                                                AddImageToCanvas((int)data[0], picture.Picture, picture.SelectedTemplate.NoOnVertical, picture.SelectedTemplate.NoOnHorizontal, picture.SelectedTemplate.NoOfImages, c, picture.PicturePlace);
                                                isCompleted = true;
                                            };
                                            TempPicture tpicture = new TempPicture();
                                            tpicture.Picture = pictures[randomNumbers[indexer]];
                                            tpicture.SelectedTemplate = selectedTemplate;
                                            tpicture.PicturePlace = new MyPhoneLockScreen.Model.Point(j, i);
                                            Task t1 = new Task(action, new object[] { indexer, tpicture, mainCanvas });
                                            t1.Start();
                                            while (true)
                                            {
                                                if (isCompleted)
                                                    break;
                                            }
                                            indexer++;
                                        }
                                    }

                                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                                    {
                                        try
                                        {
                                            string lockfileName;

                                            var currentImage = Windows.Phone.System.UserProfile.LockScreen.GetImageUri();

                                            if (currentImage.ToString().EndsWith(lockfileNameA))
                                            {
                                                lockfileName = lockfileNameB;
                                            }
                                            else
                                            {
                                                lockfileName = lockfileNameA;
                                            }

                                            Uri uri = new Uri(lockfileName, UriKind.Relative);

                                            // Create virtual store and file stream. Check for duplicate tempJPEG files.
                                            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                                            {
                                                if (myIsolatedStorage.FileExists(lockfileName))
                                                {
                                                    myIsolatedStorage.DeleteFile(lockfileName);
                                                }

                                                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(lockfileName))
                                                {
                                                    WriteableBitmap wb = new WriteableBitmap(mainCanvas, null);
                                                    wb.Invalidate();
                                                    // Encode WriteableBitmap object to a JPEG stream.
                                                    System.Windows.Media.Imaging.Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 100);

                                                    fileStream.Close();
                                                    mainCanvas.Clear();
                                                }
                                            }
                                            mainCanvas = null;

                                            GC.Collect();
                                            GC.WaitForPendingFinalizers();

                                            var schema = "ms-appdata:///Local/";
                                            var newUri = new Uri(schema + lockfileName, UriKind.Absolute);
                                            Windows.Phone.System.UserProfile.LockScreen.SetImageUri(newUri);
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.StackTrace);
                                        }
                                    });
                                }
                                else
                                {
                                    ShowPicture(setting);
                                }
                            }
                            else
                            {
                                ShowPicture(setting);
                            }
                        }
                        else
                        {
                            ShowPicture(setting);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            finally
            {
                //ScheduledActionService.LaunchForTest("MyPhoneLock-LockScreenChangerAgent", TimeSpan.FromSeconds(10));
                NotifyComplete();
            }
        }

        private bool RunNow(string frequency)
        {
            bool runNow = false;
            try
            {
                DateTime? lastRunTime = null;
                IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;
                iss.TryGetValue("myPhoneLockScreenLockSettingsLastRun", out lastRunTime);
                if (lastRunTime.HasValue)
                {
                    switch (frequency)
                    {
                        case ("1 Hrs"):
                            if (lastRunTime.Value.AddHours(1) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("3 Hrs"):
                            if (lastRunTime.Value.AddHours(3) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("6 Hrs"):
                            if (lastRunTime.Value.AddHours(6) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("Daily"):
                            if (lastRunTime.Value.AddDays(1) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("3 Days"):
                            if (lastRunTime.Value.AddDays(3) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("1 Week"):
                            if (lastRunTime.Value.AddDays(7) <= DateTime.Now)
                                runNow = true;
                            break;

                        case ("1 Month"):
                            if (lastRunTime.Value.AddMonths(1) <= DateTime.Now)
                                runNow = true;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    runNow = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return runNow;
        }

        private void ShowPicture(LockSettings setting)
        {
            if (String.IsNullOrEmpty(setting.PhotoPath))
                ShowDefaultImage();
            else
                ShowSelectedImage(setting.PhotoPath, setting.Photo);
        }

        private void ShowDefaultImage()
        {
            var schema = "ms-appx:///";
            string picturePath = "DefaultLockScreen.jpg";
            var uri = new Uri(schema + picturePath, UriKind.Absolute);
            Windows.Phone.System.UserProfile.LockScreen.SetImageUri(uri);
        }

        private PictureAlbum GetAlbum(PictureAlbum album, string albumName)
        {
            if (String.Equals(album.Name, albumName))
            {
                return album;
            }
            else
            {
                if (album.Albums.Count > 0)
                {
                    return album.Albums.Where(s => String.Equals(s.Name, albumName)).FirstOrDefault();
                }
                else
                    return null;
            }
        }

        private void AddImageToCanvas(int indexer, Picture picture, int noOnVertical, int noOnHorizontal, int maxCount, DynamicImageCanvas mainCanvas, MyPhoneLockScreen.Model.Point point)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            bool isCompleted = false;
            Deployment.Current.Dispatcher.BeginInvoke(() =>
                                    {
                                        try
                                        {
                                            var actualheight = Application.Current.Host.Content.ActualHeight;
                                            var actualwidth = Application.Current.Host.Content.ActualWidth;

                                            actualheight = actualheight > 800 ? 800 : actualheight;
                                            actualwidth = actualwidth > 480 ? 480 : actualwidth;

                                            //Create and save Dynamic Image

                                            var imageHeight = actualheight / noOnVertical;
                                            var imageWidth = actualwidth / noOnHorizontal;

                                            var left = (point.X * imageWidth) + (15 * point.X);
                                            var top = (point.Y * imageHeight) + (15 * point.Y);

                                            var image = new Image();
                                            var imag = new BitmapImage();
                                            imag.DecodePixelHeight = (int)imageHeight;
                                            imag.DecodePixelWidth = (int)imageWidth;
                                            imag.SetSource(picture.GetImage());
                                            image.Source = imag;
                                            image.Height = imageHeight;
                                            image.Width = imageWidth;
                                            mainCanvas.AddImage(image, left, top);
                                            image = null;
                                            imag = null;
                                        }
                                        catch (Exception ex)
                                        {
                                            Debug.WriteLine(ex.StackTrace);
                                        }
                                        finally
                                        {
                                            isCompleted = true;
                                        }
                                    });
            while (true)
            {
                if (isCompleted)
                    break;
            }
        }

        private void ShowSelectedImage(string picturePath, string pictureName)
        {
            var ml = new MediaLibrary();
            var fSplit = picturePath.Split('\\');
            PictureAlbum photoAlbum = null;
            for (int i = 0; i <= fSplit.Length - 2; ++i)
            {
                if (photoAlbum == null && !String.Equals(fSplit[i], ml.RootPictureAlbum.Name))
                    continue;
                photoAlbum = GetAlbum(ml.RootPictureAlbum, fSplit[i]);
            }
            if (photoAlbum != null)
            {
                var picture = photoAlbum.Pictures.Where(p => String.Equals(p.Name, pictureName)).FirstOrDefault();
                if (picture != null)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                                {
                                    try
                                    {
                                        //Save individual images

                                        var actualheight = Application.Current.Host.Content.ActualHeight;
                                        var actualwidth = Application.Current.Host.Content.ActualWidth;

                                        actualheight = actualheight > 800 ? 800 : actualheight;
                                        actualwidth = actualwidth > 480 ? 480 : actualwidth;

                                        //Create and save Dynamic Image
                                        DynamicImageCanvas canvas = new DynamicImageCanvas(actualheight, actualwidth);
                                        int left = 0;
                                        int top = 0;
                                        var image = new Image();
                                        var imag = new BitmapImage();
                                        imag.DecodePixelHeight = (int)actualheight;
                                        imag.DecodePixelWidth = (int)actualwidth;
                                        imag.SetSource(picture.GetImage());
                                        image.Source = imag;
                                        image.Height = actualheight;
                                        image.Width = actualwidth;

                                        canvas.AddImage(image, left, top);

                                        string lockfileName;

                                        var currentImage = Windows.Phone.System.UserProfile.LockScreen.GetImageUri();

                                        if (currentImage.ToString().EndsWith(lockfileNameA))
                                        {
                                            lockfileName = lockfileNameB;
                                        }
                                        else
                                        {
                                            lockfileName = lockfileNameA;
                                        }

                                        using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                                        {
                                            if (myIsolatedStorage.FileExists(lockfileName))
                                            {
                                                myIsolatedStorage.DeleteFile(lockfileName);
                                            }

                                            using (IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(lockfileName))
                                            {
                                                WriteableBitmap wb = new WriteableBitmap(canvas, null);

                                                // Encode WriteableBitmap object to a JPEG stream.
                                                System.Windows.Media.Imaging.Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);

                                                fileStream.Close();
                                            }
                                            canvas.Clear();
                                        }
                                        var schema = "ms-appdata:///Local/";
                                        var newUri = new Uri(schema + picture.Name, UriKind.Absolute);
                                        Windows.Phone.System.UserProfile.LockScreen.SetImageUri(newUri);
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine(ex.StackTrace);
                                    }
                                });
                }
                else
                    ShowDefaultImage();
            }
            else
                ShowDefaultImage();
        }

        private void PopulatePictures(List<Picture> pictures, PictureAlbum album, int maxCount)
        {
            if (album.Pictures.Count > 0)
            {
                foreach (var picture in album.Pictures)
                {
                    pictures.Add(picture);
                }
            }
            if (album.Albums.Count > 0)
            {
                foreach (var childAlbum in album.Albums)
                {
                    PopulatePictures(pictures, childAlbum, maxCount);
                }
            }
        }

        private PictureAlbum GetAlbum(string albumName, PictureAlbum album)
        {
            PictureAlbum foundAlbum = null;
            if (String.Equals(album.Name, albumName))
            {
                foundAlbum = album;
            }
            if (foundAlbum == null && album.Albums.Count > 0)
            {
                foreach (var childAlbum in album.Albums)
                {
                    foundAlbum = GetAlbum(albumName, childAlbum);
                    if (foundAlbum != null)
                        break;
                }
            }
            return foundAlbum;
        }

        private List<Template> GetTemplates()
        {
            List<Template> templates = new List<Template>();
            templates.Add(new Template(true));
            try
            {
                List<Template> temptemplates;
                IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;
                iss.TryGetValue("myPhoneLockScreenTemplates", out temptemplates);
                if(temptemplates != null)
                    templates.AddRange(temptemplates);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return templates;
        }

        private LockSettings GetSetting()
        {
            LockSettings setting = null;
            try
            {
                IsolatedStorageSettings iss = IsolatedStorageSettings.ApplicationSettings;
                iss.TryGetValue("myPhoneLockScreenLockSettings", out setting);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            return setting ?? new LockSettings() { Template = "Default", Photo = "DefaultLockScreen", Frequency = "Daily" };
        }
    }
}