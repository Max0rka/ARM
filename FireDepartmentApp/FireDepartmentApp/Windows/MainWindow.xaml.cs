using FireDepartmentApp.Windows;
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
using FireDepartmentApp.Entities;
using FireDepartmentApp.Pages;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

namespace FireDepartmentApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private bool IsNewDocument = false;
        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.Content = new DefaultPage();
            try
            {
                FireDepartEntities.GetContext().Database.Connection.Open();
                FireDepartEntities.GetContext().Database.Connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            MainFrame.Content = new AddDeparturePage(null);
            Manager.MainFrame = MainFrame;
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (IsNewDocument)
            {
                while (MainFrame.NavigationService.RemoveBackEntry() != null) { }
                IsNewDocument = false;
            }  
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnListDepart.Visibility = Visibility.Collapsed;

            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnListDepart.Visibility = Visibility.Visible;
            }
        }
        private void BtnNewDoc_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.IsOpenAddPage && MessageBox.Show("Сохранить текущий документ?", "Сохранение",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Manager.AddDeparturePage.Focusable = true;
                Manager.AddDeparturePage.Focus();
                Manager.AddDeparturePage.SaveInfo();
            }
            IsNewDocument = true;
            MainFrame.Content = new AddDeparturePage(null);
        }

        private void BtnOpenDoc_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSaveDoc_Click(object sender, RoutedEventArgs e)
        {
            Manager.AddDeparturePage.Focusable = true;
            Manager.AddDeparturePage.Focus();
            Manager.AddDeparturePage.SaveInfo();
            //MainFrame.Content = null;
            //while (MainFrame.NavigationService.RemoveBackEntry() != null) { }
           
            //MainFrame.Content = new AddDeparturePage(null);
            //Manager.MainFrame = MainFrame;
        }

        private void BtnWaybill_Click(object sender, RoutedEventArgs e)
        {
            Manager.AddDeparturePage.Focusable = true;
            Manager.AddDeparturePage.Focus();
            Word.Application application = new Word.Application();
            Word.Document document = default;
            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;
            Object templatePath = Directory.GetCurrentDirectory() + "/WordTemplate/TourTemplate.docx";
            try
            {
                document = application.Documents.Add(ref templatePath, ref missingObj, ref missingObj, ref missingObj);
                ReplaceWordText("{fireDep}", Properties.Settings.Default.FireDepName, document);
                ReplaceWordText("{DepAddress}", Manager.AddDeparturePage._currentDeparture.AddressName, document);
                ReplaceWordText("{fireObjects}", Manager.AddDeparturePage._currentDeparture.ListBurnTypes, document);
                ReplaceWordText("{timeEntrance}", $"{Manager.AddDeparturePage._currentDeparture.DateTimeDepart:HH.mm}", document);
                ReplaceWordText("{applicantInfo}", Manager.AddDeparturePage._currentDeparture.ApplicantInfo, document);
                ReplaceWordText("{dateEntrance}", $"{Manager.AddDeparturePage._currentDeparture.DateTimeDepart:dd.MM.yyyy} г", document);
                application.Visible = true;
            }
            catch (Exception ex) 
            {
               
                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 

            }
            
        }
        private void ReplaceWordText(string stubToReplace, string text, Word.Document document)
        {
            var range = document.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            Manager.AddDeparturePage.Focusable = true;
            Manager.AddDeparturePage.Focus();
            Word.Application application = new Word.Application();
            Word.Document document = default;
            Object missingObj = System.Reflection.Missing.Value;
            Object trueObj = true;
            Object falseObj = false;
            Object templatePath = Directory.GetCurrentDirectory() + "/WordTemplate/DepartTemplate.docx";
            try
            {
                document = application.Documents.Add(ref templatePath, ref missingObj, ref missingObj, ref missingObj);
                var table = application.ActiveDocument.Tables[1];
                Departure dep = Manager.AddDeparturePage._currentDeparture;
                table.Rows.Add(missingObj);

                table.Cell(3, 1).Range.Text = $"{dep.DateTimeDepart:dd.MM.yyyy}";
                table.Cell(3, 2).Range.Text = $"{dep.DateTimeDepart:HH.mm}";
                table.Cell(4, 1).Range.Text = $"{dep.DateTimeDepart:dd.MM.yyyy}";
                table.Cell(4, 2).Range.Text = $"{dep.DateTimeDepart:HH.mm}";
                table.Cell(3, 3).Range.Text = $"{dep.AddressName} {((dep.Landmark != null && dep.Landmark.Length > 0) ? $"\nОриентиры - {dep.Landmark}" : "")}" +
                    $"{((dep.ApplicantPhone != null && dep.ApplicantPhone.Length > 0) ? $"\nНомер телефона заявителя - {dep.ApplicantPhone}" : "")}" +
                    $"{((dep.ListBurnTypes.Length > 0) ? $"\nЧто горит - {dep.ListBurnTypes}" : "")} {((dep.AdditionalInfo != null && dep.AdditionalInfo.Length > 0) ? $"\nДополнительная информация - {dep.AdditionalInfo}" : "")}";

                string updatedInfo = "Уточненная информация\nЧто вы видите по внешним признакам";
                if (dep.ExternalSignsInfo != null && dep.ExternalSignsInfo.Length > 0)
                    updatedInfo += $" - {dep.ExternalSignsInfo}";
                if (dep.ExternalSignAddInfo != null && dep.ExternalSignAddInfo.Length > 0)
                    updatedInfo += $" - {dep.ExternalSignAddInfo}";
                updatedInfo += $"\nУгроза людям, просят ли о помощи";
                if (dep.ThreatPeopleInfo != null && dep.ThreatPeopleInfo.Length > 0)
                {
                    updatedInfo += $" - {dep.ThreatPeopleInfo}";
                    if (dep.ThreatPeopleCount != null)
                        updatedInfo += $" - {dep.ThreatPeopleCount} чел.";
                    if (dep.ThreatPeopleAddInfo != null && dep.ThreatPeopleAddInfo.Length > 0)
                        updatedInfo += $" - {dep.ThreatPeopleAddInfo}";
                }
                updatedInfo += $"\nИмеются ли пострадавшие";
                if (dep.AffectedInfo != null && dep.AffectedInfo.Length > 0)
                {
                    updatedInfo += $" - {dep.AffectedInfo}";
                    if (dep.AffectedCount != null && dep.AffectedInfo.Contains("Да"))
                        updatedInfo += $" - {dep.AffectedCount} чел.";
                    if (dep.AffectedAddInfo != null && dep.AffectedAddInfo.Length > 0)
                        updatedInfo += $" - {dep.AffectedAddInfo}";
                }
                if (dep.AffectedInfo != null && dep.AffectedInfo.Length > 0 && dep.AffectedInfo.Contains("Да"))
                {
                    updatedInfo += $"\nЧто с ними";
                    if (dep.StatePeopleInfo != null && dep.StatePeopleInfo.Length > 0)
                    {
                        updatedInfo += $" - {dep.StatePeopleInfo}";
                        if (dep.StatePeopleAddInfo != null && dep.StatePeopleAddInfo.Length > 0)
                            updatedInfo += $" - {dep.StatePeopleAddInfo}";
                    }
                    updatedInfo += $"\nГде находятся";
                    if (dep.PeopleLocationInfo != null && dep.PeopleLocationInfo.Length > 0)
                    {
                        updatedInfo += $" - {dep.PeopleLocationInfo}";
                        if (dep.PeopleLocationAddInfo != null && dep.PeopleLocationAddInfo.Length > 0)
                            updatedInfo += $" - {dep.PeopleLocationAddInfo}";
                    }
                }
                updatedInfo += "\nИмеется ли угроза распространения";
                if (dep.ThreatFireInfo != null && dep.ThreatFireInfo.Length > 0)
                    updatedInfo += $" - {dep.ThreatFireInfo}";
                if (dep.ThreatFireAddInfo != null && dep.ThreatFireAddInfo.Length > 0)
                    updatedInfo += $" - {dep.ThreatFireAddInfo}";
                updatedInfo += "\nКакие значимые объекты имеются рядом";
                if (dep.NearbyObjectInfo != null && dep.NearbyObjectInfo.Length > 0)
                    updatedInfo += $" - {dep.NearbyObjectInfo}";
                if (dep.NearbyObjectAddInfo != null && dep.NearbyObjectAddInfo.Length > 0)
                    updatedInfo += $" - {dep.NearbyObjectAddInfo}";
                updatedInfo += "\nМестонахождение заявителя";
                if (dep.PlaceInfo != null && dep.PlaceInfo.Length > 0)
                    updatedInfo += $" - {dep.PlaceInfo}";
                if (dep.PlaceAddInfo != null && dep.PlaceAddInfo.Length > 0)
                    updatedInfo += $" - {dep.PlaceAddInfo}";
                updatedInfo += "\nЕсть ли перекрытые проезды";
                if (dep.BarrierInfo != null && dep.BarrierInfo.Length > 0)
                    updatedInfo += $" - {dep.BarrierInfo}";
                if (dep.BarrierAddInfo != null && dep.BarrierAddInfo.Length > 0)
                    updatedInfo += $" - {dep.BarrierAddInfo}";
                updatedInfo += "\nВозможность встречи пожарных подразделений";
                if (dep.MeetMCSInfo != null && dep.MeetMCSInfo.Length > 0)
                    updatedInfo += $" - {dep.MeetMCSInfo}";
                if (dep.MeetMCSAddInfo != null && dep.MeetMCSAddInfo.Length > 0)
                    updatedInfo += $" - {dep.MeetMCSAddInfo}";
                updatedInfo += "\nВаше отношение к объекту пожара";
                if (dep.WhyApplicantInfo != null && dep.WhyApplicantInfo.Length > 0)
                    updatedInfo += $" - {dep.WhyApplicantInfo}";
                if (dep.WhyApplicantAddInfo != null && dep.WhyApplicantAddInfo.Length > 0)
                    updatedInfo += $" - {dep.WhyApplicantAddInfo}";
                updatedInfo += "\nВаша фамилия, имя, отчество";
                if (dep.FIOApplicant != null && dep.FIOApplicant.Length > 0)
                    updatedInfo += $" - {dep.FIOApplicant}";

                table.Cell(4, 3).Range.Text = updatedInfo;
                // прибывшие подразделения 1 ранга пожара
                List<Subdivision> subdivisionsRank = Manager.AddDeparturePage.ListViewRank.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 1 БИС ранга пожара
                List<Subdivision> subdivisionsRank1 = Manager.AddDeparturePage.ListViewRank1.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 2 ранга пожара
                List<Subdivision> subdivisionsRank2 = Manager.AddDeparturePage.ListViewRank2.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 3 ранга пожара
                List<Subdivision> subdivisionsRank3 = Manager.AddDeparturePage.ListViewRank3.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 4 ранга пожара
                List<Subdivision> subdivisionsRank4 = Manager.AddDeparturePage.ListViewRank4.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие подразделения 5 ранга пожара
                List<Subdivision> subdivisionsRank5 = Manager.AddDeparturePage.ListViewRank5.Items.Cast<Subdivision>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();

                // прибывшие подразделения общее
                List<Subdivision> generalSubdivisions = new List<Subdivision>();
                generalSubdivisions.AddRange(subdivisionsRank);
                generalSubdivisions.AddRange(subdivisionsRank1);
                generalSubdivisions.AddRange(subdivisionsRank2);
                generalSubdivisions.AddRange(subdivisionsRank3);
                generalSubdivisions.AddRange(subdivisionsRank4);
                generalSubdivisions.AddRange(subdivisionsRank5);

                // прибывшие иные службы
                List<ServiceType> serviceTypes = Manager.AddDeparturePage.ListViewServiceTypes.Items.Cast<ServiceType>().Where(p => p.DepartureChecked && p.ArrivalChecked).ToList();
                // прибывшие должностные лица
                List<PositionType> positionTypes = Manager.AddDeparturePage.ListViewPositionTypes.Items.Cast<PositionType>().Where(p => p.ArrivalChecked).ToList();
                int rowInd = 4;
                string subdivisionInfo = "", subdivisionDep = "", subdivisionArrival = "";
                foreach (var i in generalSubdivisions)
                {
                    table.Rows.Add(missingObj);
                    rowInd++;
                    table.Cell(rowInd, 1).Range.Text = $"{i.TimeArrival:dd.MM.yyyy}";
                    table.Cell(rowInd, 2).Range.Text = $"{i.TimeArrival:HH.mm}";
                    table.Cell(rowInd, 3).Range.Text = $"Прибыл к месту вызова\n{i.SubdivisionName} провожу разведку";
                    table.Cell(3, 4).Merge(table.Cell(rowInd, 4));
                    table.Cell(3, 5).Merge(table.Cell(rowInd, 5));
                    table.Cell(3, 6).Merge(table.Cell(rowInd, 6));
                    table.Cell(3, 7).Merge(table.Cell(rowInd, 7));
                    table.Cell(3, 8).Merge(table.Cell(rowInd, 8));
                    table.Cell(3, 9).Merge(table.Cell(rowInd, 9));
                    table.Cell(3, 10).Merge(table.Cell(rowInd, 10));
                    table.Cell(3, 11).Merge(table.Cell(rowInd, 11));
                    table.Cell(3, 12).Merge(table.Cell(rowInd, 12));
                    subdivisionInfo += $"{i.SubdivisionName} - {i.PeopleCount} чел.\n";
                    subdivisionDep += $"{i.TimeDeparture:HH.mm} _\n";
                    subdivisionArrival += $"{i.TimeArrival:HH.mm} _\n";
                }
                table.Cell(3, 4).Range.Text = subdivisionInfo;
                table.Cell(3, 5).Range.Text = subdivisionDep;
                table.Cell(3, 6).Range.Text = subdivisionArrival;
                void MergedTable()
                {
                    table.Cell(3, 4).Merge(table.Cell(rowInd, 4));
                    table.Cell(3, 5).Merge(table.Cell(rowInd, 5));
                    table.Cell(3, 6).Merge(table.Cell(rowInd, 6));
                    table.Cell(3, 7).Merge(table.Cell(rowInd, 7));
                    table.Cell(3, 8).Merge(table.Cell(rowInd, 8));
                    table.Cell(3, 9).Merge(table.Cell(rowInd, 9));
                    table.Cell(3, 10).Merge(table.Cell(rowInd, 10));
                    table.Cell(3, 11).Merge(table.Cell(rowInd, 11));
                    table.Cell(3, 12).Merge(table.Cell(rowInd, 12));
                }

                foreach (var i in serviceTypes)
                {
                    table.Rows.Add(missingObj);
                    rowInd++;
                    table.Cell(rowInd, 1).Range.Text = $"{i.TimeArrival:dd.MM.yyyy}";
                    table.Cell(rowInd, 2).Range.Text = $"{i.TimeArrival:HH.mm}";
                    table.Cell(rowInd, 3).Range.Text = $"Прибыли к месту вызова\n{i.ServiceTypeName}";
                    MergedTable();
                }
                foreach (var i in positionTypes)
                {
                    table.Rows.Add(missingObj);
                    rowInd++;
                    table.Cell(rowInd, 1).Range.Text = $"{i.TimeArrival:dd.MM.yyyy}";
                    table.Cell(rowInd, 2).Range.Text = $"{i.TimeArrival:HH.mm}";
                    table.Cell(rowInd, 3).Range.Text = $"Прибыли к месту вызова\n{i.PositionTypeName}";
                    MergedTable();
                }
                foreach (var i in dep.FireInfoes)
                {
                    table.Rows.Add(missingObj);
                    rowInd++;
                    table.Cell(rowInd, 1).Range.Text = $"{i.DateTimeEntry:dd.MM.yyyy}";
                    table.Cell(rowInd, 2).Range.Text = $"{i.DateTimeEntry:HH.mm}";
                    string fireInfo = "";
                    if (i.Broadcast != null)
                        fireInfo += $"{i.Broadcast.BroadcastName}";
                    if (i.InfoPlace != null && i.InfoPlace.Length > 0)
                        fireInfo += $"\n{i.InfoPlace}";
                    if (i.WorkVariety != null && i.WorkVariety.Length > 0)
                        fireInfo += $"\nРазновидность работ - {i.WorkVariety}";
                    if (i.ListSubdivisions != null && i.ListSubdivisions.Length > 0)
                        fireInfo += $"\nПривлекаемые силы и средства - {i.ListSubdivisions}";
                    if (i.MissionType != null)
                        fireInfo += $"\nЗадача - {i.MissionType.MissionTypeName}";
                    if (i.WorkArea != null)
                        fireInfo += $"\nУчасток работы - {i.WorkArea.WorkAreaName}";
                    if (i.BarrelType != null)
                        fireInfo += $"\nТип стволов - {i.BarrelType.BarrelTypeName}";
                    if (i.BarrelCount != null)
                        fireInfo += $"\nКоличество стволов - {i.BarrelCount}";
                    if (i.CombatArea != null)
                        fireInfo += $"\nБоевой участок - {i.CombatArea.CombatAreaName}";
                    if (i.AddInfo != null && i.AddInfo.Length > 0)
                        fireInfo += $"\nДополнительная инф-ция - {i.AddInfo}";
                    table.Cell(rowInd, 3).Range.Text = fireInfo;
                    MergedTable();
                }
                table.Rows.Add(missingObj);
                rowInd++;
                MergedTable();
                string generalInfo = "Всего привлечено техники";
                var technics = FireDepartEntities.GetContext().Technics.ToList();
                foreach (var i in technics)
                    if (i.TechnicCountGeneral > 0)
                        generalInfo += $"\n{i.TechnicName} - {i.TechnicCountGeneral}";
                generalInfo += $"\nЛичного состава - {Manager.AddDeparturePage.TbGeneralCountPeople.Text} чел.\nПодано стволов - {dep.BarrelCount}\nПлощадь пожара - {dep.FireAreaCount}" +
                    $"\nВсего привлекалось - {Manager.AddDeparturePage.TbGeneralCountPeople.Text} чел., {Manager.AddDeparturePage.TbGeneralCountTechnic.Text} ед. техники" +
                    $"\nВ том числе от МЧС - {Manager.AddDeparturePage.TbMCSCountPeople.Text} чел., {Manager.AddDeparturePage.TbMCSCountTechnic.Text} ед. техники";
                table.Cell(rowInd, 3).Range.Text = generalInfo;

                table.Rows.Add(missingObj);
                rowInd++;
                MergedTable();
                table.Cell(rowInd, 3).Range.Text = "Диспетчер ЦПСС\n\nОперативный дежурный\n";
                if (dep.IsFireContainment)
                    table.Cell(3, 8).Range.Text = $"{dep.DateTimeFireContainment:dd.MM.yyyy HH.mm}";
                if (dep.IsOpenBurning)
                    table.Cell(3, 9).Range.Text = $"{dep.DateTimeOpenBurn:dd.MM.yyyy HH.mm}";
                if (dep.IsAftermathFire)
                    table.Cell(3, 10).Range.Text = $"{dep.DateTimeAftermath:dd.MM.yyyy HH.mm}";
                //table.Cell(3, 4).Merge(table.Cell(4, 4));
                //table.Cell(3, 4).Range.Text = "5";
                //var range = document.Content.Tables[0];
                //var text = range.Cell(1, 1).Range;
                //text.Text = "test";
                //ReplaceWordText("{dateEntrance}", $"{Manager.AddDeparturePage._currentDeparture.DateTimeDepart:dd.MM.yyyy} г", document);
                application.Visible = true;
            }
            catch (Exception ex)
            {

                application.Quit(ref missingObj, ref missingObj, ref missingObj);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BtnDirectoryEdit_Click(object sender, RoutedEventArgs e)
        {
            DirectoryWindow directoryWindow = new DirectoryWindow();
            directoryWindow.ShowDialog();
            Manager.IsDirectory = true;
            //MainFrame.Refresh();
            Manager.AddDeparturePage.Page_IsVisibleChanged(null, default);
        }

        private void BtnOptions_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.ShowDialog();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void BtnListDepart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DeparturePage();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
    }
}
