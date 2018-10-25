<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProfileManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.ProfileManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function AddSelectedItems() {
            MoveSelectedItems(lstboxPages, lstboxBookmarks);
            UpdateButtonState();
        }

        function RemoveSelectedItems() {
            MoveSelectedItems(lstboxBookmarks, lstboxPages);
            UpdateButtonState();
        }

        function MoveSelectedItems(srcListBox, dstListBox) {
            srcListBox.BeginUpdate();
            dstListBox.BeginUpdate();
            var items = srcListBox.GetSelectedItems();
            for (var i = items.length - 1; i >= 0; i = i - 1) {
                dstListBox.AddItem(items[i].text, items[i].value, "");
                srcListBox.RemoveItem(items[i].index);
            }
            srcListBox.EndUpdate();
            dstListBox.EndUpdate();
        }

        function UpdateButtonState() {

            var disableAdd = lstboxPages.GetSelectedItems().length > 0;
            var disableRemove = lstboxBookmarks.GetSelectedItems().length > 0;

            if (!disableAdd) {
                $("#btnAdd").attr("disabled", "disabled");
            }
            else {
                $("#btnAdd").removeAttr("disabled");
            }

            if (!disableRemove) {
                $("#btnRemove").attr("disabled", "disabled");
            }
            else {
                $("#btnRemove").removeAttr("disabled");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Profil Yönetimi</h3>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Kişisel Bilgilerim</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3">
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td class="lbl"><span class="label">Ad</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server" />
                            </td>
                            <td class="lbl"><span class="label">Soyad</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" /></td>
                        </tr>
                        <tr>
                            <td class="lbl"><span class="label">Login ID</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <asp:TextBox ID="txtLoginId" runat="server" />
                            </td>
                            <td class="lbl"><span class="label">Sicil No</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <asp:TextBox ID="txtRegisterNumber" runat="server" ReadOnly="true" /></td>
                        </tr>
                        <tr>
                            <td class="lbl"><span class="label">Takım</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbTeam" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains" ReadOnly="true" Width="100%">
                                </dx:ASPxComboBox>
                            </td>
                            <td class="lbl">
                                <span class="label">Takım Lideri</span>
                            </td>
                            <td>
                                <span class="label">:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTeamLeaderName" runat="server" ReadOnly="true" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Sık Kullanılan Sayfalarım</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <div style="float: left; width: 40%">
                        <span class="label">Sayalar :</span>
                        <dx:ASPxListBox ID="lstboxPages" ClientInstanceName="lstboxPages" runat="server" ValueType="System.Int32" SelectionMode="CheckColumn" Width="100%" Height="200px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }" Init="function(s,e) { UpdateButtonState(); }" />
                        </dx:ASPxListBox>
                    </div>
                    <div style="float: left; width: 15%;">
                        <div style="margin-left: 30px; margin-top: 60px;">
                            <input type="button" id="btnAdd" value=">>" onclick="AddSelectedItems();" />
                            <br />
                            <br />
                            <input type="button" id="btnRemove" value="<<" onclick="RemoveSelectedItems();" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnSave" Text="Kaydet" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <div style="float: right; width: 40%;">
                        <span class="label">Sık Kullanılanlar :</span>
                        <dx:ASPxListBox ID="lstboxBookmarks" ClientInstanceName="lstboxBookmarks" runat="server" ValueType="System.Int32" SelectionMode="CheckColumn" Width="100%" Height="200px">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }" Init="function(s,e) { UpdateButtonState(); }" />
                        </dx:ASPxListBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
