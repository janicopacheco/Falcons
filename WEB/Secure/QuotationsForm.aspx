<%@ Page Title="" Language="C#" MasterPageFile="~/Secure/Site1.Master" AutoEventWireup="true" CodeBehind="QuotationsForm.aspx.cs" Inherits="Falcon.Secure.QuotationsForm" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(function () {
            $("[id*=DDLClient]").select2({
                placeholder: 'Select Client',
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLShipment]").select2({
                placeholder: 'Select Shipment',
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLStatus]").select2({
                placeholder: 'Select Status',
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DropDownListCargo]").select2({
                placeholder: 'Select Nature of Cargo',
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLCurrency]").select2({
                placeholder: 'Select Exchange Currency',
                allowClear: true
            });
        });




        //Freight Start
        $(function () {
            $("[id*=DDLFreight]").select2({
                placeholder: 'Select Particular',
                dropdownParent: $('#modalCenter1'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLFContainer]").select2({
                placeholder: 'Select Container',
                dropdownParent: $('#modalCenter1'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLFCurrency]").select2({
                placeholder: 'Select Currency',
                dropdownParent: $('#modalCenter1'),
                allowClear: true
            });
        });




        $(function () {
            $("[id*=FreightEdit]").select2({
                placeholder: 'Select Particular',
                allowClear: true
            });
        });
        //END


        //Origin Start
        $(function () {
            $("[id*=DDLOrigin]").select2({
                placeholder: 'Select Particular',
                dropdownParent: $('#modalCenter2'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLOContainer]").select2({
                placeholder: 'Select Container',
                dropdownParent: $('#modalCenter2'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLOCurrency]").select2({
                placeholder: 'Select Currency',
                dropdownParent: $('#modalCenter2'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=OriginDDLList]").select2({
                placeholder: 'Select Particular',
                allowClear: true
            });
        });
        //END

        //Local Start
        $(function () {
            $("[id*=DDLLocal]").select2({
                placeholder: 'Select Particular',
                dropdownParent: $('#modalCenter3'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLLContainer]").select2({
                placeholder: 'Select Container',
                dropdownParent: $('#modalCenter3'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=DDLLCurrency]").select2({
                placeholder: 'Select Currency',
                dropdownParent: $('#modalCenter3'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=LocalDDLList]").select2({
                placeholder: 'Select Particular',
                allowClear: true
            });
        });
        //END

        //Cotainer Start
        $(function () {
            $("[id*=DDLContainer]").select2({
                placeholder: 'Select Container',
                dropdownParent: $('#modalCenter4'),
                allowClear: true
            });
        });

        $(function () {
            $("[id*=ContainerDDLList]").select2({
                placeholder: 'Select Particular',
                allowClear: true
            });
        });
        //END


        window.onload = function () {
            document.getElementById('master-quotation').classList.add("active");
        };

        function OpenFreight() {

            var myModal = new bootstrap.Modal(document.getElementById('modalCenter1'), {
                keyboard: false
            })

            myModal.show();
        }


        function OpenOrigin() {

            var myModal = new bootstrap.Modal(document.getElementById('modalCenter2'), {
                keyboard: false
            })

            myModal.show();
        }

        function OpenLocal() {

            var myModal = new bootstrap.Modal(document.getElementById('modalCenter3'), {
                keyboard: false
            })

            myModal.show();
        }

    </script>

    <style type="text/css">
        .table {
            border-left: white !important;
            border-right: white !important;
        }

        .table-height-min {
            min-height: 300px !important;
        }

        .select2-container {
            width: 100% !important;
        }

        #ContentPlaceHolder1_GridView1 .select2-container {
            width: 180px !important;
        }

        #ContentPlaceHolder1_GridView2 .select2-container {
            width: 180px !important;
        }

        #ContentPlaceHolder1_GridView3 .select2-container {
            width: 180px !important;
        }

        #ContentPlaceHolder1_TextBoxFEx {
            height: 29px !important;
        }

        #ContentPlaceHolder1_TextBoxOEx {
            height: 29px !important;
        }

        #ContentPlaceHolder1_TextBoxLEx {
            height: 29px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Quotation - </span>Add/Edit </h4>


    <div class="row">
        <div class="col-xxl">
            <div class="card mb-4">
                <div class="card-header d-flex align-items-center justify-content-between">
                    <h5 class="mb-0">Maintenance Form</h5>



                    <small class="text-muted float-end">
                        <asp:LinkButton runat="server" ID="LnkBtnDownload" CssClass="btn btn-outline-primary" OnClick="LnkBtnDownload_Click"><span class="tf-icons bx bx-download"></span> &nbsp; Download Quotation</asp:LinkButton></small>
                </div>
                <div class="card-body">
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Name <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DDLClient" CssClass="form-control" DataTextField="name" DataValueField="id"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredClient" runat="server" ControlToValidate="DDLClient" Display="None" ErrorMessage="Client is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Date</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxDate" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>




                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Description <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxDescription" CssClass="form-control" ValidationGroup="save" placeholder="Description"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredDescription" runat="server" ControlToValidate="TextBoxDescription" Display="None" ErrorMessage="Description is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Gross Weight (kgs) <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxWeight" CssClass="form-control" ValidationGroup="save" placeholder="Weight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxWeight" Display="None" ErrorMessage="Weight is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Dimension/s (CBM) <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxDimension" CssClass="form-control" ValidationGroup="save" placeholder="Dimension"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxDimension" Display="None" ErrorMessage="Dimension is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>




                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">POL <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPOL" CssClass="form-control" ValidationGroup="save" placeholder="POL"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPOL" Display="None" ErrorMessage="POL is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">POD <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPOD" CssClass="form-control" ValidationGroup="save" placeholder="POD"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPOD" Display="None" ErrorMessage="POD is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Pick up Address <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPickup" CssClass="form-control" ValidationGroup="save" placeholder="Pick up Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxPickup" Display="None" ErrorMessage="Pick up Address is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Carrier</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxCarrier" CssClass="form-control" ValidationGroup="save" placeholder="Carrier"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Rate Validity</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxTransit" CssClass="form-control" ValidationGroup="save" TextMode="Date"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Nature of Cargo</label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DropDownListCargo" CssClass="form-control">
                                <asp:ListItem Text="General Cargo" Value="General Cargo"></asp:ListItem>
                                <asp:ListItem Text="Dangerous Cargo" Value="Dangerous Cargo"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Transit Time</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxRateValidity" CssClass="form-control" ValidationGroup="save" placeholder="Rate Validity"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Payment Terms</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPaymentTerms" CssClass="form-control" ValidationGroup="save" placeholder="Payment Terms"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Exchange Currency <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DDLCurrency" DataValueField="name" DataTextField="name" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DDLCurrency" Display="None" ErrorMessage="Exchange Currency is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Exchange Rate <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxRate" CssClass="form-control" ValidationGroup="save" placeholder="Exchange Rate" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxRate" Display="None" ErrorMessage="Exchange Rate is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Status</label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DDLStatus" CssClass="form-control" DataTextField="name" DataValueField="id"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Prepared By</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPreparedBy" CssClass="form-control" ValidationGroup="save" placeholder="Prepared By"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-company">Position</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="TextBoxPosition" CssClass="form-control" ValidationGroup="save" placeholder="Position"></asp:TextBox>
                        </div>
                    </div>



                    <div class="row mb-3">
                        <label class="col-sm-2 col-form-label" for="basic-default-name">Shipment <span class="field-required">*</span></label>
                        <div class="col-sm-10">
                            <asp:DropDownList runat="server" ID="DDLShipment" CssClass="form-control" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="DDLShipment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLShipment" Display="None" ErrorMessage="Shipment is required." ValidationGroup="save">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <asp:Panel runat="server" ID="PanelVolume" Visible="false">
                        <div class="row mb-3">
                            <%--VOLUME--%>
                            <label class="col-sm-2 col-form-label" for="basic-default-company">Chargeable Weight <span class="field-required">*</span></label>
                            <div class="col-sm-10">
                                <asp:TextBox runat="server" ID="TextBoxVolume" CssClass="form-control" ValidationGroup="save" placeholder="Chargeable Weight" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxVolume" Display="None" ErrorMessage="Volume is required." ValidationGroup="save" Enabled="false">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </asp:Panel>



                    <asp:Panel runat="server" ID="PanelContainer" Visible="false">
                        <div class="row mb-3">

                            <!-- Modal -->
                            <div class="modal fade" id="modalCenter4" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="modalCenter4Title">Add New Container</h5>
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
                                                    <label class="form-label">Particular</label>
                                                    <br />
                                                    <div>
                                                        <asp:DropDownList runat="server" ID="DDLContainer" DataValueField="id" DataTextField="name" CssClass="form-control"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row g-2">
                                                <div class="col mb-0">
                                                    <label class="form-label">Qty</label>
                                                    <asp:TextBox runat="server" ID="txtContainerQty" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator19" ControlToValidate="txtContainerQty" Display="None" ErrorMessage="Qty is required." ValidationGroup="container"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                                                Close
                               
                                            </button>
                                            <asp:Button runat="server" ID="BtnContainer" Text="Save" CssClass="btn btn-primary" ValidationGroup="container" OnClick="BtnContainer_Click" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <label class="col-sm-2 col-form-label" for="basic-default-company">Containers<span class="field-required">*</span></label>
                            <div class="col-sm-10">
                                <div style="width: 40%; padding-bottom: 20px;">
                                    <asp:GridView runat="server"
                                        ID="GridView4"
                                        AutoGenerateColumns="False"
                                        DataKeyNames="id"
                                        AllowPaging="false"
                                        CssClass="table"
                                        HeaderStyle-CssClass="table-dark"
                                        OnRowDeleting="GridView4_RowDeleting"
                                        OnRowDataBound="GridView4_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <div class="dropdown">
                                                        <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                                            <i class="bx bx-dots-vertical-rounded"></i>
                                                        </button>
                                                        <div class="dropdown-menu">
                                                            <a class="dropdown-item" data-bs-toggle="modal" data-bs-target="#modalCenter4">
                                                                <i class="bx bx-plus me-1"></i>Add
                                                            </a>
                                                            <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Container" SortExpression="container_name">
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="hdnContainerId" Value='<%# Bind("container_id") %>' />
                                                    <asp:Label ID="Labelcontainer_name" runat="server" Text='<%# Bind("container_name") %>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="Labelqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>

                                        <EmptyDataTemplate>
                                            <div align="center">No records found.</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>

                                </div>

                            </div>
                        </div>
                    </asp:Panel>



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

    <asp:Panel runat="server" ID="Panel1">
        <div class="card">
            <h5 class="card-header">Freight Charges</h5>
            <!-- Modal -->

            <div class="modal fade" id="modalCenter1" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalCenterTitle">Add New Frieght Charges
                                <asp:Label runat="server" ID="lblFreightId" Text=""></asp:Label></h5>
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
                                    <label class="form-label">Particular</label>
                                    <br />
                                    <div>
                                        <asp:DropDownList runat="server" ID="DDLFreight" DataValueField="id" DataTextField="name" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="DDLFreight" Display="None" ErrorMessage="Particular is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Currency</label>
                                    <asp:DropDownList runat="server" ID="DDLFCurrency" DataValueField="id" DataTextField="name" CssClass="form-control" OnSelectedIndexChanged="DDLFCurrency_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <%--    <asp:TextBox runat="server" ID="TextBoxFCurrency" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFCurrency" ControlToValidate="DDLFCurrency" Display="None" ErrorMessage="Currency is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col mb-0">
                                    <label class="form-label">Currency Exchange</label>
                                    <asp:TextBox runat="server" ID="TextBoxFEx" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxFEx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator22" ControlToValidate="TextBoxFEx" Display="None" ErrorMessage="Currency Exchange is required." ValidationGroup="freight"></asp:RequiredFieldValidator>


                                </div>

                            </div>
                            <div class="row g-2">

                                <div class="col mb-0">

                                    <asp:Panel runat="server" ID="PanelFVolume">
                                        <label class="form-label">Chargeable Weight</label>
                                        <asp:TextBox runat="server" ID="TextBoxFVolume" CssClass="form-control" onkeypress="return isNumberKey(event)" OnTextChanged="TextBoxFVolume_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="TextBoxFVolume" Display="None" ErrorMessage="Chargeable Weight is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="PanelFContainer">
                                        <label class="form-label">Container</label>
                                        <asp:DropDownList runat="server" ID="DDLFContainer" DataValueField="id" DataTextField="ddlvalue" CssClass="form-control" OnSelectedIndexChanged="DDLFContainer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="DDLFContainer" Display="None" ErrorMessage="Container is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                    </asp:Panel>

                                </div>


                            </div>
                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Unit Price</label>
                                    <asp:TextBox runat="server" ID="TextBoxFUnitPrice" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxFUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFUnitPrice" ControlToValidate="TextBoxFUnitPrice" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                </div>
                                <%-- <div class="col mb-0">
                                    <label class="form-label">Qty</label>
                                    <asp:TextBox runat="server" ID="TextBoxFQty" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFQty" ControlToValidate="TextBoxFQty" Display="None" ErrorMessage="Qty is required." ValidationGroup="freight"></asp:RequiredFieldValidator>

                                </div>--%>
                                <div class="col mb-0">
                                    <label class="form-label">Total Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxFTotalAmount" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFTotalAmount" ControlToValidate="TextBoxFTotalAmount" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="freight"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Estimated Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxFEstimate" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Remarks</label>
                                    <asp:TextBox runat="server" ID="TextBoxFRemarks" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                                Close
                               
                            </button>
                            <asp:Button runat="server" ID="BtnFSave" Text="Save" CssClass="btn btn-primary" ValidationGroup="freight" OnClick="BtnFSave_Click" />

                        </div>
                    </div>
                </div>
            </div>

            <div class="table-responsive text-nowrap table-height-min">
                <asp:GridView runat="server"
                    ID="GridView1"
                    AutoGenerateColumns="False"
                    DataKeyNames="id"
                    AllowPaging="True"
                    PageSize="10"
                    CssClass="table"
                    HeaderStyle-CssClass="table-dark"
                    OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDeleting="GridView1_RowDeleting"
                    OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowDataBound="GridView1_RowDataBound"
                    OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonAdd" CssClass="dropdown-item" CommandName="ActionAdd">
                                            <i class="bx bx-plus me-1"></i>Add
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item" CommandName="ActionEdit" CommandArgument='<%#Bind("id")%>'>
                                            <i class="bx bx-edit-alt me-1"></i>Edit
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                        </asp:LinkButton>
                                        <asp:HiddenField runat="server" ID="hdnFreightId" Value='<%# Bind("id") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonSave" CssClass="dropdown-item" CommandName="Update" ValidationGroup="freightedit">
                                        <i class="bx bx-edit-alt me-1"></i>Update
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="dropdown-item" CommandName="Cancel" CausesValidation="False">
                                        <i class="bx bx-exit me-1"></i>Cancel
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Particular/s" SortExpression="particularname">
                            <ItemTemplate>
                                <asp:Label ID="Labelparticularname" runat="server" Text='<%# Bind("particularname") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField runat="server" ID="HdnDDLFrieghtEdit" Value='<%# Bind("particularid") %>' />
                                <asp:DropDownList runat="server" ID="FreightEdit" DataValueField="id" DataTextField="name" Width="200px"></asp:DropDownList>
                            </EditItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Currency" SortExpression="currency">
                            <ItemTemplate>
                                <asp:Label ID="Labelcurrency" runat="server" Text='<%# Bind("currency") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFCurrencyEdit" CssClass="form-control" Text='<%# Bind("currency") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFCurrencyEdit" ControlToValidate="TextBoxFCurrencyEdit" Display="None" ErrorMessage="Currency is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price" SortExpression="unit_price">
                            <ItemTemplate>
                                <asp:Label ID="Labelunit_price" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("unit_price").ToString()) ? "0": Eval("unit_price").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFUnitPriceEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("unit_price") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFUnitPriceEdit" ControlToValidate="TextBoxFUnitPriceEdit" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                            <ItemTemplate>
                                <asp:Label ID="Labelqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFQtyEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("qty") %>' Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFQtyEdit" ControlToValidate="TextBoxFQtyEdit" Display="None" ErrorMessage="Qty is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount" SortExpression="total_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labeltotal_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("total_amount").ToString()) ? "0": Eval("total_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFTotalAmountEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("total_amount") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFTotalAmountEdit" ControlToValidate="TextBoxFTotalAmountEdit" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estimated Amount" SortExpression="agent_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labelagent_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("agent_amount").ToString()) ? "0": Eval("agent_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Remarks" SortExpression="remarks">
                            <ItemTemplate>
                                <asp:Label ID="Labelremarkst" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFRemarksEdit" Width="175px" CssClass="form-control" TextMode="MultiLine" Text='<%# Bind("remarks") %>'></asp:TextBox>
                            </EditItemTemplate>
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

            <div class="card-header">
                Sub Total:
                <asp:Label runat="server" ID="lblFreightTotal"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <div class="card">
            <h5 class="card-header">Origin Charges</h5>
            <!-- Modal -->
            <div class="modal fade" id="modalCenter2" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalCenterTitle2">Add New Origin Charges
                                <asp:Label runat="server" ID="lblOriginId"></asp:Label></h5>
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
                                    <label class="form-label">Particular</label>
                                    <br />
                                    <div>
                                        <asp:DropDownList runat="server" ID="DDLOrigin" DataValueField="id" DataTextField="name" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="DDLOrigin" Display="None" ErrorMessage="Particular is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Currency</label>
                                    <asp:DropDownList runat="server" ID="DDLOCurrency" DataValueField="id" DataTextField="name" CssClass="form-control" OnSelectedIndexChanged="DDLOCurrency_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="DDLOCurrency" Display="None" ErrorMessage="Currency is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col mb-0">
                                    <label class="form-label">Currency Exchange</label>
                                    <asp:TextBox runat="server" ID="TextBoxOEx" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxOEx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator23" ControlToValidate="TextBoxOEx" Display="None" ErrorMessage="Currency Exchange is required." ValidationGroup="origin"></asp:RequiredFieldValidator>


                                </div>

                            </div>


                            <div class="row g-2">
                                <div class="col mb-0">
                                    <asp:Panel runat="server" ID="PanelOVolume">
                                        <label class="form-label">Chargeable Weight</label>
                                        <asp:TextBox runat="server" ID="TextBoxOVolume" CssClass="form-control" onkeypress="return isNumberKey(event)" OnTextChanged="TextBoxOVolume_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredOVolume" ControlToValidate="TextBoxOVolume" Display="None" ErrorMessage="Chargeable Weight is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="PanelOContainer">
                                        <label class="form-label">Container</label>
                                        <asp:DropDownList runat="server" ID="DDLOContainer" DataValueField="id" DataTextField="ddlvalue" CssClass="form-control" OnSelectedIndexChanged="DDLOContainer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredOContainer" ControlToValidate="DDLOContainer" Display="None" ErrorMessage="Container is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                    </asp:Panel>
                                </div>



                            </div>
                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Unit Price</label>
                                    <asp:TextBox runat="server" ID="TextBoxOUnitPrice" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxOUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="TextBoxOUnitPrice" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                </div>

                                <%--  <div class="col mb-0">
                                    <label class="form-label">Qty</label>
                                    <asp:TextBox runat="server" ID="TextBoxOQty" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="TextBoxOQty" Display="None" ErrorMessage="Qty is required." ValidationGroup="origin"></asp:RequiredFieldValidator>

                                </div>--%>
                                <div class="col mb-0">
                                    <label class="form-label">Total Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxOTotalAmount" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="TextBoxOTotalAmount" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="origin"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Estimated Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxOEstimate" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Remarks</label>
                                    <asp:TextBox runat="server" ID="TextBoxORemarks" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                                Close
                               
                            </button>
                            <asp:Button runat="server" ID="BtnOSave" Text="Save" CssClass="btn btn-primary" ValidationGroup="origin" OnClick="BtnOSave_Click" />

                        </div>
                    </div>
                </div>
            </div>
            <div class="table-responsive text-nowrap table-height-min">
                <asp:GridView runat="server"
                    ID="GridView2"
                    AutoGenerateColumns="False"
                    DataKeyNames="id"
                    AllowPaging="True"
                    PageSize="10"
                    CssClass="table"
                    HeaderStyle-CssClass="table-dark"
                    OnPageIndexChanging="GridView2_PageIndexChanging"
                    OnRowDeleting="GridView2_RowDeleting"
                    OnRowEditing="GridView2_RowEditing"
                    OnRowUpdating="GridView2_RowUpdating"
                    OnRowCancelingEdit="GridView2_RowCancelingEdit"
                    OnRowDataBound="GridView2_RowDataBound"
                    OnRowCommand="GridView2_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonAdd" CssClass="dropdown-item" CommandName="ActionAdd">
                                       <i class="bx bx-plus me-1"></i>Add
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item" CommandName="ActionEdit" CommandArgument='<%#Bind("id")%>'>
                                        <i class="bx bx-edit-alt me-1"></i>Edit
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                        </asp:LinkButton>
                                        <asp:HiddenField runat="server" ID="hdnOriginId" Value='<%# Bind("id") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonSave" CssClass="dropdown-item" CommandName="Update" ValidationGroup="originedit">
                                        <i class="bx bx-edit-alt me-1"></i>Update
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="dropdown-item" CommandName="Cancel" CausesValidation="False">
                                        <i class="bx bx-exit me-1"></i>Cancel
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Particular/s" SortExpression="particularname">
                            <ItemTemplate>
                                <asp:Label ID="Labelparticularname" runat="server" Text='<%# Bind("particularname") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField runat="server" ID="HdnDDLOriginEdit" Value='<%# Bind("particularid") %>' />
                                <asp:DropDownList runat="server" ID="OriginDDLList" DataValueField="id" DataTextField="name" Width="200px"></asp:DropDownList>
                            </EditItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Currency" SortExpression="currency">
                            <ItemTemplate>
                                <asp:Label ID="Labelcurrency" runat="server" Text='<%# Bind("currency") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxOCurrencyEdit" CssClass="form-control" Text='<%# Bind("currency") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredOCurrencyEdit" ControlToValidate="TextBoxOCurrencyEdit" Display="None" ErrorMessage="Currency is required." ValidationGroup="originedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price" SortExpression="unit_price">
                            <ItemTemplate>
                                <asp:Label ID="Labelunit_price" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("unit_price").ToString()) ? "0": Eval("unit_price").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFUnitPriceEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("unit_price") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFUnitPriceEdit" ControlToValidate="TextBoxFUnitPriceEdit" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                            <ItemTemplate>
                                <asp:Label ID="Labelqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFQtyEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("qty") %>' Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFQtyEdit" ControlToValidate="TextBoxFQtyEdit" Display="None" ErrorMessage="Qty is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount" SortExpression="total_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labeltotal_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("total_amount").ToString()) ? "0": Eval("total_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxFTotalAmountEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("total_amount") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFTotalAmountEdit" ControlToValidate="TextBoxFTotalAmountEdit" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="freightedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estimated Amount" SortExpression="agent_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labelagent_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("agent_amount").ToString()) ? "0": Eval("agent_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remarks">
                            <ItemTemplate>
                                <asp:Label ID="Labelremarkst" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxORemarksEdit" Width="175px" CssClass="form-control" TextMode="MultiLine" Text='<%# Bind("remarks") %>'></asp:TextBox>
                            </EditItemTemplate>
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

            <div class="card-header">
                Sub Total:
                <asp:Label runat="server" ID="lblOriginTotal"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <div class="card">
            <h5 class="card-header">Destination Local Charges</h5>
            <!-- Modal -->
            <div class="modal fade" id="modalCenter3" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="modalCenterTitle3">Add New Destination Local Charges
                                <asp:Label runat="server" ID="lblLocalId"></asp:Label></h5>
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
                                    <label class="form-label">Particular</label>
                                    <br />
                                    <div>
                                        <asp:DropDownList runat="server" ID="DDLLocal" DataValueField="id" DataTextField="name" CssClass="form-control"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="DDLLocal" Display="None" ErrorMessage="Particular is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Currency</label>
                                    <asp:DropDownList runat="server" ID="DDLLCurrency" DataValueField="id" DataTextField="name" CssClass="form-control" OnSelectedIndexChanged="DDLLCurrency_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="DDLLCurrency" Display="None" ErrorMessage="Currency is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col mb-0">
                                    <label class="form-label">Currency Exchange</label>
                                    <asp:TextBox runat="server" ID="TextBoxLEx" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxLEx_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator24" ControlToValidate="TextBoxLEx" Display="None" ErrorMessage="Currency Exchange is required." ValidationGroup="local"></asp:RequiredFieldValidator>


                                </div>

                            </div>

                            <div class="row g-2">
                                <div class="col mb-0">
                                    <asp:Panel runat="server" ID="PanelLVolume">
                                        <label class="form-label">Chargeable Weight</label>
                                        <asp:TextBox runat="server" ID="TextBoxLVolume" CssClass="form-control" onkeypress="return isNumberKey(event)" OnTextChanged="TextBoxLVolume_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredLVolume" ControlToValidate="TextBoxLVolume" Display="None" ErrorMessage="Chargeable Weight is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="PanelLContainer">
                                        <label class="form-label">Container</label>
                                        <asp:DropDownList runat="server" ID="DDLLContainer" DataValueField="id" DataTextField="ddlvalue" CssClass="form-control" OnSelectedIndexChanged="DDLLContainer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredLContainer" ControlToValidate="DDLLContainer" Display="None" ErrorMessage="Container is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                    </asp:Panel>

                                </div>




                            </div>
                            <div class="row g-2">
                                <div class="col mb-0">
                                    <label class="form-label">Unit Price</label>
                                    <asp:TextBox runat="server" ID="TextBoxLUnitPrice" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" OnTextChanged="TextBoxLUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="TextBoxLUnitPrice" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                </div>
                                <%--           <div class="col mb-0">
                                    <label class="form-label">Qty</label>
                                    <asp:TextBox runat="server" ID="TextBoxLQty" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="TextBoxLQty" Display="None" ErrorMessage="Qty is required." ValidationGroup="local"></asp:RequiredFieldValidator>

                                </div>--%>
                                <div class="col mb-0">
                                    <label class="form-label">Total Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxLTotalAmount" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="TextBoxLTotalAmount" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="local"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Estimated Amount</label>
                                    <asp:TextBox runat="server" ID="TextBoxLEstimate" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col mb-3">
                                    <label class="form-label">Remarks</label>
                                    <asp:TextBox runat="server" ID="TextBoxLRemarks" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-outline-secondary" data-bs-dismiss="modal">
                                Close
                               
                            </button>
                            <asp:Button runat="server" ID="BtnLSave" Text="Save" CssClass="btn btn-primary" ValidationGroup="local" OnClick="BtnLSave_Click" />

                        </div>
                    </div>
                </div>
            </div>
            <div class="table-responsive text-nowrap table-height-min">
                <asp:GridView runat="server"
                    ID="GridView3"
                    AutoGenerateColumns="False"
                    DataKeyNames="id"
                    AllowPaging="True"
                    PageSize="10"
                    CssClass="table"
                    HeaderStyle-CssClass="table-dark"
                    OnPageIndexChanging="GridView3_PageIndexChanging"
                    OnRowDeleting="GridView3_RowDeleting"
                    OnRowEditing="GridView3_RowEditing"
                    OnRowUpdating="GridView3_RowUpdating"
                    OnRowCancelingEdit="GridView3_RowCancelingEdit"
                    OnRowDataBound="GridView3_RowDataBound"
                    OnRowCommand="GridView3_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonAdd" CssClass="dropdown-item" CommandName="ActionAdd">
                                            <i class="bx bx-plus me-1"></i>Add
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonEdit" CssClass="dropdown-item" CommandName="ActionEdit" CommandArgument='<%#Bind("id")%>'>
                                            <i class="bx bx-edit-alt me-1"></i>Edit
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LnkButtonDelete" CssClass="dropdown-item" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandName="Delete">
                                        <i class="bx bx-trash me-1"></i>Delete
                                        </asp:LinkButton>
                                        <asp:HiddenField runat="server" ID="hdnLocalId" Value='<%# Bind("id") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="dropdown">
                                    <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                                        <i class="bx bx-dots-vertical-rounded"></i>
                                    </button>
                                    <div class="dropdown-menu">
                                        <asp:LinkButton runat="server" ID="LnkButtonSave" CssClass="dropdown-item" CommandName="Update" ValidationGroup="localedit">
                                        <i class="bx bx-edit-alt me-1"></i>Update
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LinkButtonCancel" CssClass="dropdown-item" CommandName="Cancel" CausesValidation="False">
                                        <i class="bx bx-exit me-1"></i>Cancel
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </EditItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Particular/s" SortExpression="particularname">
                            <ItemTemplate>
                                <asp:Label ID="Labelparticularname" runat="server" Text='<%# Bind("particularname") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField runat="server" ID="HdnDDLLocalEdit" Value='<%# Bind("particularid") %>' />
                                <asp:DropDownList runat="server" ID="LocalDDLList" DataValueField="id" DataTextField="name" Width="200px"></asp:DropDownList>
                            </EditItemTemplate>

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Currency" SortExpression="currency">
                            <ItemTemplate>
                                <asp:Label ID="Labelcurrency" runat="server" Text='<%# Bind("currency") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxLCurrencyEdit" CssClass="form-control" Text='<%# Bind("currency") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredLCurrencyEdit" ControlToValidate="TextBoxLCurrencyEdit" Display="None" ErrorMessage="Currency is required." ValidationGroup="localedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Price" SortExpression="unit_price">
                            <ItemTemplate>
                                <asp:Label ID="Labelunit_price" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("unit_price").ToString()) ? "0": Eval("unit_price").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxLUnitPriceEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("unit_price") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredLUnitPriceEdit" ControlToValidate="TextBoxLUnitPriceEdit" Display="None" ErrorMessage="Unit Price is required." ValidationGroup="localedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="qty">
                            <ItemTemplate>
                                <asp:Label ID="Labelqty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxLQtyEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("qty") %>' Width="50px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredLQtyEdit" ControlToValidate="TextBoxLQtyEdit" Display="None" ErrorMessage="Qty is required." ValidationGroup="localedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount" SortExpression="total_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labeltotal_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("total_amount").ToString()) ? "0": Eval("total_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxLTotalAmountEdit" CssClass="form-control" onkeypress="return isNumberKey(event)" onkeyup="javascript:this.value=Comma(this.value);" Text='<%# Bind("total_amount") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredLTotalAmountEdit" ControlToValidate="TextBoxLTotalAmountEdit" Display="None" ErrorMessage="Total Amount is required." ValidationGroup="localedit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estimated Amount" SortExpression="agent_amount">
                            <ItemTemplate>
                                <asp:Label ID="Labelagent_amount" runat="server" Text='<%# Convert.ToDouble( string.IsNullOrEmpty(Eval("agent_amount").ToString()) ? "0": Eval("agent_amount").ToString()).ToString("N")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks" SortExpression="remarks">
                            <ItemTemplate>
                                <asp:Label ID="Labelremarkst" runat="server" Text='<%# Bind("remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="TextBoxLRemarksEdit" Width="175px" CssClass="form-control" TextMode="MultiLine" Text='<%# Bind("remarks") %>'></asp:TextBox>
                            </EditItemTemplate>
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

            <div class="card-header">
                Sub Total:
                <asp:Label runat="server" ID="lblLocalTotal"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <div class="card">
            <h5 class="card-header">Estimated Revenue</h5>

            <div class="table-responsive text-nowrap">
                <table class="table table-bordered">
                    <tr class="table-primary">
                        <th colspan="4">Freight Charges</th>
                    </tr>
                    <tr>
                        <th>PARTICULAR/S</th>
                        <th>TOTAL AMOUNT</th>
                        <th>ESTIMATED AMOUNT</th>
                        <th>NET EARNINGS</th>
                    </tr>
                    <asp:Repeater runat="server" ID="RepeaterF">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("particularname") %></td>
                                <td><%#Eval("total_amount") %></td>
                                <td><%#Eval("agent_amount") %></td>
                                <td><%#Eval("net_earnings") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>


                    <tr class="table-danger">
                        <th colspan="4">Origin Charges</th>
                    </tr>
                    <tr>
                        <th>PARTICULAR/S</th>
                        <th>TOTAL AMOUNT</th>
                        <th>ESTIMATED AMOUNT</th>
                        <th>NET EARNINGS</th>
                    </tr>
                    <asp:Repeater runat="server" ID="RepeaterO">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("particularname") %></td>
                                <td><%#Eval("total_amount") %></td>
                                <td><%#Eval("agent_amount") %></td>
                                <td><%#Eval("net_earnings") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>


                    <tr class="table-warning">
                        <th colspan="4">Local Charges</th>
                    </tr>
                    <tr>
                        <th>PARTICULAR/S</th>
                        <th>TOTAL AMOUNT</th>
                        <th>ESTIMATED AMOUNT</th>
                        <th>NET EARNINGS</th>
                    </tr>
                    <asp:Repeater runat="server" ID="RepeaterL">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("particularname") %></td>
                                <td><%#Eval("total_amount") %></td>
                                <td><%#Eval("agent_amount") %></td>
                                <td><%#Eval("net_earnings") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr class="table-info">
                        <td colspan="3"><strong>TOTAL:</strong></td>
                        <td><strong>
                            <asp:Label runat="server" ID="lblEarnings"></asp:Label></strong></td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />


    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="save"></asp:ValidationSummary>

    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="freight"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="freightedit"></asp:ValidationSummary>

    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="origin"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="originedit"></asp:ValidationSummary>

    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="local"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary7" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="localedit"></asp:ValidationSummary>


    <asp:ValidationSummary ID="ValidationSummary8" runat="server" ShowMessageBox="True" ShowSummary="False" HeaderText="Record could not be saved." ValidationGroup="container"></asp:ValidationSummary>




</asp:Content>
