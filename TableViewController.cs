using System;
using Foundation;
using UIKit;

using AMScrollingNavbar;

namespace Smite
{
partial class TableViewController : ScrollingNavigationTableViewController
{
    #region Name of Gods
   string [] gods =
        {"Agni", 
            "Ah Muzen Cab", 
            "Ah Puch",
            "Amaterasu", 
            "Anhur",
            "Anubis",
            "Ao Kuang",
            "Aphrodite",
            "Apollo",
            "Arachne",
            "Ares",
            "Artemis",
            "Athena",
            "Awilix",
            "Bacchus",
            "Bakasura",
            "Bastet",
            "Bellona",
            "Cabrakan",
            "Chaac",
            "Chang'e",
            "Chiron",
            "Chronos",
            "Cupid",
            "Fenrir",
            "Freya",
            "Geb",
            "Guan Yu",
            "Hades",
            "He Bo",
            "Hel",
            "Hercules",
            "Hou Yi",
            "Hun Batz",
            "Isis",
            "Janus",
            "Kali",
            "Khepri",
            "Kukulkan",
            "Kumbhakarna",
            "Loki",
            "Medusa",
            "Mercury",
            "Ne Zha",
            "Neith",
            "Nemesis",
            "Nox",
            "Nu Wa",
            "Odin",
            "Osiris",
            "Poseidon",
            "Ra",
            "Rama",
            "Ratatoskr",
            "Ravana",
            "Scylla",
            "Serqet",
            "Sobek",
            "Sol",
            "Sun Wukong",
            "Sylvanus",
            "Thanatos",
            "Thor",
            "Tyr",
            "Ullr",
            "Vamana",
            "Vulcan",
            "Xbalanque",
            "Xian Tian",
            "Ymir",
            "Zeus",
            "Zhong Kui"};
    #endregion

    #region Name of Pantheons
    public string [] pantheons = 
        
        {
            "Hindu" +
            "Mayan" +
            "Chinese" +
            "Japanese" +
            "Norse" +
            "Greek" +
            "Roman" +
            "Egyptian"
        };
    #endregion


    public TableViewController (IntPtr handle) : base (handle)
    {
        
    }
    public TableViewController(){

        
    }

    public  event EventHandler<GodSelectedEventArgs> GodSelected;

    public class GodSelectedEventArgs : EventArgs{
        public string godSelected { get; set; }

        public GodSelectedEventArgs(string GodSelected){
            this.godSelected = GodSelected;
        }
    }



    public override void ViewDidLoad ()
    {
        base.ViewDidLoad ();


        NavigationItem.RightBarButtonItem = new UIBarButtonItem (UIBarButtonSystemItem.Add);
        NavigationController.NavigationBar.BarTintColor = new UIColor (0.91f, 0.3f, 0.24f, 1.0f);
    }

    public override void ViewDidAppear (bool animated)
    {
        if (ScrollingNavigationController != null) {
            // Enable the navbar scrolling
            ScrollingNavigationController.FollowScrollView (TableView, 50.0);
        }
            
    }

    public override nint RowsInSection (UITableView tableView, nint section)
    {
        return gods.Length;
      
    }
   
     public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        new UIAlertView("Alert", "You touched " + gods[indexPath.Row], null, "OK", null).Show();

        tableView.DeselectRow(indexPath, true);

        if(GodSelected != null){
            GodSelected(this, new GodSelectedEventArgs(gods[indexPath.Row]));
        }

       
     }
            
    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
        var cell = TableView.DequeueReusableCell ("Cell");
        cell.TextLabel.Text = gods[indexPath.Row];
        cell.ImageView.Image = UIImage.FromFile("Gods/GodScreenPictures/" + indexPath.Row);
        cell.DetailTextLabel.Text = "Pantheon";
        return cell;
    }

}


}
