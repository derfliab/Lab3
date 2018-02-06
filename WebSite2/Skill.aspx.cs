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

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtskillName.Value = "";
        txtskillDescription.Value = "";
    }
 
    protected void SkillBtn_Click(object sender, EventArgs e)
    {
        bool working = true;
        if (compareOne(txtskillName.Value, "SKILL", "SkillName") == false)
        {
            working = false;
            Label.Text += "Skill name exists in the database!";
        }
        if (compareOne(txtskillDescription.Value, "SKILL", "SkillDescription") == false)
        {
            working = false;
            Label.Text += "Skill description exists in the database!";
        }
        if (working == true)
        {
            try
            {
                Skill newSkill = new Skill(txtskillName.Value, txtskillDescription.Value, "Andrea Derflinger", DateTime.Now);
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = @"Server =Localhost ;Database=Lab3;Trusted_Connection=Yes;";
                string commandText = "INSERT into [dbo].[Skill] (SkillName, SkillDescription, LastUpdatedBy, LastUpdated) " +
                    "values (@skillName, @skillDesc, @lastUpdatedBy, @lastUpdated)";
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand(commandText, sc);
                insert.Parameters.AddWithValue("@skillName", newSkill.SkillName);
                insert.Parameters.AddWithValue("@skillDesc", newSkill.SkillDescription);
                insert.Parameters.AddWithValue("@lastUpdatedBy", newSkill.LastUpdatedBy);
                insert.Parameters.AddWithValue("@lastUpdated", newSkill.LastUpdated);

                sc.Open();
                insert.ExecuteNonQuery();
                Label.Text += "Skill has been added!";
                sc.Close();

            }
            catch (Exception i)
            {
                Label.Text += "Error adding skill!";
                Label.Text += i.Message;
            }
        }
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