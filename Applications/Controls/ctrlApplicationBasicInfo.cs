﻿using DVLD.People;
using DVLD_Business;
using DVLD_MySolution.Global_Classes;
using DVLD_MySolution.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_MySolution.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

            lblApplicationID.Text = "{???}";
            lblStatus.Text = "{???}";
            lblFees.Text = "{$$$}";
            lblApplicant.Text = "{???}";
            lblType.Text = "{????}";
            lblDate.Text = "{??/??/????}";
            lblStatusDate.Text = "{??/??/????}";
            lblCreatedByUser.Text = "{????}";
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lblApplicationID.Text = _Application.ApplicationID.ToString();

            lblStatus.Text = _Application.StatusText;

            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;

            lblFees.Text = _Application.PaidFees.ToString();

            lblApplicant.Text = _Application.ApplicantFullName;

            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);

            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);

            lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

            //Refresh
            LoadApplicationInfo(_ApplicationID);
        }
    }
}