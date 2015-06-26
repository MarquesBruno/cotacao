using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Cotacao
{
    public partial class Sobre : PhoneApplicationPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            TxtSobre.Text = "Este aplicativo foi projetado para que todos possam converter valores em dollar para reais em segundos, de forma pratica e muito segura.  ";

        }

        private void appBarHelp_Click(object sender, EventArgs e)
        {
            Navigate("/Info.xaml");
        }

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void appBarLike_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void appBarEquip_Click(object sender, EventArgs e)
        {
            Navigate("/Equipe.xaml");
        }





    }
}