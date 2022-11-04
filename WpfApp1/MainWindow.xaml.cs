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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DiceInfo> diceInfoList = new List<DiceInfo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void rolledNum_Lost_Focus(object sender, RoutedEventArgs e)
        {
            string txt = rolledNum.Text.Trim();

            int.TryParse(txt, out int result);

            if (result <= 0)
            {
                MessageBox.Show("Please enter an integer");
            }
        }

        private void factorSel_Initialized(object sender, EventArgs e)
        {
            factorSel.Items.Add("1");
            factorSel.Items.Add("2"); 
            factorSel.Items.Add("3"); 
            factorSel.Items.Add("4");
            factorSel.Items.Add("5");
        }

        private void faceSel_Initialized(object sender, EventArgs e)
        {
            faceSel.Items.Add("1");
            faceSel.Items.Add("2");            
            faceSel.Items.Add("3");
            faceSel.Items.Add("4");
            faceSel.Items.Add("5");
            faceSel.Items.Add("6");
        }

        private void rollDice_Click(object sender, RoutedEventArgs e)
        {
            var face = (string)faceSel.SelectedItem;

            if (string.IsNullOrEmpty(face))
            {
                MessageBox.Show("Please select a face of dice.");
                return;
            }

            var factor = (string)factorSel.SelectedItem;

            if (string.IsNullOrEmpty(factor))
            {
                MessageBox.Show("Please select a factor.");
                return;
            }

            var rnum = rolledNum.Text;

            if (string.IsNullOrWhiteSpace(rnum))
            {
                MessageBox.Show("Please enter number of times dice will be rolled.");
                return;
            }

            if (!int.TryParse(rnum, out int irnum))
            {
                MessageBox.Show("Please enter a integer for number of times dice will be rolled.");
                return;
            }

            int iface = int.Parse(face);
            int ifactor = int.Parse(factor);

            RollDice rollDice = new RollDice(iface, ifactor, irnum);

            List<DiceInfo> lstDiceInfo = rollDice.RollMyCice();
            diceInfoList.AddRange(lstDiceInfo);

            lvHistory.ItemsSource = null;
            lvHistory.Items.Clear();
            lvHistory.ItemsSource = diceInfoList;
            lvHistory.SelectedIndex = 0;
            lvHistory.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lvHistory.ItemsSource = null;
            lvHistory.Items.Clear();
            diceInfoList.Clear();
        }
    }
}
