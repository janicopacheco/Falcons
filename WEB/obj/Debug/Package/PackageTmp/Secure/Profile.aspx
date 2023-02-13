<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Falcon.Secure.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Profile - </span>Information</h4>



<%--    <img src="../assets/image/logo.png" />--%>

    <div class="row">
        <div class="col-xxl">
            <div class="card mb-4">
                <div class="card-header d-flex align-items-center justify-content-between">
                    <h5 class="mb-0">User Information Form</h5>
                    <small class="text-muted float-end">Update User details</small>
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Username</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxUsername" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Role</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxRole" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">First Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxFName" CssClass="form-control" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxFName" Display="None" ErrorMessage="First Name is required." ValidationGroup="save">
                                    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Middle Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxMName" CssClass="form-control" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxMName" Display="None" ErrorMessage="Middle Name is required." ValidationGroup="save">
                                    </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Last Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxLName" CssClass="form-control" ValidationGroup="save"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxLName" Display="None" ErrorMessage="Last Name is required." ValidationGroup="save">
                                    </asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <div class="row justify-content-end">
                        <div class="col-sm-10">
                            <asp:Button runat="server" ID="ButtonSave" CssClass="btn btn-dark" Text="Update" ValidationGroup="save" OnClick="ButtonSave_Click" />

                            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#modalCenter1">Change Password</button>

                            <asp:Button runat="server" ID="ButtonPdf" OnClick="ButtonPdf_Click" Text="PDF" Visible="false" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

    <!-- Modal -->
    <div class="modal fade" id="modalCenter1" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalCenterTitle">Change Password</h5>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                        aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col mb-3">
                            <label class="form-label">Old Password</label>
                            <asp:TextBox runat="server" ID="TextBoxOld" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxOld" Display="None" ErrorMessage="Old Password is required." ValidationGroup="ProfileChangePassword">
                            </asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col mb-3">
                            <label class="form-label">New Password</label>
                            <asp:TextBox runat="server" ID="TextBoxNew" CssClass="form-control" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNew" Display="None" ErrorMessage="New Password is required." ValidationGroup="ProfileChangePassword">
                                    </asp:RequiredFieldValidator>

                        </div>
                        <div class="col mb-3">
                            <label class="form-label">Confirm Password</label>
                            <asp:TextBox runat="server" ID="TextBoxConfirm" CssClass="form-control" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxConfirm" Display="None" ErrorMessage="Confirm Password is required." ValidationGroup="ProfileChangePassword">
                                    </asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="TextBoxConfirm" ControlToCompare="TextBoxNew" Operator="Equal" ErrorMessage="New Password and Confirm Password should equal." ValidationGroup="ProfileChangePassword" Display="None"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                        Close
                               
                    </button>
                    <asp:Button runat="server" ID="BtnUpdatePassword" Text="Update" CssClass="btn btn-primary" OnClick="BtnUpdatePassword_Click" ValidationGroup="ProfileChangePassword" />

                </div>
            </div>
        </div>
    </div>


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="save"></asp:ValidationSummary>

    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="ProfileChangePassword"></asp:ValidationSummary>

</asp:Content>
