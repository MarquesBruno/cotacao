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
    public partial class Info : PhoneApplicationPage
    {
        public Info()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            TxtInfo1.Text = "Com este App o usuário poderá Converter valores de dollar para reais em segundos, atualizado diariamente através de sua internet.";
            TxtInfo.Text = "Abaixo segue os principais comandos :";

            TxtAbout.Text = "Entra na tela sobre o App;";
            TxtDelete.Text = "Após selecionar item, é excuido;";
            TxtEquipe.Text = "Equipe;";
            TxtAddFav.Text = "Adiciona Cotação para historico;";
            TxtFav.Text = "Encaminha para pagina Historico;";
            TxtHelp.Text = "Acessa a pagina de ajuda;";
            TxtAvalia.Text = "Avalia o App;";
            TxtRefresh.Text = "Recarrega pagina";

        }

        

        





    }
}