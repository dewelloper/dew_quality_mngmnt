<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TeamManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.TeamManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js"></script>
    <script src="../Scripts/jQuery/jquery-1.7.2.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Takım Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_13" target="_blank"><span class="label">Yardım</span></a>
            </div>
        </div>
        <div class="simple_buttons">
            <div class="bwIcon i_16_settings">
                Araçlar
            </div>
            <div class="buttons_arrow">
                <!-- Drop Menu -->
                <ul class="drop_menu menu_with_icons right_direction">
                    <li><a class="i_16_up" href="javascript:void(0)" onclick="HideAll();" title="Tüm Sekmeleri Kapat">
                        <span class="label">Tümünü Gizle</span> </a></li>
                    <li><a class="i_16_down" href="javascript:void(0)" onclick="ShowAll();" title="Tüm Sekmeleri Aç">
                        <span class="label">Tümünü Göster</span> </a></li>
                    <li><a class="i_16_pages" href="javascript:void(0)" onclick="BookmarkPage();" title="Sayfayı Sık Kullanılanlara Ekle">
                        <span class="label">Favorilere Ekle</span> </a></li>
                    <li><a class="i_16_add" href="GroupManagement.aspx" title="Yeni Grup Ekle">
                        <span class="label">Yeni Grup</span> </a></li>
                    <li><a class="i_16_add" href="AgentManagement.aspx" title="Yeni Kullanıcı Ekle">
                        <span class="label">Yeni Kullanıcı</span> </a></li>
                </ul>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlRegister" CssClass="pnlRegister" runat="server" Visible="false">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Takım</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <table cellpadding="5" cellspacing="5">
                            <tr>
                                <td class="lbl"><span class="label">Ad</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_txtNamee" ControlToValidate="txtName"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                                <td class="lbl"><span class="label">Takım Lideri</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbAgent" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_cmbAgent" ControlToValidate="cmbAgent"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Grup</span></td>
                                <td><span class="label">:</span></td>
                                <td colspan="5">
                                    <dx:ASPxComboBox ID="cmbGroup" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains" Width="100%">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_cmbGroup" ControlToValidate="cmbGroup"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSave" Text="Kaydet" ValidationGroup="Register" runat="server" OnClick="btnSave_Click" PostBackUrl="~/Pages/TeamManagement.aspx" />
                                    <input type="button" value="Temizle" onclick="javascript: ClearControls('pnlRegister');" />
                                    <asp:Button ID="btnCancel" Text="İptal" runat="server" OnClick="btnClear_Click" PostBackUrl="~/Pages/TeamManagement.aspx" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="g_12">
        <asp:Button ID="btnNew" Text="Yeni" runat="server" OnClick="btnNew_Click" />
    </div>
    <div class="g_12 separator">
        
    </div>
    <asp:Panel ID="pnlList" runat="server">
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Takım Listesi</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewTeams" runat="server" ClientInstanceName="gridviewTeams" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="60px">
                                    <DataItemTemplate>
                                        <asp:ImageButton ID="imgEdit"   style="width:16px; height:16px;" class="imgButton"  PostBackUrl='<%#Eval("Id", "/Pages/TeamManagement.aspx?Id={0}") %>'
                                            ImageUrl="~/Contents/Images/Icons/16/i_16_edit.png" runat="server" />
                                        <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%#Eval("Name") %>', 'takım', this, '/Pages/TeamManagement.aspx/DeleteTeam');"
                                            src="/Contents/Images/Icons/16/i_16_delete.png" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Takım" FieldName="Name">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Grup" FieldName="GroupName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Takım Lideri" FieldName="AgentName">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
