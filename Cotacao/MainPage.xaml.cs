using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cotacao.Resources;
using Cotacao.Entidade;
using Newtonsoft.Json.Linq;
using Cotacao.Repositorio;


namespace Cotacao
{
    public partial class MainPage : PhoneApplicationPage
    {
        string variavel = "Cotacao";
       // Cota ObejtoCotacao = null;
        Cota CotaDoJson = null;
       // Cota pagina;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void ConsultarCota()
        {
            

            WebClient rssClient = new WebClient();

            
           // rssClient.DownloadStringCompleted += rssClient_DownloadStringCompleted;
            rssClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);

            //rssClient.DownloadStringCompleted +=
            //    new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);

            
            rssClient.DownloadStringAsync(new Uri(@"http://morpheu269.url.ph/" + variavel + ".json"));

        }





        void rssClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            double aux = 0;
            double resultado = 0;
            try
            {
                Cota cot = ParseJson(e.Result);
            }
            catch
            {
                MessageBox.Show("Sem Conexao com internet.");
                return;
            }
           // double valorDouble = Convert.ToDouble(CotaDoJson.indice);
            double valorDouble = CotaDoJson.indice;            
            //try
            //{
            if (TxtDolar.Text == "")
                TxtDolar.Text = "1";
            aux = Convert.ToDouble(TxtDolar.Text);
            resultado = valorDouble * aux;
            TxtResultado.Text = "R$ " + Convert.ToString(resultado);
            TxtAtual.Text = "Ultima Atualização " + CotaDoJson.data_consulta;
            TxtIndice.Text = "  US$ 1,00 = R$ " + valorDouble;
            //}
            //catch
            //{
            //    MessageBox.Show("Informe um valor");
            //    Navigate("/MainPage.xaml"); 

            //}


            //NavigationService.Navigate(new Uri("/Result.xaml", UriKind.Relative));

        }
        private Cota ParseJson(string pJson)
        {


            if (pJson != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(pJson);

                CotaDoJson = new Cota
                {
                    
                    indice = (double)jobject["indice"],
                    data_consulta = (string)jobject["atual"]
                };
                
               
            }
            return CotaDoJson;
        }
        






        #region Eventos




        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            //this.CotaDoJson = null;
            //e = null;
            //if(this.CotaDoJson!=null)
            //    MessageBox.Show("O CotaDoJson nao esta vazia.");
            //CotaRepositorio.Delete(CotaDoJson);
            //vamos acessar o web service
             ConsultarCota();
            
        }

        

        private void appBarFavoritos_Click(object sender, EventArgs e)
        {
            Navigate("/Favoritos.xaml");
        }

        #endregion

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }

        private void appBarAddFavoritos_Click(object sender, EventArgs e)
        {
            
            if (CotaDoJson != null)
            {

                CotaRepositorio.Create(CotaDoJson);
                Navigate("/Favoritos.xaml");
                MessageBox.Show("Favorito salvo com Sucesso.");

            }
            else
            {
                MessageBox.Show("Consulte para carregar os dados");
            }

        }

        private void appBarRefresh_Click(object sender, EventArgs e)
        {
           
            Navigate("/MainPage.xaml");
        }

     
        
   

    }
}