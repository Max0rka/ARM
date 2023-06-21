using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FireDepartmentApp.Entities;
using FireDepartmentApp.Windows.AddOrEditWindow;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Management.Instrumentation;

namespace FireDepartmentApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDeparturePage.xaml
    /// </summary>
    public partial class AddDeparturePage : Page
    {
        // текущий вызов
        public Departure _currentDeparture = new Departure();
        // выбранный район вызова
        DepartureArea selectedDepartureArea = new DepartureArea();

        List<BurnType> selectedBurns = new List<BurnType>();
        List<ServiceType> selectedServices = new List<ServiceType>();
        List<PositionType> selectedPositions = new List<PositionType>();


        public AddDeparturePage(Departure departure)
        {
            InitializeComponent();           
            if (departure != null)
            {
                _currentDeparture = departure;
                _currentDeparture.Settlement = departure.DepartureArea.Settlement;
                //DateDepart.SelectedDate = TimeDepart.SelectedTime = departure.DateTimeDepart;
            }              
            else
            {
                _currentDeparture.DateTimeDepart = DateTime.Now;

            }
            DataContext = _currentDeparture;
        }

        private void ComboBoxSettlement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColorZoneDateTime.IsEnabled = true;
            ComboBoxDepArea.IsEnabled = true;
            int settlementId = ((int)((ComboBoxSettlement.SelectedItem as Settlement)?.SettlementId));
            ComboBoxDepArea.ItemsSource = FireDepartEntities.GetContext().DepartureAreas.Where(p => p.SettlementId == settlementId).ToList();
            if (_currentDeparture.DepartureId == 0)
            {
                _currentDeparture.DateTimeDepart = DateTime.Now;
                TimeDepart.SelectedTime = DateTime.Now;
                DateDepart.SelectedDate = DateTime.Now;
            }
        }
        private void ComboBoxDepArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (ComboBoxDepArea.SelectedItem is DepartureArea departureArea)
            {                
                selectedDepartureArea = departureArea;
                               
                LoadSubdivisionInfo();
                //LoadUpdatedInfo();
                
                //if (_currentDeparture.DepartureId != 0)
                //{


                //}
                //else
                //{
                //    // 1 ранг пожара
                //    ListViewRank.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 1 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //    // 1 Бис ранг пожара
                //    ListViewRank1.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 2 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //    // 2 ранг пожара
                //    ListViewRank2.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 3 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //    // 3 ранг пожара
                //    ListViewRank3.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 4 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //    // 4 ранг пожара
                //    ListViewRank4.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 5 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //    // 5 ранг пожара
                //    ListViewRank5.ItemsSource = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 6 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                //}


                ColorZoneRank.Visibility = ListViewRank.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                ColorZoneRank1.Visibility = ListViewRank1.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                ColorZoneRank2.Visibility = ListViewRank2.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                ColorZoneRank3.Visibility = ListViewRank3.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                ColorZoneRank4.Visibility = ListViewRank4.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                ColorZoneRank5.Visibility = ListViewRank5.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                BtnAddFireInfo.Visibility = Visibility.Visible;

                // иные службы
                ListViewServiceTypes.ItemsSource = FireDepartEntities.GetContext().ServiceTypes.ToList();
                ColorZoneServiceType.Visibility = ListViewServiceTypes.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

                // должностные лица
                ListViewPositionTypes.ItemsSource = FireDepartEntities.GetContext().PositionTypes.ToList();
                ColorZonePositionType.Visibility = ListViewPositionTypes.Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

                // привлеченная техника
                ListViewDepTechnics.ItemsSource = FireDepartEntities.GetContext().Technics.ToList();

                // общая информация
                ColorZoneGeneralInfo.Visibility = Visibility.Visible;
            }
            else
            {
                ColorZoneRank.Visibility = Visibility.Collapsed;
                ColorZoneRank1.Visibility = Visibility.Collapsed;
                ColorZoneRank2.Visibility = Visibility.Collapsed;
                ColorZoneRank3.Visibility = Visibility.Collapsed;
                ColorZoneRank4.Visibility = Visibility.Collapsed;
                ColorZoneRank5.Visibility = Visibility.Collapsed;
                ColorZoneServiceType.Visibility = Visibility.Collapsed;
                ColorZonePositionType.Visibility = Visibility.Collapsed;
                ColorZoneGeneralInfo.Visibility = Visibility.Collapsed;
            }
                

        }
        public void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {        
            try
            {
                Manager.IsOpenAddPage = true;
                ComboBoxSettlement.ItemsSource = FireDepartEntities.GetContext().Settlements.OrderBy(p => p.SettlementName).ToList();
                ComboBoxStreet.ItemsSource = FireDepartEntities.GetContext().Streets.OrderBy(p => p.StreetName).ToList();
                Manager.AddDeparturePage = this;
                
                if (Manager.IsDirectory)
                {
                    Manager.IsDirectory = false;
                    ComboBoxBurns.ItemsSource = FireDepartEntities.GetContext().BurnTypes.ToList();
                    ListViewServiceTypes.ItemsSource = FireDepartEntities.GetContext().ServiceTypes.ToList();
                    ListViewPositionTypes.ItemsSource = FireDepartEntities.GetContext().PositionTypes.ToList();
                }
                else
                {
                    // очистка данных привлеченной техники
                    FireDepartEntities.GetContext().Technics.ForEachAsync(p => p.TechnicCountGeneral = 0).Wait();
                    // очистка данных всей привлеченной техники и л.с.
                    ServiceType.TechnicCountGeneral = 0;
                    ServiceType.PeopleCountGeneral = 0;
                    Technic.AllTechnicCount = 0;
                    Subdivision.PeopleCountGeneral = 0;
                    PositionType.PeopleCountGeneral = 0;
                    TbGeneralCountPeople.Text = "";
                    TbGeneralCountTechnic.Text = "";
                    TbMCSCountPeople.Text = "";
                    TbMCSCountTechnic.Text = "";
                    // очистка данных от прошлого района выезда
                    if (_currentDeparture.DepartureId == 0)
                    {
                        FireDepartEntities.GetContext().BurnTypes.ForEachAsync(p => p.BurnSelected = false).Wait();
                        ComboBoxBurns.ItemsSource = FireDepartEntities.GetContext().BurnTypes.ToList();
                        FireDepartEntities.GetContext().ServiceTypes.ForEachAsync(p =>
                        {
                            p.DepartureChecked = false;
                            p.ArrivalChecked = false;
                            p.TechnicCount = 0;
                            p.PeopleCount = 0;
                        }).Wait();

                        ListViewServiceTypes.ItemsSource = FireDepartEntities.GetContext().ServiceTypes.ToList();
                        FireDepartEntities.GetContext().PositionTypes.ForEachAsync(p =>
                        {
                            p.ArrivalChecked = false;
                        }).Wait();
                        ListViewPositionTypes.ItemsSource = FireDepartEntities.GetContext().PositionTypes.ToList();
                        FireDepartEntities.GetContext().Technics.ForEachAsync(p => p.TechnicCountGeneral = 0).Wait();
                        ListViewDepTechnics.Items.Refresh();
                    }

                    LoadInfo();
                    LoadSubdivisionInfo();
                    LoadUpdatedInfo();
                }
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }

        }

        private void CheckBoxArrival_Checked(object sender, RoutedEventArgs e)
        {
            Subdivision subdivision = ((CheckBox)sender).DataContext as Subdivision;
            subdivision.TimeArrival = DateTime.Now;
            switch (subdivision.FireRank)
            {
                case 1:
                    ListViewRank.Items.Refresh();
                    break;
                case 2:
                    ListViewRank1.Items.Refresh();
                    break;
                case 3:
                    ListViewRank2.Items.Refresh();
                    break;
                case 4:
                    ListViewRank3.Items.Refresh();
                    break;
                case 5:
                    ListViewRank4.Items.Refresh();
                    break;
                case 6:
                    ListViewRank5.Items.Refresh();
                    break;
                default:
                    break;
            }
            subdivision.Technic.TechnicCountGeneral += 1;
            Technic.AllTechnicCount += 1;
            TbMCSCountTechnic.Text = Technic.AllTechnicCount.ToString();
            TbGeneralCountTechnic.Text = (ServiceType.TechnicCountGeneral + Technic.AllTechnicCount).ToString();
            ListViewDepTechnics.Items.Refresh();
        }
        private void CheckBoxArrival_Unchecked(object sender, RoutedEventArgs e)
        {
            Subdivision subdivision = ((CheckBox)sender).DataContext as Subdivision;
            subdivision.Technic.TechnicCountGeneral -= 1;
            Technic.AllTechnicCount -= 1;
            TbMCSCountTechnic.Text = Technic.AllTechnicCount.ToString();
            TbGeneralCountTechnic.Text = (ServiceType.TechnicCountGeneral + Technic.AllTechnicCount).ToString();
            ListViewDepTechnics.Items.Refresh();
            Subdivision.PeopleCountGeneral -= subdivision.PeopleCount;
            subdivision.PeopleCount = 0;
            TbMCSCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral).ToString();
            TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
            switch (subdivision.FireRank)
            {
                case 1:
                    ListViewRank.Items.Refresh();
                    break;
                case 2:
                    ListViewRank1.Items.Refresh();
                    break;
                case 3:
                    ListViewRank2.Items.Refresh();
                    break;
                case 4:
                    ListViewRank3.Items.Refresh();
                    break;
                case 5:
                    ListViewRank4.Items.Refresh();
                    break;
                case 6:
                    ListViewRank5.Items.Refresh();
                    break;
                default:
                    break;
            }
        }
        private void CheckBoxDepart_Checked(object sender, RoutedEventArgs e)
        {
            
            Subdivision subdivision = ((CheckBox)sender).DataContext as Subdivision;
            subdivision.TimeDeparture = DateTime.Now;
            switch (subdivision.FireRank)
            {
                case 1:
                    ListViewRank.Items.Refresh();
                    break;
                case 2:
                    ListViewRank1.Items.Refresh();
                    break;
                case 3:
                    ListViewRank2.Items.Refresh();
                    break;
                case 4:
                    ListViewRank3.Items.Refresh();
                    break;
                case 5:
                    ListViewRank4.Items.Refresh();
                    break;
                case 6:
                    ListViewRank5.Items.Refresh();
                    break;
                default:
                    break;
            }
        }
        private void TbPeopleCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string peopleText = textBox.Text.Replace(" ", "").Replace("-", "");
            if (peopleText != null && peopleText.Length > 0)
            {
                short peopleCount = short.Parse(peopleText);

                if (textBox.DataContext is Subdivision subdivision)
                {
                    Subdivision.PeopleCountGeneral = (Subdivision.PeopleCountGeneral - subdivision.PeopleCount + peopleCount);
                    subdivision.PeopleCount = peopleCount;
                    TbMCSCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral).ToString();
                    TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
                }
                else if (textBox.DataContext is ServiceType serviceType)
                {
                    ServiceType.PeopleCountGeneral = ServiceType.PeopleCountGeneral - serviceType.PeopleCount + peopleCount;
                    serviceType.PeopleCount = peopleCount;
                    TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
                }
            }
        }
        private void TbPeopleCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsNumber(e.Text, 0);
            
        }
        private void TbTechnicCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string technicText = textBox.Text.Replace(" ", "").Replace("-", "");
            if (technicText != null && technicText.Length > 0)
            {
                short technicCount = short.Parse(technicText);
                if (textBox.DataContext is ServiceType serviceType)
                {
                    ServiceType.TechnicCountGeneral = ServiceType.TechnicCountGeneral - serviceType.TechnicCount + technicCount;
                    serviceType.TechnicCount = technicCount;
                    TbGeneralCountTechnic.Text = (ServiceType.TechnicCountGeneral + Technic.AllTechnicCount).ToString();
                }
            }
        }
        private void TbTechnicCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsNumber(e.Text, 0);
            
        }

        private void CheckBoxDepartService_Checked(object sender, RoutedEventArgs e)
        {
            ServiceType serviceType = ((CheckBox)sender).DataContext as ServiceType;
            serviceType.TimeDeparture = DateTime.Now;
            ListViewServiceTypes.Items.Refresh();
        }

        private void CheckBoxArrivalService_Checked(object sender, RoutedEventArgs e)
        {
            ServiceType serviceType = ((CheckBox)sender).DataContext as ServiceType;
            serviceType.TimeArrival = DateTime.Now;
            ListViewServiceTypes.Items.Refresh();
        }
        private void CheckBoxArrivalService_Unchecked(object sender, RoutedEventArgs e)
        {
            ServiceType serviceType = ((CheckBox)sender).DataContext as ServiceType;
            ServiceType.PeopleCountGeneral -= serviceType.PeopleCount;
            ServiceType.TechnicCountGeneral -= serviceType.TechnicCount;
            serviceType.PeopleCount = 0;
            serviceType.TechnicCount = 0;
            TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
            TbGeneralCountTechnic.Text = (ServiceType.TechnicCountGeneral + Technic.AllTechnicCount).ToString();
            ListViewServiceTypes.Items.Refresh();
        }
        private void CheckBoxArrivalPosition_Checked(object sender, RoutedEventArgs e)
        {
            PositionType positionType = ((CheckBox)sender).DataContext as PositionType;
            positionType.TimeArrival = DateTime.Now;
            PositionType.PeopleCountGeneral += 1;
            TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
            TbMCSCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral).ToString();
            ListViewPositionTypes.Items.Refresh();
        }
        private void CheckBoxArrivalPosition_Unchecked(object sender, RoutedEventArgs e)
        {
            PositionType positionType = ((CheckBox)sender).DataContext as PositionType;
            PositionType.PeopleCountGeneral -= 1;
            TbGeneralCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral).ToString();
            TbMCSCountPeople.Text = (PositionType.PeopleCountGeneral + Subdivision.PeopleCountGeneral).ToString();
        }

        private void CheckBoxFireEnd_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerFireEnd.SelectedDate = TimePickerFireEnd.SelectedTime = DateTime.Now;   
               
        }

        private void CheckBoxOpenFire_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerOpenFire.SelectedDate = TimePickerOpenFire.SelectedTime = DateTime.Now;
        }

        private void CheckBoxAftermathFire_Checked(object sender, RoutedEventArgs e)
        {
            DatePickerAftermathFire.SelectedDate = TimePickerAftermathFire.SelectedTime = DateTime.Now;
        }
        public void SaveInfo()
        {
            try
            {
                if (ComboBoxSettlement.SelectedItem == null)
                    throw new Exception("Выберите населенный пункт");
                if (ComboBoxDepArea.SelectedItem == null)
                    throw new Exception("Выберите район выезда");
                if (ComboBoxStreet.SelectedItem == null)
                    throw new Exception("Выберите улицу");
                // список объектов горения
                List<BurnType> burnTypes = ComboBoxBurns.Items.Cast<BurnType>().Where(p => p.BurnSelected).ToList();

                SaveUpdatedInfo();

                // прибывшие подразделения 1 ранга пожара
                List<Subdivision> subdivisionsRank = ListViewRank.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 1 БИС ранга пожара
                List<Subdivision> subdivisionsRank1 = ListViewRank1.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 2 ранга пожара
                List<Subdivision> subdivisionsRank2 = ListViewRank2.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 3 ранга пожара
                List<Subdivision> subdivisionsRank3 = ListViewRank3.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 4 ранга пожара
                List<Subdivision> subdivisionsRank4 = ListViewRank4.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 5 ранга пожара
                List<Subdivision> subdivisionsRank5 = ListViewRank5.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();

                // прибывшие подразделения общее
                List<Subdivision> generalSubdivisions = new List<Subdivision>();
                generalSubdivisions.AddRange(subdivisionsRank);
                generalSubdivisions.AddRange(subdivisionsRank1);
                generalSubdivisions.AddRange(subdivisionsRank2);
                generalSubdivisions.AddRange(subdivisionsRank3);
                generalSubdivisions.AddRange(subdivisionsRank4);
                generalSubdivisions.AddRange(subdivisionsRank5);

                // прибывшие иные службы
                List<ServiceType> serviceTypes = ListViewServiceTypes.Items.Cast<ServiceType>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие должностные лица
                List<PositionType> positionTypes = ListViewPositionTypes.Items.Cast<PositionType>().Where(p => p.ArrivalChecked).ToList();
                if (_currentDeparture.DepartureId == 0)
                    FireDepartEntities.GetContext().Departures.Add(_currentDeparture);
                FireDepartEntities.GetContext().SaveChanges();
                // обновление, добавление данных в производных таблицах
                FireDepartEntities.GetContext().DepartureBurns.RemoveRange(_currentDeparture.DepartureBurns);
                FireDepartEntities.GetContext().DepartureSubdivisions.RemoveRange(_currentDeparture.DepartureSubdivisions);
                FireDepartEntities.GetContext().DepartureServices.RemoveRange(_currentDeparture.DepartureServices);
                FireDepartEntities.GetContext().DeparturePositions.RemoveRange(_currentDeparture.DeparturePositions);

                foreach (var i in burnTypes)
                    FireDepartEntities.GetContext().DepartureBurns.Add(new DepartureBurn { BurnTypeId = i.BurnTypeId, DepartureId = _currentDeparture.DepartureId });
                foreach (var i in generalSubdivisions)
                    FireDepartEntities.GetContext().DepartureSubdivisions.Add(new DepartureSubdivision
                    {
                        SubdivisionId = i.SubdivisionId,
                        DepartureId = _currentDeparture.DepartureId,
                        DateTimeDeparture = i.TimeDeparture,
                        DateTimeArrival = i.TimeArrival,
                        CountPeople = i.PeopleCount
                    });
                foreach (var i in serviceTypes)
                    FireDepartEntities.GetContext().DepartureServices.Add(new DepartureService
                    {
                        ServiceTypeId = i.ServiceTypeId,
                        DepartureId = _currentDeparture.DepartureId,
                        DateTimeDeparture = i.TimeDeparture,
                        DateTimeArrival = i.TimeArrival,
                        CountTechnics = i.TechnicCount,
                        CountPeople = i.PeopleCount
                    });
                foreach (var i in positionTypes)
                    FireDepartEntities.GetContext().DeparturePositions.Add(new DeparturePosition
                    {
                        PositionTypeId = i.PositionTypeId,
                        DepartureId = _currentDeparture.DepartureId,
                        DateTimeArrival = i.TimeArrival
                    });
                FireDepartEntities.GetContext().SaveChanges();
                //SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Файлы данных|*.xml" };
                //if (saveFileDialog.ShowDialog() == true)
                //{
                //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Departure));
                //    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                //    {
                //        Departure departure = new Departure
                //        {
                //            DepartureId = _currentDeparture.DepartureId,
                //            DateTimeDepart = _currentDeparture.DateTimeDepart,
                //            NumHouse = _currentDeparture.NumHouse
                //        };
                //        Departure departure2 = _currentDeparture;
                //        xmlSerializer.Serialize(fs, departure2);
                //    }
                //}
                MessageBox.Show("Запись изменена/добавлена");
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            

        }
        private void LoadInfo()
        {
            // загрузка инфорации
            //ComboBoxBurns.Items.Clear();
            selectedBurns = FireDepartEntities.GetContext().BurnTypes.ToList();
            foreach (var i in selectedBurns)
            {
                i.BurnSelected = false;
                if (_currentDeparture.DepartureId != 0)
                {                   
                    DepartureBurn depBurn  = _currentDeparture.DepartureBurns.FirstOrDefault(p => p.BurnTypeId == i.BurnTypeId);
                    if (depBurn != null)
                    {
                        i.BurnSelected = true;
                    }
                }
            }
            ComboBoxBurns.ItemsSource = selectedBurns;

            selectedServices = FireDepartEntities.GetContext().ServiceTypes.ToList();
            foreach (var i in selectedServices)
            {
                i.DepartureChecked = false;
                i.ArrivalChecked = false;
                i.PeopleCount = 0;
                i.TechnicCount = 0;
                if (_currentDeparture.DepartureId != 0)
                {
                    DepartureService depSerivce = _currentDeparture.DepartureServices.FirstOrDefault(p => p.ServiceTypeId == i.ServiceTypeId);
                    if (depSerivce != null)
                    {
                        i.DepartureChecked = true;
                        i.TimeDeparture = depSerivce.DateTimeDeparture;
                        i.ArrivalChecked = true;
                        i.TimeArrival = (DateTime)depSerivce.DateTimeArrival;
                        i.PeopleCount = (short)depSerivce.CountPeople;
                        i.TechnicCount = (short)depSerivce.CountTechnics;
                    }
                }
            }
            ListViewServiceTypes.ItemsSource = selectedServices;

            selectedPositions = FireDepartEntities.GetContext().PositionTypes.ToList();
            foreach (var i in selectedPositions)
            {
                i.ArrivalChecked = false;
                if (_currentDeparture.DepartureId != 0)
                {
                    DeparturePosition depPosition = _currentDeparture.DeparturePositions.FirstOrDefault(p => p.PositionTypeId == i.PositionTypeId);
                    if (depPosition != null)
                    {
                        i.ArrivalChecked = true;
                        i.TimeArrival = (DateTime)depPosition.DateTimeArrival;
                    }
                }
            }
            ListViewPositionTypes.ItemsSource = selectedPositions;  
        }
        private void LoadSubdivisionInfo()
        {
            if (ComboBoxDepArea.SelectedItem is DepartureArea departureArea)
            {
                // 1 ранг пожара
                List<Subdivision> subdivisionRank = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 1 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;                   
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank.ItemsSource = subdivisionRank;
                // 1 Бис ранг пожара
                List<Subdivision> subdivisionRank1 = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 2 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank1)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank1.ItemsSource = subdivisionRank1;
                // 2 ранг пожара
                List<Subdivision> subdivisionRank2 = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 3 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank2)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank2.ItemsSource = subdivisionRank2;
                // 3 ранг пожара
                List<Subdivision> subdivisionRank3 = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 4 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank3)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank3.ItemsSource = subdivisionRank3;
                // 4 ранг пожара
                List<Subdivision> subdivisionRank4 = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 5 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank4)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank4.ItemsSource = subdivisionRank4;
                // 5 ранг пожара
                List<Subdivision> subdivisionRank5 = FireDepartEntities.GetContext().Subdivisions.Where(p => p.FireRank == 6 && p.DepartureAreaId == departureArea.DepartureAreaId).ToList();
                foreach (var i in subdivisionRank5)
                {
                    i.DepartureChecked = false;
                    i.ArrivalChecked = false;
                    i.PeopleCount = 0;
                    if (_currentDeparture.DepartureId != 0)
                    {
                        DepartureSubdivision depSubdivision = _currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.SubdivisionId == i.SubdivisionId);
                        if (depSubdivision != null)
                        {
                            i.DepartureChecked = true;
                            i.TimeDeparture = depSubdivision.DateTimeDeparture;
                            i.ArrivalChecked = true;
                            i.TimeArrival = (DateTime)depSubdivision.DateTimeArrival;
                            i.PeopleCount = (short)depSubdivision.CountPeople;
                        }
                    }
                }
                ListViewRank5.ItemsSource = subdivisionRank5;
            }

        }
        private void LoadUpdatedInfo()
        {
            // уточненная информация
            if (_currentDeparture.ExternalSignsInfo != null)
            {
                if (_currentDeparture.ExternalSignsInfo.Contains("Слабое выделение дыма"))
                    RButtonSign1.IsChecked = true;
                else if (_currentDeparture.ExternalSignsInfo.Contains("Сильное выделение дыма"))
                    RButtonSign2.IsChecked = true;
                else if (_currentDeparture.ExternalSignsInfo.Contains("Вырывающиеся языки пламени"))
                    RButtonSign3.IsChecked = true;
            }
               
            if (_currentDeparture.ThreatPeopleInfo != null)
            {
                if (_currentDeparture.ThreatPeopleInfo.Contains("Имеется угроза"))
                    ThreatPeople.IsChecked = true;
                else
                    ThreatPeople.IsChecked = false;
            }
            
            if (_currentDeparture.AffectedInfo != null)
            {
                if (_currentDeparture.AffectedInfo.Contains("Да, в количестве"))
                    YesAffected.IsChecked = true;
                else if (_currentDeparture.AffectedInfo.Contains("Пострадавших нет"))
                    NoAffected.IsChecked = true;
                else if (_currentDeparture.AffectedInfo.Contains("Не знаю"))
                    UnknownAffected.IsChecked = true;
            }
           
            if (_currentDeparture.StatePeopleInfo != null)
            {
                if (_currentDeparture.StatePeopleInfo.Contains("Без сознания"))
                    StatePeople1.IsChecked = true;
                if (_currentDeparture.StatePeopleInfo.Contains("ожоги"))
                    StatePeople2.IsChecked = true;
                if (_currentDeparture.StatePeopleInfo.Contains("Не знаю"))
                    StatePeople3.IsChecked = true;
            }

            if (_currentDeparture.PeopleLocationInfo != null)
            {
                if (_currentDeparture.PeopleLocationInfo.Contains("Самостоятельно эвакуируются"))
                    CheckBoxLocation1.IsChecked = true;
                if (_currentDeparture.PeopleLocationInfo.Contains("В зоне воздействия"))
                    CheckBoxLocation2.IsChecked = true;
            }

            if (_currentDeparture.ThreatFireInfo != null)
            {
                if (_currentDeparture.ThreatFireInfo.Contains("Имеется"))
                    ThreatFire1.IsChecked = true;
                else if (_currentDeparture.ThreatFireInfo.Contains("Имеется на этажи"))
                    ThreatFire2.IsChecked = true;
                else if (_currentDeparture.ThreatFireInfo.Contains("Имеется на соседние объекты"))
                    ThreatFire3.IsChecked = true;
                else if (_currentDeparture.ThreatFireInfo.Contains("Не знаю"))
                    ThreatFire4.IsChecked = true;
            }

            if (_currentDeparture.NearbyObjectInfo != null)
            {
                if (_currentDeparture.NearbyObjectInfo.Contains("Социально - значимые"))
                    CheckBoxObject1.IsChecked = true;
                if (_currentDeparture.NearbyObjectInfo.Contains("С массовым пребыванием"))
                    CheckBoxObject2.IsChecked = true;
                if (_currentDeparture.NearbyObjectInfo.Contains("Производственные"))
                    CheckBoxObject3.IsChecked = true;
                if (_currentDeparture.NearbyObjectInfo.Contains("Социально - значимых объектов рядом нет"))
                    CheckBoxObject4.IsChecked = true;
                if (_currentDeparture.NearbyObjectInfo.Contains("Рядом объектов нет"))
                    CheckBoxObject5.IsChecked = true;
            }
            if (_currentDeparture.PlaceInfo != null)
            {
                if (_currentDeparture.PlaceInfo.Contains("На объекте"))
                    RButtonPlace1.IsChecked = true;
                else if (_currentDeparture.PlaceInfo.Contains("Рядом с объектом"))
                    RButtonPlace2.IsChecked = true;
                else if (_currentDeparture.PlaceInfo.Contains("Внутри здания"))
                    RButtonPlace3.IsChecked = true;
            }
            if (_currentDeparture.BarrierInfo != null)
            {
                if (_currentDeparture.BarrierInfo.Contains("Есть"))
                    RButtonBarrier1.IsChecked = true;
                else if (_currentDeparture.BarrierInfo.Contains("Припаркованные ТС"))
                    RButtonBarrier2.IsChecked = true;
                else if (_currentDeparture.BarrierInfo.Contains("Котлованы"))
                    RButtonBarrier3.IsChecked = true;
                else if (_currentDeparture.BarrierInfo.Contains("Шлагбаум"))
                    RButtonBarrier4.IsChecked = true;
                else if (_currentDeparture.BarrierInfo.Contains("Искусственные заграждения"))
                    RButtonBarrier5.IsChecked = true;
            }
            if (_currentDeparture.MeetMCSInfo != null)
            {
                if (_currentDeparture.MeetMCSInfo.Contains("Имеется"))
                    RButtonMCS1.IsChecked = true;
                else if (_currentDeparture.MeetMCSInfo.Contains("Нет"))
                    RButtonMCS2.IsChecked = true;
            }
            if (_currentDeparture.WhyApplicantInfo != null)
            {
                if (_currentDeparture.WhyApplicantInfo.Contains("Собственник"))
                    RButtonWhy1.IsChecked = true;
                else if (_currentDeparture.WhyApplicantInfo.Contains("Сосед"))
                    RButtonWhy2.IsChecked = true;
                else if (_currentDeparture.WhyApplicantInfo.Contains("Арендатор"))
                    RButtonWhy3.IsChecked = true;
                else if (_currentDeparture.WhyApplicantInfo.Contains("Очевидец"))
                    RButtonWhy4.IsChecked = true;
            }
            // привлеченная техника            
            foreach (var i in _currentDeparture.DepartureSubdivisions)
            {
                if (i.Subdivision.DepartureAreaId == selectedDepartureArea.DepartureAreaId)
                    i.Subdivision.Technic.TechnicCountGeneral += 1;
            }
            // кол-во привлеченной техники и л.с
            foreach (var i in _currentDeparture.DepartureSubdivisions)
                if (i.Subdivision.DepartureAreaId == selectedDepartureArea.DepartureAreaId)
                    Subdivision.PeopleCountGeneral += (int)i.CountPeople;
            if (_currentDeparture.DepartureSubdivisions.FirstOrDefault(p => p.Subdivision.DepartureAreaId == selectedDepartureArea.DepartureAreaId) != null)
                Technic.AllTechnicCount = _currentDeparture.DepartureSubdivisions.Count;  
            PositionType.PeopleCountGeneral = _currentDeparture.DeparturePositions.Count;
            foreach (var i in _currentDeparture.DepartureServices)
            {
                ServiceType.TechnicCountGeneral += (int)i.CountTechnics;
                ServiceType.PeopleCountGeneral += (int)i.CountPeople;
            }
            TbMCSCountTechnic.Text = Technic.AllTechnicCount.ToString();
            TbMCSCountPeople.Text = (Subdivision.PeopleCountGeneral + PositionType.PeopleCountGeneral).ToString();
            TbGeneralCountPeople.Text = (Subdivision.PeopleCountGeneral + ServiceType.PeopleCountGeneral + PositionType.PeopleCountGeneral).ToString();
            TbGeneralCountTechnic.Text = (Technic.AllTechnicCount + ServiceType.TechnicCountGeneral).ToString();

            // загрузка в раздел "информация с места пожара"
            DataGridFireInfo.ItemsSource = _currentDeparture.FireInfoes.ToList();

        }
        private void UpdateBarrelAndSquareCount()
        {
            var listFireInfo = DataGridFireInfo.Items.Cast<FireInfo>().ToList();
            short barrelCount = 0;
            foreach (var i in listFireInfo)
            {
                if (i.BarrelCount != null)
                    barrelCount += Convert.ToInt16(i.BarrelCount);
               
            }
            var lastFireArea = listFireInfo.Where(p => p.FireAreaCount != null).OrderByDescending(p => p.DateTimeEntry).ToList();
            if (lastFireArea.Count > 0)
            {
                _currentDeparture.FireAreaCount = lastFireArea[0].FireAreaCount;
                TbSquareFire.Text = lastFireArea[0].FireAreaCount.ToString();
            }
            else
            {
                _currentDeparture.FireAreaCount = 0;
                TbSquareFire.Text = "0";
            }
            _currentDeparture.BarrelCount = barrelCount;
            TbCountSteam.Text = barrelCount.ToString();
            
        }
        /// <summary>
        /// Добавление информации с места пожара
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddFireInfo_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditFireInfoWindow addOrEditFireInfoWindow = new AddOrEditFireInfoWindow(null, _currentDeparture);
            if (addOrEditFireInfoWindow.ShowDialog() == false)
            {
                
                FireDepartEntities.GetContext().ChangeTracker.Entries<FireInfo>().ToList().ForEach(p => p.Reload());
            }
            DataGridFireInfo.ItemsSource = _currentDeparture.FireInfoes.ToList();
            UpdateBarrelAndSquareCount();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridFireInfo.SelectedItem is FireInfo fireInfo)
            {
                AddOrEditFireInfoWindow addOrEditFireInfoWindow = new AddOrEditFireInfoWindow(fireInfo, _currentDeparture);
                if (addOrEditFireInfoWindow.ShowDialog() == false)
                {

                    FireDepartEntities.GetContext().ChangeTracker.Entries<FireInfo>().ToList().ForEach(p => p.Reload());
                }
                DataGridFireInfo.ItemsSource = _currentDeparture.FireInfoes.ToList();
                UpdateBarrelAndSquareCount();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridFireInfo.SelectedItem is FireInfo fireInfo)
            {
                try
                {
                    //if (positionType.Specialties.Count > 0)
                    //    throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    if (fireInfo.FireInfoId != 0)
                    {
                        FireDepartEntities.GetContext().FireInfoSubdivisions.RemoveRange(fireInfo.FireInfoSubdivisions);
                        FireDepartEntities.GetContext().FireInfoes.Remove(fireInfo);
                    }
                    else
                    {
                        fireInfo.FireInfoSubdivisions.Clear();
                        _currentDeparture.FireInfoes.Remove(fireInfo);
                    }    
                    //FireDepartEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");

                    DataGridFireInfo.ItemsSource = _currentDeparture.FireInfoes.ToList();
                    UpdateBarrelAndSquareCount();
                    FireDepartEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        /// <summary>
        /// добавление уточненной информации
        /// </summary>
        private void SaveUpdatedInfo()
        {
            // форматы разделители: - - перечисление, , - доп информация, % - текстовое поле, | - след информация
            //string generalInfo = $"Что вы видите по внешним признакам? - {_currentDeparture.SignInfo} , {_currentDeparture.SignAddInfo}|Угроза людям, просят ли о помощи? - " +
            //    $"{_currentDeparture.ThreatPeople} % {_currentDeparture.ThreatCountPeople} , {_currentDeparture.AddThreatPeople}|Имеются ли пострадавшие? - {_currentDeparture.Affected}" +
            //    $" % {_currentDeparture.AffectedCount} , {_currentDeparture.AddAffected}|Что с ними?";
            //foreach (var i in _currentDeparture.StatePeoples)
            //    generalInfo += $" - {i}";
            //generalInfo += $" , {_currentDeparture.AddStatePeople}";
            //var list = generalInfo.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            //foreach(var i in list)
            //{
            //    var test = i.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            //}
            

        }

        private void RButtonSign_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.ExternalSignsInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
            
        }

        private void ThreatPeople_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.ThreatPeopleInfo = (((CheckBox)sender).Content as TextBlock)?.Text;
        }

        private void ThreatPeople_Unchecked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.ThreatPeopleInfo = null;
        }

        private void YesAffected_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.AffectedInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        private void StatePeople_Checked(object sender, RoutedEventArgs e)
        {
            if (_currentDeparture.StatePeopleInfo != null && !_currentDeparture.StatePeopleInfo.Contains($"{(((CheckBox)sender).Content as TextBlock)?.Text},"))
                _currentDeparture.StatePeopleInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
            else if (_currentDeparture.StatePeopleInfo == null)
                _currentDeparture.StatePeopleInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
            //_currentDeparture.StatePeoples.Add((((CheckBox)sender).Content as TextBlock)?.Text);
        }

        private void StatePeople_Unchecked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.StatePeopleInfo =  _currentDeparture.StatePeopleInfo.Replace($"{(((CheckBox)sender).Content as TextBlock)?.Text},", "");
            //_currentDeparture.StatePeoples.Remove((((CheckBox)sender).Content as TextBlock)?.Text);
        }

        private void CheckBoxLocation_Checked(object sender, RoutedEventArgs e)
        {
            if (_currentDeparture.PeopleLocationInfo != null && !_currentDeparture.PeopleLocationInfo.Contains($"{(((CheckBox)sender).Content as TextBlock)?.Text},"))
                _currentDeparture.PeopleLocationInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
            else if (_currentDeparture.PeopleLocationInfo == null)
                _currentDeparture.PeopleLocationInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
            //_currentDeparture.Locations.Add((((CheckBox)sender).Content as TextBlock)?.Text);
        }

        private void CheckBoxLocation_Unchecked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.PeopleLocationInfo = _currentDeparture.PeopleLocationInfo.Replace($"{(((CheckBox)sender).Content as TextBlock)?.Text},", "");
            //_currentDeparture.Locations.Remove((((CheckBox)sender).Content as TextBlock)?.Text);
        }

        private void ThreatFire_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.ThreatFireInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        private void CheckBoxObject_Checked(object sender, RoutedEventArgs e)
        {
            if (_currentDeparture.NearbyObjectInfo != null && !_currentDeparture.NearbyObjectInfo.Contains($"{(((CheckBox)sender).Content as TextBlock)?.Text},"))
                _currentDeparture.NearbyObjectInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
            else if (_currentDeparture.NearbyObjectInfo == null)
                _currentDeparture.NearbyObjectInfo += $"{(((CheckBox)sender).Content as TextBlock)?.Text},";
        }

        private void CheckBoxObject_Unchecked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.NearbyObjectInfo = _currentDeparture.NearbyObjectInfo.Replace($"{(((CheckBox)sender).Content as TextBlock)?.Text},", "");
        }
        private void RButtonPlace_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.PlaceInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        private void RButtonBarrier_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.BarrierInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        private void RButtonMCS_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.MeetMCSInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        private void RButtonWhy_Checked(object sender, RoutedEventArgs e)
        {
            _currentDeparture.WhyApplicantInfo = (((RadioButton)sender).Content as TextBlock)?.Text;
        }

        
    }
}
