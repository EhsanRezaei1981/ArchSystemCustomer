using ArchSystem.Service.Customer;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace DesktopApp.Launcher
{
    public partial class MainForm : Form
    {
        private readonly ICustomerService _customerService;
        public MainForm(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            refreshGrid();
        }
        bool isEditMode = false;
        private bool isValidEmail (string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtEmail.Text;
                if (!string.IsNullOrWhiteSpace(email) && !isValidEmail(email)) {
                    MessageBox.Show("Email provided is invalid");
                    return;
                }

                if (!isEditMode)
                {
                    var result = await _customerService.Create(new ArchSystem.Dto.Models.Customer.Create.InputDto
                    {
                        Name = txtName.Text,
                        Surname = txtSurname.Text,
                        Email = txtEmail.Text,
                        IDNumber = txtIdNumber.Text,
                        Tel = string.IsNullOrWhiteSpace(txtTel.Text) ? null : long.Parse(txtTel.Text),
                        Country = txtCountry.Text,
                    });

                    if (!result.ErrorHandling.IsSuccessful)
                    {
                        MessageBox.Show($"Error!!! {result.ErrorHandling.ErrorMessage} {result.ErrorHandling.ErrorTechnicalMessage}");
                        return;
                    }
                    clearFields();
                    refreshGrid();
                    MessageBox.Show(result.ErrorHandling.ErrorMessage);
                }
                else
                {
                    var result = await _customerService.Update(new ArchSystem.Dto.Models.Customer.Update.InputDto
                    {
                        CustomerId = int.Parse(lblCustomerId.Text),
                        LastUpdateDateTime = lblLastUpdateDateTime.Text,
                        Name = txtName.Text,
                        Surname = txtSurname.Text,
                        Email = txtEmail.Text,
                        IDNumber = txtIdNumber.Text,
                        Tel = string.IsNullOrWhiteSpace(txtTel.Text) ? null : long.Parse(txtTel.Text),
                        Country = txtCountry.Text,
                    });

                    if (!result.ErrorHandling.IsSuccessful)
                    {
                        MessageBox.Show($"Error!!! {result.ErrorHandling.ErrorMessage} {result.ErrorHandling.ErrorTechnicalMessage}");
                        return;
                    }
                    isEditMode = false;
                    clearFields();
                    refreshGrid();
                    MessageBox.Show(result.ErrorHandling.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!!! {ex.Message}");
            }
        }

        async void refreshGrid()
        {
            try
            {
                var result = await _customerService.Retrieve(new ArchSystem.Dto.Models.Customer.Retrieve.InputDto());

                if (!result.ErrorHandling.IsSuccessful)
                {
                    MessageBox.Show($"Error!!! {result.ErrorHandling.ErrorMessage} {result.ErrorHandling.ErrorTechnicalMessage}");
                    return;
                }

                var source = new BindingSource(result.Data, null);
                dataGridViewCustomer.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!!! {ex.Message}");
            }
        }

        private async void dataGridViewCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            var selectedIndex = (dataGridViewCustomer.CurrentCell?.RowIndex) ?? -1;
            if (selectedIndex == -1) return;
            var key = e.KeyValue;
            switch (key)
            {
                case 113:/*F2*/
                    isEditMode = true;
                    populateFields(selectedIndex);
                    lblCustomerId.Visible = true;
                    lblLastUpdateDateTime.Visible = true;
                    _lblCustomerId.Visible = true;
                    _lblLastUpdateDateTime.Visible = true;
                    break;
                case 46:/*Delete*/
                    delete(selectedIndex);
                    break;
                case 27:/*Escape*/
                    if (!isEditMode) return;
                    isEditMode = false;
                    clearFields();
                    break;
                case 117:/*F6*/
                    refreshGrid();
                    break;
                default:
                    break;
            }
        }

        async void delete(int index)
        {
            var customerId = dataGridViewCustomer.Rows[index].Cells["dgwCustomerId"].Value?.ToString();
            var lastUpdateDateTime = dataGridViewCustomer.Rows[index].Cells["dgwLastUpdateDateTime"].Value?.ToString();
            var result = await _customerService.Delete(new ArchSystem.Dto.Models.Customer.Delete.InputDto
            {
                CustomerId = int.Parse(customerId),
                LastUpdateDateTime = lastUpdateDateTime
            });

            if (!result.ErrorHandling.IsSuccessful)
            {
                MessageBox.Show($"Error!!! {result.ErrorHandling.ErrorMessage} {result.ErrorHandling.ErrorTechnicalMessage}");
                return;
            }
            refreshGrid();
        }

        void clearFields()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtIdNumber.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            lblCustomerId.Visible = false;
            lblLastUpdateDateTime.Visible = false;
            _lblCustomerId.Visible = false;
            _lblLastUpdateDateTime.Visible = false;

        }
        void populateFields(int index)
        {
            lblCustomerId.Text = dataGridViewCustomer.Rows[index].Cells["dgwCustomerId"].Value?.ToString();
            txtName.Text = dataGridViewCustomer.Rows[index].Cells["dgwName"].Value?.ToString();
            txtSurname.Text = dataGridViewCustomer.Rows[index].Cells["dgwSurname"].Value?.ToString();
            txtIdNumber.Text = dataGridViewCustomer.Rows[index].Cells["dgwIDNumber"].Value?.ToString();
            txtTel.Text = dataGridViewCustomer.Rows[index].Cells["dgwTel"].Value?.ToString();
            txtEmail.Text = dataGridViewCustomer.Rows[index].Cells["dgwEmail"].Value?.ToString();
            txtCountry.Text = dataGridViewCustomer.Rows[index].Cells["dgwCountry"].Value?.ToString();
            lblLastUpdateDateTime.Text = dataGridViewCustomer.Rows[index].Cells["dgwLastUpdateDateTime"].Value?.ToString();
        }

        private void dataGridViewCustomer_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (!isEditMode)
                return;

            var selectedIndex = dataGridViewCustomer.CurrentCell.RowIndex;
            populateFields(selectedIndex);
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _customerService.ExportToXml();

                if (!result.ErrorHandling.IsSuccessful)
                {
                    MessageBox.Show($"Error!!! {result.ErrorHandling.ErrorMessage} {result.ErrorHandling.ErrorTechnicalMessage}");
                    return;
                }
                MessageBox.Show(result.ErrorHandling.ErrorMessage);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error!!! {ex.Message}");
            }
        }
    }
}