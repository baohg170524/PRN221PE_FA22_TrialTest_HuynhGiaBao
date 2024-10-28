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
using Candidate_BO;
using Candidate_Repositories;
using Candidate_Services;

namespace CandidateManagement_HuynhGiaBao
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private readonly ICandidateProfileServ profileServ;
        private readonly IJobPostingServ jobPostingServ;
        private readonly int? RoleID;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            profileServ = new CandidateProfileServ();
            jobPostingServ = new JobPostingServ();
        }
        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            this.profileServ = new CandidateProfileServ();
            
            this.jobPostingServ = new JobPostingServ();
            this.RoleID = roleID;
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            switch (RoleID)
            {
                case 1:
                    this.btnUpdate.IsEnabled = false;
                    break;
                case 2:
                    //Staff
                    this.btnAdd.IsEnabled = false;
                    break;
                case 3:
                    this.btnDelete.IsEnabled = false;
                    break;
                default:
                    this.Close();
                    break;
            }
            this.loadDataInit();

        }

        private void loadDataInit()
        {
            this.dtgCandidateProfile.ItemsSource = profileServ.GetCandidates();
            this.cmbPostID.ItemsSource = jobPostingServ.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            // gán giá trị cho từng thuộc tính ở dưới
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCanID.Text;
            candidateProfile.Fullname = txtFullname.Text;
            candidateProfile.ProfileUrl = txtImgurl.Text;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.Birthday = dtpBirthDay.SelectedDate;
            candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();

            // Lưu đối tượng CandidateProfile vào cơ sở dữ liệu hoặc danh sách
            if (profileServ.AddCadidateProfile(candidateProfile))
            {
                MessageBox.Show("Add Successful !");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something is wrong !");
            }

        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            if(row == null)
            {
                MessageBox.Show("err");
                return;
            }
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string CandidateId = ((TextBlock)RowColumn.Content).Text;
            CandidateProfile candidateProfile = profileServ.searchCandidateByID(CandidateId);

            txtCanID.Text = candidateProfile.CandidateId;

            txtFullname.Text = candidateProfile.Fullname;

            txtImgurl.Text = candidateProfile.ProfileUrl;

            txtDescription.Text = candidateProfile.ProfileShortDescription;

            dtpBirthDay.SelectedDate = candidateProfile.Birthday;

            cmbPostID.SelectedValue = candidateProfile.PostingId.ToString();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (profileServ.removeCandidate(txtCanID.Text))
                {
                    MessageBox.Show("Deleted successfully");
                    this.dtgCandidateProfile.ItemsSource = profileServ.GetCandidates();


                }
                else
                {
                    MessageBox.Show("Can not Delete");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                CandidateProfile candidateProfile = new CandidateProfile();

                candidateProfile.CandidateId = txtCanID.Text;
                candidateProfile.Fullname = txtFullname.Text;
                candidateProfile.ProfileUrl = txtImgurl.Text;
                candidateProfile.ProfileShortDescription = txtDescription.Text;
                candidateProfile.Birthday = dtpBirthDay.SelectedDate;
                candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();
                if (profileServ.updateCandidate(candidateProfile))
                {
                    MessageBox.Show("Update successfully");
                    this.dtgCandidateProfile.ItemsSource = profileServ.GetCandidates();
                }
                else
                {
                    MessageBox.Show("Update failed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
