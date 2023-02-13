<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Falcon.Secure.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-users').classList.add("active");
        };
    </script>
    <style type="text/css">
        .table {
            border-left: white !important;
            border-right: white !important;
        }

        .table-height-min {
            min-height: 300px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <h5 class="card-header">Users Table</h5>
        <div class="table-responsive text-nowrap table-height-min">

            <asp:GridView runat="server"
                ID="GridView1"
                AutoGenerateColumns="False"
                DataKeyNames="userid"
                AllowPaging="True"
                PageSize="10"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                CssClass="table"
                HeaderStyle-CssClass="table-dark"
                OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="dropdown">
                                <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                    <i class="bx bx-dots-vertical-rounded"></i>
                                </button>
                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="UsersForm.aspx">
                                        <i class="bx bx-plus me-1"></i>Add
                                    </a>
                                    <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item">
                                        <i class="bx bx-edit-alt me-1"></i>Edit
                                    </asp:LinkButton>
                                    <asp:LinkButton OnClick="LinkButtonReset_Click" runat="server" ID="LinkButtonReset" CssClass="dropdown-item" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                        <i class="bx bx-archive me-1"></i>Reset
                                    </asp:LinkButton>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Full name" SortExpression="fullname">
                        <ItemTemplate>
                            <asp:Label ID="Labelfullname" runat="server" Text='<%# Bind("fullname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Username" SortExpression="email">
                        <ItemTemplate>
                            <asp:Label ID="Labelemail" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Role name" SortExpression="rolename">
                        <ItemTemplate>
                            <asp:Label ID="Labelrolename" runat="server" Text='<%# Bind("rolename") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Validity" SortExpression="validitydate">
                        <ItemTemplate>
                            <asp:Label ID="Labelvaliditydate" runat="server" Text='<%# Bind("validitydate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--   <asp:BoundField DataField="creatorname" HeaderText="Created By" InsertVisible="False" ReadOnly="True" SortExpression="creatorname" />
                    <asp:BoundField DataField="created" HeaderText="Date Ceated" InsertVisible="False" ReadOnly="True" SortExpression="created" />
                    <asp:BoundField DataField="updatername" HeaderText="Updated By" InsertVisible="False" ReadOnly="True" SortExpression="updatername" />
                    <asp:BoundField DataField="updated" HeaderText="Date Updated" InsertVisible="False" ReadOnly="True" SortExpression="updated" />--%>
                </Columns>

                <EmptyDataTemplate>
                    <div align="center">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
