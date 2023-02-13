<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="TermsConditionsForm.aspx.cs" Inherits="Falcon.Secure.TermsConditionsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        window.onload = function () {
            document.getElementById('master-tc').classList.add("active");
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Terms & Conditions - </span>Add/Edit</h4>

    <div class="row">
        <div class="col-xxl">
            <div class="card mb-4">
                <div class="card-header d-flex align-items-center justify-content-between">
                    <h5 class="mb-0">Maintenance Form</h5>
                    <small class="text-muted float-end">Create and Update terms & conditions</small>
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Content <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxName" CssClass="form-control" ValidationGroup="save" placeholder="Content" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredName" runat="server" ControlToValidate="TextBoxName" Display="None" ErrorMessage="Content is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Sequence <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxSequence" CssClass="form-control" ValidationGroup="save" placeholder="Sequence" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredSequence" runat="server" ControlToValidate="TextBoxSequence" Display="None" ErrorMessage="Sequence is required." ValidationGroup="save">
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
