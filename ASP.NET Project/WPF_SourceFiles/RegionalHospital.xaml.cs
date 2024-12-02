using System;
using System.Windows;

namespace KwikMedicalUI_WPF
{
    /// <summary>
    /// Interaction logic for RegionalHospital.xaml
    /// </summary>
    public partial class RegionalHospital : Window
    {
        public RegionalHospital(string name, string chiNumber, string address, string condition,
                                string responseWho, string responseWhat, string responseWhen, string responseWhere)
        {
            InitializeComponent();

            // Populate the patient and response details
            txt_PatientName.Text = name;
            txt_PatientCHI.Text = chiNumber;
            txt_PatientAddress.Text = address;
            txt_PatientCondition.Text = condition;

            txt_ResponseWho.Text = responseWho;
            txt_ResponseWhat.Text = responseWhat;
            txt_ResponseWhen.Text = responseWhen;
            txt_ResponseWhere.Text = responseWhere;
        }
        /// <summary>
        /// This button is to demostrate the functionality of the hospital staff confirming a patient's arrival. 
        /// In the final build, additional functionality should be given like finding suitable beds for arrival patients. 
        /// </summary>
        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            // Logic to confirm patient reception
            MessageBox.Show("Patient reception confirmed by the hospital staff.", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optional: Log the confirmation to a database or send it to the API

           
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            // Simply close the window
            this.Close();
        }
    }
}

