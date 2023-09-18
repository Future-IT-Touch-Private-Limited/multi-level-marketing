<%@ Page Title="View Withdrawal Request" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="view-withdrawal-request.aspx.cs" Inherits="admin_view_withdrawal_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body overflow-hidden">
            <asp:HiddenField ID="username_3des_hf" Visible="false" runat="server" />
            <div runat="server" visible="false" id="errordiv" class="alert alert-danger alert-dismissible fade show" role="alert">
                <div class="row">
                    <div class="col-2">
                        <button type="button" class="btn-close" style="float: right" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                    <div class="col-10">
                        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div runat="server" visible="false" id="successdiv" class="alert alert-success alert-dismissible fade show" role="alert">
                <div class="row">
                    <div class="col-10">
                        <asp:Label ID="successlbl" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-2">
                        <button type="button" class="btn-close" style="float: right" data-bs-dismiss="alert" aria-label="Close"></button>
                    </div>
                </div>
            </div>

            <div class="row align-items-center">
                <div class="col-lg-6">
                    <h5 class="text-primary pb-2">User Details:</h5>
                    <div class="text-center">
                        <asp:Image ID="profile_pic" Style="width: 200px" runat="server" />
                    </div>
                    <div class="table-responsive">
                        <table class="table table-bordered">
                            <tr>
                                <td><strong>Username</strong></td>
                                <td>
                                    <asp:Label ID="username_3ddes_lbl" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td><strong>Bank Name</strong></td>
                                <td>
                                    <asp:Label ID="bank_name" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td><strong>Account Name</strong></td>
                                <td>
                                    <asp:Label ID="account_holder_name" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td><strong>Acc. No.</strong></td>
                                <td>
                                    <asp:Label ID="account_number" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td><strong>IFSC Code</strong></td>
                                <td>
                                    <asp:Label ID="ifsc_code" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 ps-lg-4 my-5 text-center text-lg-start">
                    <h5 class="text-primary pb-2">Withdrawal Details:
                        <asp:Label ID="package_name_lbl" runat="server" Text=""></asp:Label></h5>
                    <div class="pb-3">
                        Withdrawal Request Date:
                        <div class="ps-2 fw-bolder text-dark">
                            <asp:Label ID="request_date" runat="server" Text=""></asp:Label></div>
                    </div>
                    <div class="pb-3">
                        Withdrawal Amount (<asp:Label ID="withdrawal_amount_lbl" ForeColor="Green" Font-Bold="true" runat="server" Text="0"></asp:Label>-<asp:Label ID="total_charge_lbl" ForeColor="Red" Font-Bold="true" runat="server" Text="0"></asp:Label>=<asp:Label ID="total_payable_lbl" ForeColor="Green" Font-Bold="true" runat="server" Text="0"></asp:Label>):
                        <asp:TextBox CssClass="form-control" ReadOnly="true" ID="withdrawal_amount" runat="server"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        Transaction ID:
                        <asp:TextBox CssClass="form-control" ID="admin_set_transaction_id" runat="server"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        Note:
                        <asp:TextBox CssClass="form-control" ID="admin_set_note" runat="server"></asp:TextBox>
                    </div>
                    <asp:Panel ID="btn_box" runat="server">
                        <div>
                            <asp:CheckBox ID="confirm_cb" runat="server" Text="Confirm to continue" /></div>
                        <asp:Button ID="approve_btn" OnClick="approve_btn_Click" class="btn btn-falcon-success" runat="server" Text="Mark as paid" />
                        <asp:Button ID="reject_btn" OnClick="reject_btn_Click" class="btn btn-falcon-danger" runat="server" Text="Mark as Rejected" />
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
