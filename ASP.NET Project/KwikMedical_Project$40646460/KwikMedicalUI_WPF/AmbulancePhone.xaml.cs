using KwikMedical_Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace KwikMedicalUI_WPF
{
    /// <summary>
    /// Interaction logic for AmbulancePhone.xaml
    /// </summary>
    public partial class AmbulancePhone : Window
    {
        /// <summary>
        /// Contructor takes in patient data when called to display on the form.
        /// NOTE: This is the prototype version, the full system should simply pull the patient record from the database (API)
        /// </summary>
        public AmbulancePhone(string name, string chiNumber, string address, string condition)
        {
            InitializeComponent();

            txt_PatientName.Text = name;
            txt_PatientCHI.Text = chiNumber;
            txt_PatientAddress.Text = address;
            txt_PatientCondition.Text = condition;
            // Display the patient name into the ambulance form for efficiency.
            txt_ResponseWho.Text = name;
        }
        /// <summary>
        /// Button event that is triggered when the user hits the save response button. 
        /// This will only be valid if all response fields are properly filled out. 
        /// </summary>
        private async void btn_SaveResponse_Click(object sender, RoutedEventArgs e)
        {
            // Capture response details
            string who = txt_ResponseWho.Text.Trim();
            string what = txt_ResponseWhat.Text.Trim();
            string when = txt_ResponseWhen.Text.Trim();
            string where = txt_ResponseWhere.Text.Trim();

            if (string.IsNullOrWhiteSpace(who) || string.IsNullOrWhiteSpace(what) ||
                string.IsNullOrWhiteSpace(when) || string.IsNullOrWhiteSpace(where))
            {
                MessageBox.Show("Please fill out all response details.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Save response data to the database table
            var record = new
            {
                PatientCHI = txt_PatientCHI.Text.Trim(), // Use the value from the TextBox
                ResponseWho = who,
                ResponseWhat = what,
                ResponseWhen = when,
                ResponseWhere = where
            };

            try
            {
                // Initalise the Http Client address with the API URL
                using (var client = new HttpClient { BaseAddress = new Uri("http://localhost:5080/api/") })
                {
                    // Serialize object to JSON format to be stored
                    var json = JsonConvert.SerializeObject(record);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // Call the POST API controller
                    var response = await client.PostAsync("AmbulanceRecords", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ambulance record saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to save the record.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show($"Response saved successfully:\nWho: {who}\nWhat: {what}\nWhen: {when}\nWhere: {where}",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            OpenRegionalHospitalWindow();
        }
        /// <summary>
        /// Button that opens the regional hospital window.
        /// NOTE: Data is passed via the current window to the next, this is a prototype to show the communication between clients,
        /// the actual system should call the data from both tables via the API.
        /// </summary>
        private void OpenRegionalHospitalWindow()
        {
            // Collect data from the current window
            string name = txt_PatientName.Text.Trim();
            string chiNumber = txt_PatientCHI.Text.Trim();
            string address = txt_PatientAddress.Text.Trim();
            string condition = txt_PatientCondition.Text.Trim();

            string responseWho = txt_ResponseWho.Text.Trim();
            string responseWhat = txt_ResponseWhat.Text.Trim();
            string responseWhen = txt_ResponseWhen.Text.Trim();
            string responseWhere = txt_ResponseWhere.Text.Trim();

            // Open the RegionalHospital window and pass the data
            RegionalHospital hospitalWindow = new RegionalHospital(name, chiNumber, address, condition, 
                responseWho, responseWhat, responseWhen, responseWhere);
            hospitalWindow.Show();
        }

    }
}
