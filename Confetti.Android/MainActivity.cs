using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Github.Jinatonic.Confetti;
using Android.Graphics;
using Android.Views;
using Com.Github.Jinatonic.Confetti.Confetto;
using Java.Util;
using System.Collections.Generic;

namespace Confetti.Android
{
    [Activity(Label = "Confetti Effect", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        ViewGroup TopView;
        private List<ConfettiManager> ActiveConfettiManagers = new List<ConfettiManager>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource, and attach an event to it
            Button buttonOnce = FindViewById<Button>(Resource.Id.myButtonOnce);
            Button buttonStream = FindViewById<Button>(Resource.Id.myButtonStream);
            Button buttonInfinite = FindViewById<Button>(Resource.Id.myButtonInfinite);

            //Get our topview
            TopView = (ViewGroup)FindViewById(Android.Resource.Id.container);

            buttonOnce.Click += delegate { ActiveConfettiManagers.Add(GenerateStream(TopView, true)); };
            buttonStream.Click += delegate { ActiveConfettiManagers.Add(GenerateStreamWithDuration(TopView,5000)); };
            buttonInfinite.Click += delegate 
            {
                if (buttonInfinite.Text == "Infinite")
                {
                    buttonInfinite.Text = "Stop";
                    ActiveConfettiManagers.Add(GenerateStream(TopView));
                }
                else
                {
                    buttonInfinite.Text = "Infinite";
                    StopConfettiManagers();                   
                }

            };
         }

        private void StopConfettiManagers()
        {
            foreach (ConfettiManager confettiManager in ActiveConfettiManagers)
                confettiManager.Terminate();

            ActiveConfettiManagers.Clear();
        }
        private ConfettiManager GenerateStreamWithDuration(ViewGroup Container , int Duration = 3000)
        {

            var Colors = new int[] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.White, Color.Orange };
            return CommonConfetti.RainingConfetti(Container,Colors).Stream(Duration);
        }

        private ConfettiManager GenerateStream(ViewGroup Container , bool OneShot = false)
        {
            var Colors = new int[] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.White, Color.Orange };

            if(!OneShot)
                return CommonConfetti.RainingConfetti(Container, Colors).Infinite();

            return CommonConfetti.RainingConfetti(Container, Colors).OneShot();

        }
    }
}

