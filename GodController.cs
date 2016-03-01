using System;
using Foundation;
using UIKit;

namespace Smite
{
	partial class GodController : UIViewController
	{
        
		public GodController (IntPtr handle) : base (handle)
		{
            
		}


                    
       
        public override void ViewDidLoad(){
            base.ViewDidLoad();
           
            Controller.Instance.GodSelected += (object sender, Controller.GodSelectedEventArgs e) => {
                new UIAlertView("Alert", "event subscribed to", null, "OK", null).Show();
            };

            var tableViewController = new TableViewController();


           tableViewController.GodSelected += (object sender, TableViewController.GodSelectedEventArgs e) => {
                new UIAlertView("Alert", "event subscribed to", null, "OK", null).Show();

            };
        }


           



	}
}
