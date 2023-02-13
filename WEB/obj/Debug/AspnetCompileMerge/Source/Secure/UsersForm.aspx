<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="UsersForm.aspx.cs" Inherits="Falcon.Secure.UsersForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-users').classList.add("active");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">User - </span>Add/Edit</h4>

    <div class="row">
        <div class="col-xxl">
            <div class="card mb-4">
                <div class="card-header d-flex align-items-center justify-content-between">
                    <h5 class="mb-0">Maintenance Form</h5>
                    <small class="text-muted float-end">Create and Update users</small>
                </div>
                <div class="card-body">

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">User Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxUserName" CssClass="form-control" ValidationGroup="save" placeholder="User Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ControlToValidate="TextBoxUserName" Display="None" ErrorMessage="User Name is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxUserName" Display="None" ErrorMessage="Username must be in email format." ValidationGroup="save" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                        </div>
                    </div>


                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">First Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxFName" CssClass="form-control" ValidationGroup="save" placeholder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="TextBoxFName" Display="None" ErrorMessage="First Name is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Middle Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxMName" CssClass="form-control" ValidationGroup="save" placeholder="Middle Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredDescription" runat="server" ControlToValidate="TextBoxMName" Display="None" ErrorMessage="Middle Name is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Last Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxLName" CssClass="form-control" ValidationGroup="save" placeholder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredLName" runat="server" ControlToValidate="TextBoxLName" Display="None" ErrorMessage="Last Name is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Role <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DropDownListRole" CssClass="form-control" DataTextField="RoleName" DataValueField="RoleId">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Validity <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxValidity" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxValidity" Display="None" ErrorMessage="Validity is required." ValidationGroup="save">
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
