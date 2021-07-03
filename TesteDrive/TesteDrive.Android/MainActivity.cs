
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using System;
using System.IO;
using System.Threading.Tasks;
using TesteDrive.Droid;
using TesteDrive.Midia;
using TesteDrive.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TesteDrive.Droid
{
    [Activity(Label = "TesteDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        public object PhotoPath { get;  set; }

        

        protected override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);           
          

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            
            
        }

        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);


            
        
        }


       
        public async void TirarFoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                await LoadPhotoAsync(photo);
                             

            }
            catch (FeatureNotSupportedException fnsEX)
            {
                //Feature is now supported on the device
                var e = fnsEX.Message;
            }
            catch (PermissionException pEX)
            {
                var e = pEX.Message;
                //Permission not granted

            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {


            //canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;

            }

            //Save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            PhotoPath = newFile;
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;


        }
    }
}