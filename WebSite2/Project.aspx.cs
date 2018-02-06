using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * Andrea Derflinger
 * Lab 2 
 * 1/30/2018
 * This work and I comply with the JMU Honor Code.
**/
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clearLabel();
    }

    
    protected void ProjectCommitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            Project newProject = new Project(txtprojectName.Value, txtprojectDescription.Value, "Andrea Derflinger", DateTime.Now);

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab3;Trusted_Connection=Yes;";
            string commandText = "INSERT into [dbo].[Project] (ProjectName, ProjectDescription, LastUpdatedBy, LastUpdated) " +
                "values (@projectName, @projectDesc, @lastUpdatedBy, @lastUpdated)";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand(commandText, sc);
            insert.Parameters.AddWithValue("@projectName", newProject.ProjectName);
            insert.Parameters.AddWithValue("@projectDesc", newProject.ProjectDescription);
            insert.Parameters.AddWithValue("@lastUpdatedBy", newProject.LastUpdatedBy);
            insert.Parameters.AddWithValue("@lastUpdated", newProject.LastUpdated);

            sc.Open();
            insert.ExecuteNonQuery();
            Label.Text += "Project has been added!";
            sc.Close();

        }
        catch (Exception i)
        {
            Label.Text += "Error adding project!";
            Label.Text += i.Message;
        }


    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtprojectName.Value = "";
        txtprojectDescription.Value = "";
    }

    private void clearLabel()
    {
        Label.Text = "";
    }

    private bool compareOne(string item, string table, string field)
    {
        int result = 0;
        bool compareOne = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost ;Database=Lab3;Trusted_Connection=Yes;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();
        insert.CommandText = "select Count(*) FROM [dbo].[" + table + "] WHERE UPPER(" + field + ") LIKE '" + item.ToUpper() + "'";
        result = (int)insert.ExecuteScalar();
        sc.Close();
        if (result > 0)
        {
            compareOne = false;
            return compareOne;
        }

        else
        {
            return compareOne;
        }

    }
}