using UIKit;
using System;
using CoreGraphics;
using Foundation;

namespace TicTackiOS
{
    public class CustomCollectionSource : UICollectionViewSource
    {
        Counter Game;

        public CustomCollectionSource()
        {
            Game = new Counter();
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 9;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CustomCollectionViewCell)collectionView.DequeueReusableCell(CustomCollectionViewCell.CellID, indexPath);
            int index = indexPath.Row;

            cell.UpdateCell(getValueFromBoard(Game.CurrentBoard.m_Values[index]));
            return cell;
        }
        
        string getValueFromBoard(ValeCell obj)
        {
            string retVal = "";
            switch (obj)
            {
                case ValeCell.Empty:
                    retVal = "";
                    break;
                case ValeCell.PlayerO:
                    retVal = "O";
                    break;
                case ValeCell.PlayerX:
                    retVal = "X";
                    break;
                default:
                    break;
            }
            return retVal;
        }
       [Export("collectionView:didSelectItemAtIndexPath:")]
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            try
            {
                
                Game.MakeMoveUser(indexPath.Row);
                if (Game.CurrentBoard.GameOver)
                {
                    MessageBox("Game Over", string.Format("Winner Player {0}", getValueFromBoard(Game.CurrentBoard.m_Winner)));
                }
                collectionView.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox("Error", string.Format(ex.Message));
            }
        }
        public void MessageBox(string title, string message)
        {
            using (UIAlertView Alert = new UIAlertView())
            {
                Alert.Title = title;
                Alert.Message = message;
                Alert.AddButton("Play Again");
                Alert.Show();
            }

        }
    }
}