﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_WeddingDressShop.Views.Admin
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("~/Views/Clients/Login.aspx");
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Logic for adding a new category
            Response.Write("<script>alert('Add button clicked');</script>");
        }

        protected void btnEdit1_Click(object sender, EventArgs e)
        {
            // Logic for editing a category
            Response.Write("<script>alert('Edit button clicked');</script>");
        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            // Logic for deleting a category
            Response.Write("<script>alert('Delete button clicked');</script>");
        }
    }
}