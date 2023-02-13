<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="Quotations.aspx.cs" Inherits="Falcon.Secure.Quotations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-quotation').classList.add("active");
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
        <div class="row">
            <h5 class="card-header col-sm-3">Quotation Table</h5>
        </div>


        <div class="table-responsive text-nowrap table-height-min">


            <!-- Modal -->
            <div class="modal fade" id="modalCenter1" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalCenterTitle">Search Quotations</h5>
                            <button
                                type="button"
                                class="btn-close"
                                data-bs-dismiss="modal"
                                aria-label="Close">
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col mb-0">
                                    <label class="form-label">Quotation No.</label>
                                    <asp:TextBox runat="server" ID="txtSearchQuotationNo" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-0">
                                    <label class="form-label">Client</label>
                                    <asp:TextBox runat="server" ID="txtSearchClient" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-0">
                                    <label class="form-label">Shipment</label>
                                    <asp:TextBox runat="server" ID="txtSearchShipment" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-0">
                                    <label class="form-label">Description</label>
                                    <asp:TextBox runat="server" ID="txtSearchDescription" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-0">
                                    <label class="form-label">Status</label>
                                    <asp:TextBox runat="server" ID="txtSearchStatus" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                                Close
                               
                            </button>
                            <asp:Button runat="server" ID="BtnSearch" Text="Search" CssClass="btn btn-primary" OnClick="BtnSearch_Click" />

                        </div>
                    </div>
                </div>
            </div>


            <asp:GridView runat="server"
                ID="GridView1"
                AutoGenerateColumns="False"
                DataKeyNames="id"
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
                                    <a class="dropdown-item" href="QuotationsForm.aspx">
                                        <i class="bx bx-plus me-1"></i>Add
                                    </a>
                                    <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item">
                                        <i class="bx bx-notepad me-1"></i>View
                                    </asp:LinkButton>
                                    <a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#modalCenter1">
                                        <i class="bx bx-search me-1"></i>Search
                                    </a>
                                    <%--    <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                    </asp:LinkButton>--%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Quotation No." SortExpression="quotation_no">
                        <ItemTemplate>
                            <asp:Label ID="Labelquotation_no" runat="server" Text='<%# Bind("quotation_no") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Client" SortExpression="clientname">
                        <ItemTemplate>
                            <asp:Label ID="Labelclientname" runat="server" Text='<%# Bind("clientname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Shipment" SortExpression="shipmentname">
                        <ItemTemplate>
                            <asp:Label ID="Labelshipmentname" runat="server" Text='<%# Bind("shipmentname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" SortExpression="Description">
                        <ItemTemplate>
                            <asp:Label ID="LabelDescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="statusname">
                        <ItemTemplate>
                            <asp:Label ID="Labelstatusname" runat="server" Text='<%# Bind("statusname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="creatorname" HeaderText="Created By" InsertVisible="False" ReadOnly="True" SortExpression="creatorname" />
                    <asp:BoundField DataField="created" HeaderText="Date Ceated" InsertVisible="False" ReadOnly="True" SortExpression="created" />
                </Columns>

                <EmptyDataTemplate>
                    <div align="center">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
