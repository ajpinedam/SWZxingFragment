
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using ZXing.Mobile;

namespace SWZxingFragment
{
    public class Fragment2 : Fragment
    {
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Create your fragment here
        }

        public static Fragment2 NewInstance ()
        {
            var frag2 = new Fragment2 { Arguments = new Bundle () };
            return frag2;
        }


    public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        //var ignored = base.OnCreateView (inflater, container, savedInstanceState);

        var view = inflater.Inflate (Resource.Layout.fragment2_layout, container, false);

        //var app = new Android.App.Application ();

        Button scanBtn = view.FindViewById<Button> (Resource.Id.btnScann);
        TextView results = view.FindViewById<TextView> (Resource.Id.tvResults);

        scanBtn.Click += async (sender, e) => {

            MobileBarcodeScanner.Initialize (Activity.Application);

            var scanner = new MobileBarcodeScanner ();

            var result = await scanner.Scan ();

            if (result == null)
            {
                return;
            }

            Console.WriteLine ($"Scanned Barcode: {result}");

            Activity.RunOnUiThread (() => {
                Console.WriteLine ($"Activity.RunOnUiThread => Results: {result}");
                results.Text = result.Text;
            });

        };

        return view;
    }
    }
}
