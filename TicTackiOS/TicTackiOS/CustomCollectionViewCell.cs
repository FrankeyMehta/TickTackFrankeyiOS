using CoreGraphics;
using Foundation;
using UIKit;

namespace TicTackiOS
{
    public class CustomCollectionViewCell : UICollectionViewCell
    {
        public UILabel mainLabel;
        public static NSString CellID = new NSString("CustomCollectionCell");

        [Export("initWithFrame:")]
        public CustomCollectionViewCell(CGRect frame) : base(frame)
        {
            ContentView.BackgroundColor = UIColor.White;
            mainLabel = new UILabel();
            ContentView.AddSubviews(new UIView[] { mainLabel });
        }

        public void UpdateCell(string text)
        {
            mainLabel.Text = text;
            mainLabel.Frame = ContentView.Bounds;
            mainLabel.Font = UIFont.SystemFontOfSize(30);
            mainLabel.TextAlignment = UITextAlignment.Center;
        }

    }
}