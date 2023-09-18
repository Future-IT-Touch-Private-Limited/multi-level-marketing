<%@ Page Title="All Users" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card mb-3" id="ordersTable" data-list="{&quot;valueNames&quot;:[&quot;order&quot;,&quot;date&quot;,&quot;address&quot;,&quot;status&quot;,&quot;amount&quot;],&quot;page&quot;:10,&quot;pagination&quot;:true}">
        <div class="card-header">
            <div class="row flex-between-center">
                <div class="col-4 col-sm-auto d-flex align-items-center pe-0">
                    <h5 class="fs-0 mb-0 text-nowrap py-2 py-xl-0">Users</h5>
                </div>
                <div class="col-8 col-sm-auto ms-auto text-end ps-0">
                    <div class="" id="orders-bulk-actions">
                        <div class="d-flex">
                            <asp:TextBox ID="searchtxt" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:Button ID="search_btn" OnClick="search_btn_Click" class="btn btn-falcon-default btn-sm ms-2" runat="server" Text="Search" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-body p-0">
            <div class="table-responsive scrollbar">
                <table class="table table-sm table-striped fs--1 mb-0 overflow-hidden">
                    <thead class="bg-200 text-900">
                        <tr>
                            <th class="sort pe-1 align-middle white-space-nowrap" data-sort="order">User Details</th>
                            <th class="sort pe-1 align-middle white-space-nowrap pe-7" data-sort="date">Account Date</th>
                            <th class="sort pe-1 align-middle white-space-nowrap" data-sort="address">Address</th>
                            <th class="sort pe-1 align-middle white-space-nowrap text-center" data-sort="status">Status</th>
                            <th class="sort pe-1 align-middle white-space-nowrap text-end">View</th>
                        </tr>
                    </thead>
                    <tbody class="list" id="table-orders-body">

                        <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr class="btn-reveal-trigger">
                                    <td class="order py-2 align-middle white-space-nowrap"><strong><%# Eval("full_name") %></strong><br>
                                        <asp:Label ID="username_3des" runat="server" Text='<%# Eval("username_3des") %>'></asp:Label>
                                    </td>
                                    <td class="date py-2 align-middle"><%# Eval("account_date") %></td>
                                    <td class="address py-2 align-middle white-space-nowrap">
                                        <%# Eval("address") %> <%# Eval("city") %> <%# Eval("state") %> <%# Eval("country") %> <%# Eval("pin_code") %>
                                    </td>
                                    <td class="status py-2 align-middle text-center fs-0 white-space-nowrap">
                                        <asp:Label ID="account_status" runat="server" Text='<%# Eval("account_status") %>'></asp:Label>
                                    </td>
                                    <td class="amount py-2 align-middle text-end fs-0 fw-medium">
                                        <a href='user-profile.aspx?u=<%# Eval("username_md5") %>' target="_blank">View</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>
                </table>
            </div>
        </div>
        <div class="card-footer">
            <div class="d-flex align-items-center justify-content-center">

                <div class="row">
                    <div class="col-lg-12">
                        <div class="table-responsive">
                            <table class="table">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkFirst" runat="server" OnClick="lnkFirst_Click">First</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkPrevious" runat="server" OnClick="lnkPrevious_Click">Previous</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:DataList ID="RepeaterPaging" runat="server"
                                            OnItemCommand="RepeaterPaging_ItemCommand"
                                            OnItemDataBound="RepeaterPaging_ItemDataBound" RepeatDirection="Horizontal">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Pagingbtn" runat="server"
                                                    CommandArgument='<%# Eval("PageIndex") %>' CommandName="newpage"
                                                    Text='<%# Eval("PageText") %>' Width="20px"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click">Next</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkLast" runat="server" OnClick="lnkLast_Click">Last</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" class="text-center">
                                        <asp:Label ID="lblpage" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

