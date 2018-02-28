using System;

using UIKit;

namespace TicTackiOS
{
    public partial class ViewController : UIViewController
    {

        UICollectionViewFlowLayout flowLayout;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            var width = CollectionView.Bounds.Size.Width;
            var height = CollectionView.Bounds.Size.Height;

            flowLayout = new UICollectionViewFlowLayout()
            {
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                ScrollDirection = UICollectionViewScrollDirection.Vertical,
                ItemSize = new CoreGraphics.CGSize((width - 6) / 3, (height - 6) / 3),
                MinimumInteritemSpacing = 3,
                MinimumLineSpacing = 3
            };

            CollectionView.CollectionViewLayout = flowLayout;
            CollectionView.BackgroundColor = UIColor.Cyan;
            CollectionView.ContentInset = new UIEdgeInsets(0, 0, 0, 0);
            CollectionView.RegisterClassForCell(typeof(CustomCollectionViewCell), CustomCollectionViewCell.CellID);
            CollectionView.Source = new CustomCollectionSource();
            CollectionView.ReloadData(); 
        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void ButtonRestartGame_TouchUpInside(UIButton sender)
        {
            CollectionView.Source = new CustomCollectionSource();
            CollectionView.ReloadData();
        }
    }
}