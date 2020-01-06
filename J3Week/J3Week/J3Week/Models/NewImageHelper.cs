using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace J3Week.Models
{
    class NewImageHelper
    {
        public static Dictionary<string, ImageSource> Images = new Dictionary<string, ImageSource>();

        public async Task<string> PromptGetImage(string Type)
        {
            if (Type.Equals("Take Photo"))
            {
                return await TakePhoto();
            }
            else
            {
                return await ChooseFromGallery();
            }
        }

        async Task<string> TakePhoto()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                Directory = "Camera.Images",
                Name = DateTime.Now + ".png",
                SaveToAlbum = true,
                CompressionQuality = 50,
                CustomPhotoSize = 40,
            });


            if (file != null)
            {
                string ID = Guid.NewGuid().ToString();
                Images.Add(ID, ImageSource.FromStream(() => file.GetStream()));
                return ID;
            }
            else
            {
                return null;
            }

           
        }


        #region TakePictureCommmand
        public ICommand TakePictureCommmand { get; set; }
        private async Task<string> TakePictureCommandExecute()
        {
            if (await CameraPermissionDenied())
            {
                await App.Current.MainPage.DisplayAlert("Notification", "You don't allowed.", "OK");
                CrossPermissions.Current.OpenAppSettings();
                return null;
            }

            if (await StoragePermissionDenied())
            {
                await App.Current.MainPage.DisplayAlert("Notification", "You don't allowed.", "OK");
                CrossPermissions.Current.OpenAppSettings();
                return null;
            }

            await CrossMedia.Current.Initialize();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Camera.Images",
                Name = DateTime.Now + ".png",
                SaveToAlbum = true,
                CompressionQuality = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Custom,
                CustomPhotoSize = 40,
            });

            if (file == null)
                return null;

            string ID = Guid.NewGuid().ToString();
            Images.Add(ID, file.Path);
            return ID;

        }
        #endregion

        #region CheckPermission
        private async Task<bool> StoragePermissionDenied()
        {
            Permission permission = Permission.Storage;

            var _storagePermission = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);

            if (_storagePermission == PermissionStatus.Granted)
            {
                return false;
            }
            else
            {
                var requestResponse = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                var userResponse = requestResponse[permission];

                if (userResponse == PermissionStatus.Granted)
                {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> CameraPermissionDenied()
        {
            Permission permission = Permission.Camera;

            var _cameraPermission = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);

            if (_cameraPermission == PermissionStatus.Granted)
            {
                return false;
            }
            else
            {
                var requestResponse = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                var userResponse = requestResponse[permission];

                if (userResponse == PermissionStatus.Granted)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion


        async Task<string> ChooseFromGallery()
        {
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });


            if (file != null)
            {
                string ID = Guid.NewGuid().ToString();
                Images.Add(ID, ImageSource.FromStream(() => file.GetStream()));
                return ID;
            }
            else
            {
                return null;
            }
        }
    }
}
