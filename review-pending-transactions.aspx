<%@ Page Title="Review Pending Transactions" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="review-pending-transactions.aspx.cs" Inherits="admin_transactions_pending_review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body overflow-hidden">
            <%--<asp:HiddenField ID="first_transaction_id_hf" Visible="false" runat="server" />--%>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:HiddenField ID="referrer_1_hf" Visible="false" runat="server" />
            <asp:HiddenField ID="username_3des_hf" Visible="false" runat="server" />
            <asp:HiddenField ID="referr_income_hf" Visible="false" runat="server" />
            <asp:HiddenField ID="referr_package_id_hf" Visible="false" runat="server" />
            <asp:HiddenField ID="first_transaction_id_hf" Visible="false" runat="server" />
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
                <div class="col-lg-4">
                    <asp:Image ID="product_img" class="img-fluid" runat="server" />
                </div>
                <div class="col-lg-8 ps-lg-4 my-5 text-center text-lg-start">
                    <h5 class="text-primary pb-2">Package Name:
                        <asp:Label ID="package_name_lbl" runat="server" Text=""></asp:Label></h5>
                    <div class="pb-3">
                        Transaction Amount:
                        <asp:TextBox CssClass="form-control" TextMode="Number" ID="transaction_amt" runat="server"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        Payment Mode:
                    <asp:DropDownList ID="transaction_mode" CssClass="form-control" runat="server">
                        <asp:ListItem>UPI</asp:ListItem>
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Net Banking</asp:ListItem>
                        <asp:ListItem>Bank Deposit</asp:ListItem>
                        <asp:ListItem>Crypto</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="pb-3">
                        Transaction Date:
                        <asp:TextBox CssClass="form-control" TextMode="Date" ID="transaction_date" runat="server"></asp:TextBox>
                    </div>
                    <div class="pb-3">
                        Transaction ID:
                        <asp:TextBox CssClass="form-control" ID="transaction_id" runat="server"></asp:TextBox>
                    </div>
                    <div runat="server" id="tool_box">
                        <div><asp:CheckBox ID="confirm_cb" Text="Confirm to Approve or Reject" runat="server" /></div>
                        <asp:Button ID="approve_btn" OnClick="approve_btn_Click" class="btn btn-falcon-success" runat="server" Text="Approve Payment" />
                        <asp:Button ID="reject_btn" OnClick="reject_btn_Click" class="btn btn-falcon-danger" runat="server" Text="Reject Payment" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
