using StripsClientWPFStripView.Model;
using StripsClientWPFStripView.Services;
using System;
using System.Windows;

namespace StripsClientWPFStripView
{
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;

        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
        }

        private async void GetStripButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(StripIdTextBox.Text, out int stripId))
                {
                    Strip strip = await stripService.GetStrip(stripId);

                    TitelTextBox.Text = strip.Titel;
                    NrTextBox.Text = strip.Nr.ToString();
                    ReeksTextBox.Text = strip.Reeks;
                    UitgeverijTextBox.Text = strip.Uitgeverij;

                    AuteurListBox.Items.Clear();
                    foreach (string auteur in strip.Auteurs)
                    {
                        AuteurListBox.Items.Add(auteur);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid strip ID. Please enter a valid number.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}