<%@ Page Title="Andrea Derflinger" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Project.aspx.cs" Inherits="_Default" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
            body{
            background-color: lightsteelblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <body>
    <h1>Project Form:</h1>
     <table id="projectinfo" style="width:200%">
        <tr>
            
            <td>
                Project Name:
            </td>
        </tr>
        <tr>
            <td>
                <input id="txtprojectName" type="text" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Project Description:
            </td>
        </tr>
        <tr>
            <td>
                <input id="txtprojectDescription" type="text" runat="server" />
            </td>
        </tr>
        
     </table>
          <br />
          <asp:Button ID="Clear" runat="server" style="margin-right:20px" OnClick="ClearBtn_Click" Text="Clear" />
          <asp:Button ID="ProjectCommit" runat="server" style="margin-right:20px" OnClick="ProjectCommitBtn_Click" Text="Project Commit" />
          <br />
          <asp:Label ID="Label" runat="server" />
</body>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Width="283px" placeholder="Please enter a project name"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Search" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProjectID" DataSourceID="ProjectSearch" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" InsertVisible="False" ReadOnly="True" SortExpression="ProjectID" />
            <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" ReadOnly="false" />
            <asp:BoundField DataField="ProjectDescription" HeaderText="ProjectDescription" SortExpression="ProjectDescription" ReadOnly="false" />
            <asp:BoundField DataField="LastUpdatedBy" HeaderText="LastUpdatedBy" SortExpression="LastUpdatedBy" ReadOnly="true"/>
            <asp:BoundField DataField="LastUpdated" HeaderText="LastUpdated" SortExpression="LastUpdated" ReadOnly="true"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ProjectSearch" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3ConnectionString3 %>" 
        SelectCommand="SELECT * FROM [Project] WHERE ([ProjectName] LIKE '%' + @ProjectName + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="ProjectName" PropertyName="Text" Type="String" />
        </SelectParameters>
 
    </asp:SqlDataSource>
    <asp:Label ID="UpdateProjectName" runat="server" Text="Update Project Name: " Visible ="false"></asp:Label>
    <br />
    <asp:TextBox ID="txtUpdateProjectName" runat="server" Visible ="false"></asp:TextBox>
    <br />
    <asp:Label ID="UpdateProjectDesc" runat="server" Text="Update Project Description:" Visible ="false"></asp:Label>
    <br />
    <asp:TextBox ID="txtUpdateProjectDesc" runat="server" Visible ="false"></asp:TextBox>
    <br />
    <asp:Button ID="UpdateProject" runat="server" Text="Update Project" Visible="false" OnClick="UpdateProjectBtn_Click"/>
    <br />
    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
    </asp:Content>

