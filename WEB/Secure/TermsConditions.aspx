<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="TermsConditions.aspx.cs" Inherits="Falcon.Secure.TermsConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-tc').classList.add("active");
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

        .text-nowrap {
            white-space: unset !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <h5 class="card-header">Terms & Conditions</h5>
        <div class="table-responsive text-nowrap table-height-min">

            <asp:GridView runat="server"
                ID="GridView1"
                AutoGenerateColumns="False"
                DataKeyNames="id"
                AllowPaging="True"
                PageSize="10"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                CssClass="table"
                HeaderStyle-CssClass="table-dark"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="dropdown">
                                <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                    <i class="bx bx-dots-vertical-rounded"></i>
                                </button>
                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="TermsConditionsForm.aspx">
                                        <i class="bx bx-plus me-1"></i>Add
                                    </a>
                                    <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item">
                                        <i class="bx bx-edit-alt me-1"></i>Edit
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Content" SortExpression="name" ControlStyle-Width="400px" ItemStyle-Width="400px">
               
                        <ItemTemplate>
                            <asp:Label ID="Labelname" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sequence" SortExpression="sequence">
                        <ItemTemplate>
                            <asp:Label ID="Labelsequence" runat="server" Text='<%# Eval("sequence") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="creatorname" HeaderText="Created By" InsertVisible="False" ReadOnly="True" SortExpression="creatorname" />
                    <asp:BoundField DataField="created" HeaderText="Date Ceated" InsertVisible="False" ReadOnly="True" SortExpression="created" />
                    <asp:BoundField DataField="updatername" HeaderText="Updated By" InsertVisible="False" ReadOnly="True" SortExpression="updatername" />
                    <asp:BoundField DataField="updated" HeaderText="Date Updated" InsertVisible="False" ReadOnly="True" SortExpression="updated" />


                </Columns>

                <EmptyDataTemplate>
                    <div align="center">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
