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
using System.Windows.Shapes;

namespace FireDepartmentApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectoryWindow.xaml
    /// </summary>
    public partial class DirectoryWindow : Window
    {
        public DirectoryWindow()
        {
            InitializeComponent();
        }

        private void BtnSettlement_Click(object sender, RoutedEventArgs e)
        {
            SettlemetsWindow settlemetsWindow = new SettlemetsWindow();
            settlemetsWindow.ShowDialog();
        }

        private void BtnStreet_Click(object sender, RoutedEventArgs e)
        {
            StreetWindow streetWindow = new StreetWindow();
            streetWindow.ShowDialog();
        }

        private void BtnBurn_Click(object sender, RoutedEventArgs e)
        {
            BurnTypeWindow burnTypeWindow = new BurnTypeWindow();
            burnTypeWindow.ShowDialog();
        }

        private void BtnMissionType_Click(object sender, RoutedEventArgs e)
        {
            MissionTypeWindow missionTypeWindow = new MissionTypeWindow();
            missionTypeWindow.ShowDialog();
        }

        private void BtnWorkArea_Click(object sender, RoutedEventArgs e)
        {
            WorkAreaWindow workAreaWindow = new WorkAreaWindow();
            workAreaWindow.ShowDialog();
        }

        private void BtnSteamType_Click(object sender, RoutedEventArgs e)
        {
            BarrelTypeWindow barrelTypeWindow = new BarrelTypeWindow();
            barrelTypeWindow.ShowDialog();
        }

        private void BtnCombatArea_Click(object sender, RoutedEventArgs e)
        {
            CombatAreaWindow combatAreaWindow = new CombatAreaWindow();
            combatAreaWindow.ShowDialog();
        }

        private void BtnServiceType_Click(object sender, RoutedEventArgs e)
        {
            ServiceTypeWindow serviceTypeWindow = new ServiceTypeWindow();
            serviceTypeWindow.ShowDialog();
        }

        private void BtnPostionType_Click(object sender, RoutedEventArgs e)
        {
            PositionTypeWindow positionTypeWindow = new PositionTypeWindow();
            positionTypeWindow.ShowDialog();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnDivision_Click(object sender, RoutedEventArgs e)
        {
            DivisionWindow divisionWindow = new DivisionWindow();
            divisionWindow.ShowDialog();
        }

        private void BtnTechnic_Click(object sender, RoutedEventArgs e)
        {
            TechnicWindow technicWindow = new TechnicWindow();
            technicWindow.ShowDialog();
        }

        private void BtnCombatDepForce_Click(object sender, RoutedEventArgs e)
        {
            CombatDepForceWindow combatDepForceWindow = new CombatDepForceWindow();
            combatDepForceWindow.ShowDialog();
        }

        private void BtnAlignmentForce_Click(object sender, RoutedEventArgs e)
        {
            AlignmentFoceWindow alignmentFoce = new AlignmentFoceWindow();
            alignmentFoce.ShowDialog();
        }
    }
}
