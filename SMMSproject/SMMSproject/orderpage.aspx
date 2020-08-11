<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="orderpage.aspx.cs" Inherits="SMMSproject.orderpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="cus_id" HeaderText="cus_id" SortExpression="cus_id" />
            <asp:BoundField DataField="pro_id" HeaderText="pro_id" SortExpression="pro_id" />
            <asp:BoundField DataField="cus_name" HeaderText="cus_name" SortExpression="cus_name" />
            <asp:BoundField DataField="pro_name" HeaderText="pro_name" SortExpression="pro_name" />
            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
            <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:smdbConnectionString %>" SelectCommand="SELECT * FROM [order]"></asp:SqlDataSource>
</asp:Content>
