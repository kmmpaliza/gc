﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VillageClass;
using System.Linq;


namespace Village_Kiosk.View
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string name, username, designation, question, answer, password, message;
        VillageKioskClass admin = new VillageKioskClass();

        protected void Page_Load(object sender, EventArgs e)
        {

              
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            if ((String.IsNullOrEmpty(txtname.Text)) || (String.IsNullOrEmpty(txtusername.Text)) ||
                (String.IsNullOrEmpty(txtAnswer.Text)) || (drpDesignation.SelectedIndex == 0) || (drpQuestion.SelectedIndex == 0))
            {
                message = "Please Fill Up The Form";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);


            }


            else if (admin.checkAdmin(txtname.Text, txtusername.Text))
            {
                message = "Details already exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
            }

            else
            {


                answer = txtAnswer.Text;
                designation = drpDesignation.SelectedItem.Text;
                question = drpQuestion.SelectedItem.Text;

                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    password = "12345678";
                }
                else
                {
                    password = txtPassword.Text;
                }

                admin.insertAdmin(txtname.Text, txtusername.Text, designation, question, answer, password);
                message = "Admin added";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);

                txtname.Text = "";
                txtusername.Text = "";
                drpDesignation.SelectedIndex = 0;
                drpQuestion.SelectedIndex = 0;
                txtAnswer.Text = "";
                txtPassword.Text = "";

            }
        }

       
        protected void drpQuestion_Selected(object sender, EventArgs e)
        {
            txtAnswer.Enabled = true;
        }

        protected void Fullname_Changed(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 2; i++)
            {
                username = txtname.Text.Substring(txtname.Text.LastIndexOf(' ') + 1) + (Convert.ToString(random.Next(10, 200)));

            }
            string forUsername = username;
            txtusername.Text = forUsername;
        }

     
     
    }
}