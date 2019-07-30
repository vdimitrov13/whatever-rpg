namespace WERPG
{
    using System.Windows;
    using WhateverRPGEngine.Models;
    using WhateverRPGEngine.ViewModels;

    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSession Session => DataContext as GameSession;

        public TradeScreen()
        {
            InitializeComponent();
        }

        protected void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null)
            {
                Session.CurrentPlayer.Gold += item.Price;
                Session.CurrentTrader.AddItemToInventory(item);
                Session.CurrentPlayer.RemoveItemFromInventory(item);
            }
        }

        protected void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null)
            {
                if (Session.CurrentPlayer.Gold >= item.Price)
                {
                    Session.CurrentPlayer.Gold -= item.Price;
                    Session.CurrentTrader.RemoveItemFromInventory(item);
                    Session.CurrentPlayer.AddItemToInventory(item);
                }
                else
                {
                    MessageBox.Show("You do not have enough gold");
                }
            }
        }

        protected void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
