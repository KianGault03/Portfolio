using System.Windows;              // Provides WPF window functionality.
using System;                      // Provides base types like string and exception handling.
using System.Net.Http;             // For sending HTTP requests.
using System.Threading.Tasks;      // Enables asynchronous programming.
using Newtonsoft.Json;             // Used to handle JSON serialization/deserialization.
using System.Text;                 // Provides text encoding utilities.
using KwikMedical_Server.Models;   // References the server's data models (e.g., Patientcs).
using System.Net;                  // Provides networking functionality.
using System.Numerics;             // Includes numerical data types (not used in this file).

namespace KwikMedicalUI_WPF
{
    /// <summary>
    /// Interaction logic for CallOperator.xaml
    /// </summary>
    public partial class CallOperator : Window
    {
        private readonly HttpClient _httpClient; // Private HttpClient to send requests to the back-end server
        public CallOperator()
        {
            InitializeComponent();
            //Initalise the Http Client with the local host API URL
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5080/api/") };

        }

        /// <summary>
        /// Button event that is clicked when the user enters a number into the search bar (CHI number)
        /// </summary>
        private async void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            // Stores the entered string
            string chiNumber = txt_SearchCHI.Text.Trim();
            // Check if the CHI number is entered
            if (string.IsNullOrWhiteSpace(chiNumber))
            {
                MessageBox.Show("Please enter a CHI number to search.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Make the GET request to fetch the patient by CHI number
                var response = await _httpClient.GetAsync($"Patients?chiNumber={chiNumber}");

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response into a Patientcs object
                    var patientJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + patientJson); // Debug log
                    var patient = JsonConvert.DeserializeObject<Patientcs>(patientJson);

                    // Populate the text boxes with the patient's data
                    txt_Name.Text = patient.Name;
                    txt_CHINumber.Text = patient.CHIRegistrationNumber;
                    txt_Address.Text = patient.Address;
                    txt_MedicalCondition.Text = patient.MedicalCondition;
                }
                else
                {
                    // If patient is not found, display an error message
                    MessageBox.Show("Patient not found. You can create a new record.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., network issues)
                MessageBox.Show($"Error fetching patient data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// Button event that is triggered when the user clicks on the create record button
        /// </summary>
        private async void btn_CreateNewRecord_Click(object sender, RoutedEventArgs e)
        {
            // Stores the entered data and checks if all fields have been entered, if not, an error message is displayed
            string name = txt_Name.Text;
            string CHINumber = txt_CHINumber.Text;
            string Address = txt_Address.Text;
            string MedicalCondition = txt_MedicalCondition.Text;
           
            if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(CHINumber) ||
            string.IsNullOrWhiteSpace(Address) ||
            string.IsNullOrWhiteSpace(MedicalCondition))
            {
                MessageBox.Show("All fields are required to create a new record.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Check if CHI Number already exists
                var checkResponse = await _httpClient.GetAsync($"Patients?chiNumber={CHINumber}");
                if (checkResponse.IsSuccessStatusCode)
                {
                    // If a record with the CHI number exists, show a warning
                    MessageBox.Show("A patient with this CHI number already exists. Please enter a unique CHI number.", "Duplicate CHI Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new patient object
                var newPatient = new Patientcs
                {
                    Name = name,
                    CHIRegistrationNumber = CHINumber,
                    Address = Address,
                    MedicalCondition = MedicalCondition
                };

                // Serialize the patient object into JSON
                var jsonContent = JsonConvert.SerializeObject(newPatient);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make a POST request to create the new record
                var response = await _httpClient.PostAsync("Patients", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Patient record created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Clear the input fields
                    txt_Name.Clear();
                    txt_CHINumber.Clear();
                    txt_Address.Clear();
                    txt_MedicalCondition.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to create a new patient record. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., network issues, server errors)
                MessageBox.Show($"Error creating patient record: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Button event that triggers the process of sending the currently accessed database record to the ambulance UI
        /// </summary>
        private void btn_SendPatientRecords_Click(object sender, RoutedEventArgs e)
        {
            // Check to see if a patient record is present on screen
            if (string.IsNullOrWhiteSpace(txt_Name.Text) ||
                string.IsNullOrWhiteSpace(txt_CHINumber.Text))
            {
                MessageBox.Show("Please search for a patient record before proceeding.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Open the AmbulancePhone window with the selected patient’s details
            var ambulancePhone = new AmbulancePhone(
                txt_Name.Text,          // Patient Name
                txt_CHINumber.Text,     // CHI Number
                txt_Address.Text,       // Address
                txt_MedicalCondition.Text // Condition
            );

            ambulancePhone.ShowDialog();
        }
        /// <summary>
        /// Button event that clears the record from the screen
        /// </summary>
        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_Name.Text = string.Empty;
            txt_CHINumber.Text = string.Empty;
            txt_SearchCHI.Text = string.Empty;
            txt_Address.Text = string.Empty;
            txt_MedicalCondition.Text = string.Empty;
        }
    }
}
