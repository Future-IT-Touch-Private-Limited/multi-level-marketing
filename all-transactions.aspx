<%@ Page Title="All Transactions" Language="C#" MasterPageFile="~/main-admin.master" AutoEventWireup="true" CodeFile="all-transactions.aspx.cs" Inherits="admin_all_transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="card mt-4">
        <div class="card-body overflow-hidden">
            <div class="row">
                <div class="col-lg-12 text-center text-lg-start">
                    <h5 class="text-primary text-center pb-2">My Transactions (<asp:Label ID="pending_transactions_lbl" runat="server" Text="0"></asp:Label>)</h5>
                    <div class="table-responsive">
                        <table class="table text-dark table-bordered table-hover">
                            <tr>
                                <th>Amount</th>
                                <th>Date</th>
                                <th>Mode</th>
                                <th>Package Name</th>
                                <th>Status</th>
                                <th>View</th>
                            </tr>
                            <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>₹ <%# Eval("transaction_amt") %></td>
                                        <td><%# Eval("transaction_date") %></td>
                                        <td><%# Eval("transaction_mode") %></td>
                                        <td><%# Eval("package_name") %> (<%# Eval("package_id") %>)</td>
                                        <td><asp:Label ID="transaction_status_lbl" runat="server" Text='<%# Eval("transaction_status") %>'></asp:Label></td>
                                        <td><a href='review-pending-transactions.aspx?sr=<%# Eval("sr") %>'>View</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
            </div>


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
</asp:Content>

