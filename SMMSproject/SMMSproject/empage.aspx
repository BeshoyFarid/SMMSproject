<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="empage.aspx.cs" Inherits="SMMSproject.empage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <div class="row">
      
        <div class="col">
             <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">

                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" InsertVisible="False" />
                                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                                <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                                <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                                
                            </Columns>
                         </asp:GridView>
        </div>
    </div>
</div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:smdbConnectionString %>" SelectCommand="SELECT * FROM [employee]"></asp:SqlDataSource>

</asp:Content>
