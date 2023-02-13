<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="Falcon.Secure.CustomerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-manage').classList.add("active");
            document.getElementById('master-manage').classList.add("open");
            document.getElementById('manage-client').classList.add("active");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Client - </span>Add/Edit</h4>

    <div class="row">
        <div class="col-xxl">
            <div class="card mb-4">
                <div class="card-header d-flex align-items-center justify-content-between">
                    <h5 class="mb-0">Maintenance Form</h5>
                    <small class="text-muted float-end">Create and Update clients</small>
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxName" CssClass="form-control" ValidationGroup="save" placeholder="Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="TextBoxName" Display="None" ErrorMessage="Name is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Address</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxAddress" CssClass="form-control" ValidationGroup="save" placeholder="Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAddress" Display="None" ErrorMessage="Address is required." ValidationGroup="save" Enabled="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Tin</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxTin" CssClass="form-control" ValidationGroup="save" placeholder="Tin"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxTin" Display="None" ErrorMessage="Tin is required." ValidationGroup="save" Enabled="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Contact No.</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxContactNo" CssClass="form-control" ValidationGroup="save" placeholder="Contact No."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxContactNo" Display="None" ErrorMessage="Contact No is required." ValidationGroup="save" Enabled="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Contact Person</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxContactPerson" CssClass="form-control" ValidationGroup="save" placeholder="Contact Person"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxContactPerson" Display="None" ErrorMessage="Contact Person is required." ValidationGroup="save" Enabled="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <div class="row justify-content-end">
                        <div class="col-sm-10">
                            <asp:Button runat="server" ID="ButtonSave" CssClass="btn btn-dark" Text="Save" ValidationGroup="save" OnClick="ButtonSave_Click" />
                            <asp:Button runat="server" ID="ButtonCancel" CssClass="btn btn-danger" Text="Cancel" OnClick="ButtonCancel_Click" />

                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="save"></asp:ValidationSummary>

</asp:Content>
