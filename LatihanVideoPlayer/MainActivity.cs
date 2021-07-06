using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Media;

namespace LatihanVideoPlayer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        VideoView videoView;
        MediaController mediaController;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            videoView = (VideoView)FindViewById(Resource.Id.videoView1);
            if (mediaController == null)
            {
                mediaController = new MediaController(this);
                mediaController.SetAnchorView(videoView);
            }
            videoView.SetMediaController(mediaController);
            MediaPlayer player = new MediaPlayer();
            Android.Net.Uri uri = Android.Net.Uri.Parse("android.resource://" + PackageName + "/" + Resource.Raw.mood);
            videoView.SetVideoURI(uri);
            videoView.Start();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}