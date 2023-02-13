<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="AuditTrails.aspx.cs" Inherits="Falcon.Secure.AuditTrails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-logs').classList.add("active");
        };
    </script>
    <style type="text/css">
        .table {
            border-left: white !important;
            border-right: white !important;
        }

        .table-height-min {
            min-height: 300px !important;
            font-size: 11px;
        }


        .table-light {
            border-width: 1px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="table-responsive text-nowrap table-height-min">

            <asp:GridView runat="server"
                ID="GridView1"
                AutoGenerateColumns="False"
                DataKeyNames="audittrailid"
                AllowPaging="True"
                PageSize="10"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                CssClass="table"
                HeaderStyle-CssClass="table-light">
                <Columns>
                    <asp:TemplateField SortExpression="auditdate">
                        <ItemTemplate>
                            <asp:Label ID="LblAuditDate" runat="server" Text='<%# Bind("auditdate") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>Date</label>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="useridname">
                        <ItemTemplate>
                            <asp:Label ID="LblUsername" runat="server" Text='<%# Bind("useridname") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>User Name</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="action">
                        <ItemTemplate>
                            <asp:Label ID="LblAction" runat="server" Text='<%# Bind("action") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>Action</label>
                            <asp:TextBox ID="txtAction" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="type">
                        <ItemTemplate>
                            <asp:Label ID="LblType" runat="server" Text='<%# Bind("type") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>Type</label>
                            <asp:TextBox ID="txtType" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="contentname">
                        <ItemTemplate>
                            <asp:Label ID="LblContenteName" runat="server" Text='<%# Bind("contentname") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>Content</label>
                            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="details">
                        <ItemTemplate>
                            <asp:Label ID="LblDetails" runat="server" Text='<%# Bind("details") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <label>Details</label>
                            <asp:TextBox ID="txtDetails" runat="server" CssClass="form-control" Width="100px" OnTextChanged="txt_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    <div align="center">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
