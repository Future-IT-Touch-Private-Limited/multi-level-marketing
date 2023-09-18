<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .db_counter {
            border: 1px solid gray;
            box-shadow: 2px 2px 5px gray;
            border-radius: 50px;
            padding-top: 7px;
            padding-bottom: 3px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row g-3 mb-3">
        <div class="col-xxl-6">
            <div class="row g-0 h-100">

                <div class="col-12">


                    <div class="col-xxl-6 col-xl-12">
                        <div class="card py-3 mb-3">
                            <div class="card-body py-3">
                                <div class="row g-0">
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Today's Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="today_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Today's Daily Level Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="today_daily_level_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Today's Referral Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="today_referral_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Total Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="total_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Referral Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="referral_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Weekly Salery Income </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="weekly_salery_income_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Total Users </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">
                                                <asp:Label ID="total_users_count_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Premium Users </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">
                                                <asp:Label ID="premium_users_count_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter">
                                            <h6 class="pb-1 text-700">Basic Users </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">
                                                <asp:Label ID="basic_users_count_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter bg-primary">
                                            <h6 class="pb-1 text-700 text-white">Total Recharge </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1 text-white" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="total_recharge_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter bg-danger">
                                            <h6 class="pb-1 text-700 text-white">Total Withdrawal </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1 text-white" style="text-shadow: 0px 1px 2px lightblue;">₹
                                                <asp:Label ID="total_withdrawal_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="col-6 col-md-4 pb-4 ps-3 text-center">
                                        <div class="db_counter" style="background: #00D27A; color: #fff">
                                            <h6 class="pb-1 text-700 text-white">Total Available Balance </h6>
                                            <p class="font-sans-serif lh-1 mb-1 fs-1" style="text-shadow: 0px 1px 2px lightblue;">
                                                ₹
                                                <asp:Label ID="total_available_balance_lbl" runat="server" Text="0"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
