<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SectionManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.SectionManagement" %>

<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Bölüm Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_4" target="_blank"><span class="label">Yardım</span></a>
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
                    <li><a class="i_16_add" href="FormManagement.aspx" title="Yeni Form Ekle">
                        <span class="label">Yeni Form</span> </a></li>
                    <li><a class="i_16_add" href="CategoryManagement.aspx" title="Yeni Kategori Ekle">
                        <span class="label">Yeni Kategori</span> </a></li>
                    <li><a class="i_16_settings_small" href="SectionCategoriesManagement.aspx" title="Bölüm - Kategori Eşleştirme" style="width: 150px;">
                        <span class="label">Bölüm - Kategori Eşleştirme</span> </a></li>
                </ul>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlRegister" CssClass="pnlRegister" runat="server" Visible="false">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Bölüm</h4>
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
                                    <asp:RequiredFieldValidator ID="required_txtName" ControlToValidate="txtName"
                                        runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                                <td class="lbl"><span class="label">Min Puan</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <dx:ASPxSpinEdit ID="numMinScore" runat="server" Number="0" AllowNull="false" NumberType="Integer">
                                    </dx:ASPxSpinEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_numMinScore" ControlToValidate="numMinScore"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="numMinScore" ControlToCompare="numMaxScore" runat="server" ToolTip="Minimum ve maksimum değerler hatalı" Operator="LessThanEqual" ValidationGroup="Register" Type="Integer"></asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td class="lbl">
                                    <span class="label">Puanlama</span>
                                </td>
                                <td class="lbl">
                                    <span class="label">:</span></td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbScoreType" runat="server" ValueType="System.Int32" IncrementalFilteringMode="Contains">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_cmbScoreType" ControlToValidate="cmbScoreType"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                                <td class="lbl"><span class="label">Max Puan</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <dx:ASPxSpinEdit ID="numMaxScore" runat="server" Number="0" AllowNull="false" NumberType="Integer">
                                    </dx:ASPxSpinEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_numMaxScore" ControlToValidate="numMaxScore"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Kapalı</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <input type="checkbox" id="cbIsDisabled" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSave" Text="Kaydet" ValidationGroup="Register" runat="server" OnClick="btnSave_Click" PostBackUrl="/Pages/SectionManagement.aspx" />
                                    <input type="button" value="Temizle" onclick="javascript: ClearControls('pnlRegister');" />
                                    <asp:Button ID="btnCancel" Text="İptal" runat="server" OnClick="btnClear_Click" PostBackUrl="~/Pages/SectionManagement.aspx" />
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
                <h4 class="widget_header_title wwIcon i_16_forms">Bölüm Listesi</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewSections" runat="server" ClientInstanceName="gridviewSections" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="60px">
                                    <DataItemTemplate>
                                        <asp:ImageButton ID="imgEdit"  style="width:16px; height:16px;" PostBackUrl='<%#Eval("Id", "/Pages/SectionManagement.aspx?Id={0}") %>'
                                            ImageUrl="~/Contents/Images/Icons/16/i_16_edit.png" runat="server" />
                                        <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%#Eval("Name") %>', 'bölüm', this, '/Pages/SectionManagement.aspx/DeleteSection');"
                                            src="/Contents/Images/Icons/16/i_16_delete.png" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Bölüm" FieldName="Name">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Başlangıçta Kapalı" FieldName="IsDisabled" Width="120px">
                                    <DataItemTemplate>
                                        <%#HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("IsDisabled"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Min Puan" FieldName="MinimumScore" Width="80px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Max Puan" FieldName="MaximumScore" Width="80px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Puanlama Tipi" FieldName="ScoreTypeName" Width="100px">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
