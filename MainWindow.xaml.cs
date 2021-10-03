using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace TP2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)EncryptionComboBox.SelectedItem;
            string selectedText = cbi.Content.ToString();
            
            if (selectedText.Equals("Caesar"))
            {
                if ((bool)ConvertCheckBox.IsChecked)
                {
                    DecryptCaesar();
                }
                else
                {
                    CryptCaesar();
                }
            }
            
            if (selectedText.Equals("Boolean"))
            {
                if ((bool)ConvertCheckBox.IsChecked)
                {
                    DecryptBoolean();
                }
                else
                {
                    CryptBoolean();
                }
            }

            if (selectedText.Equals("Vignere"))
            {
                if ((bool)ConvertCheckBox.IsChecked)
                {
                    DecryptVignere();
                }
                else
                {
                    CryptVignere();
                }
            }

        }

        private static int CleCaesar = 3;

        private int Modulo(int x, int m)
        {
            return ((x % m + m) % m);
        }

        private void CryptCaesar()
        {

            string input = InputTextBox.Text;
            OutputTextBox.Text = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    int element = Modulo(input[i] - 97 + CleCaesar, 26) + 97;
                    OutputTextBox.Text += (char)element;
                }
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    int element = Modulo(input[i] - 65 + CleCaesar, 26) + 65;
                    OutputTextBox.Text += (char)element;
                }
                else
                {
                    OutputTextBox.Text += input[i];
                }
            }
        }
        private void DecryptCaesar()
        {
            string input = InputTextBox.Text;
            OutputTextBox.Text = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    int element = Modulo(input[i] - 97 - CleCaesar, 26) + 97;
                    OutputTextBox.Text += (char)element;
                }
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    int element = Modulo(input[i] - 65 - CleCaesar, 26) + 65;
                    OutputTextBox.Text += (char)element;
                }
                else
                {
                    OutputTextBox.Text += input[i];
                }
            }
        }

        private void CryptBoolean()
        {
            Trace.WriteLine("Bonjour crypt b");
        }

        private void DecryptBoolean()
        {
            Trace.WriteLine("Bonjour decrypt b");
        }

        private static string CleVignere = "bonjour".ToLower();
        private void CryptVignere()
        {
            string input = InputTextBox.Text;
            OutputTextBox.Text = "";

            for (int i = 0; i < input.Length; i++)
            {
                int clePos = CleVignere[i % CleVignere.Length] - 0;
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    int element = Modulo(input[i] - 97 + (clePos - 97), 26) + 97;
                    OutputTextBox.Text += (char)element;
                }
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    int element = Modulo(input[i] - 65 + (clePos - 97), 26) + 65;
                    OutputTextBox.Text += (char)element;
                }
                else
                {
                    OutputTextBox.Text += input[i];
                }
            }
        }

        private void DecryptVignere()
        {
            string input = InputTextBox.Text;
            OutputTextBox.Text = "";

            for (int i = 0; i < input.Length; i++)
            {
                int clePos = CleVignere[i % CleVignere.Length] - 0;
                if (input[i] >= 'a' && input[i] <= 'z')
                {
                    int element = Modulo(input[i] - 97 - (clePos - 97), 26) + 97;
                    OutputTextBox.Text += (char)element;
                }
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    int element = Modulo(input[i] - 65 - (clePos - 97), 26) + 65;
                    OutputTextBox.Text += (char)element;
                }
                else
                {
                    OutputTextBox.Text += input[i];
                }
            }
        }
    }
}
