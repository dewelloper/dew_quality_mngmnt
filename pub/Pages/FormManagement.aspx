<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.FormManagement" %>

<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js" type="text/javascript"></script>
    <script type="text/javascript">
        function CategoriesTotalChanged(sender) {
            var cb = $(sender);

            if ($(cb).attr("checked") == "checked") {
                numMinScore.SetEnabled(false);
                numMinScore.SetValue = 0;
                numMaxScore.SetEnabled(false);
                numMaxScore.SetValue(0);
            }
            else {
                numMinScore.SetEnabled(true);
                numMaxScore.SetEnabled(true);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Form Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_3" target="_blank"><span class="label">Yardım</span></a>
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
                    <li><a class="i_16_add" href="SectionManagement.aspx" title="Yeni Bölüm Ekle">
                        <span class="label">Yeni Bölüm</span> </a></li>
                    <li><a class="i_16_settings_small" href="FormSectionsManagement.aspx" title="Form - Bölüm Eşleştirme" style="width: 150px;">
                        <span class="label">Form - Bölüm Eşleştirme</span> </a></li>
                </ul>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlRegister" CssClass="pnlRegister" runat="server" Visible="false">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Form</h4>
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
                                    <dx:ASPxSpinEdit ID="numMinScore" ClientInstanceName="numMinScore" runat="server" Number="0" AllowNull="false" NumberType="Integer">
                                    </dx:ASPxSpinEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_numMinScore" ControlToValidate="numMinScore"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="compare_numMinScore" ControlToValidate="numMinScore" ControlToCompare="numMaxScore" runat="server" ToolTip="Minimum ve maksimum değerler hatalı" Operator="LessThanEqual" ValidationGroup="Register" Type="Integer"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="lbl"><span class="label">Açıklama Zorunlu</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <input type="checkbox" id="cbRequiresComment" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                                <td></td>
                                <td class="lbl"><span class="label">Max Puan</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <dx:ASPxSpinEdit ID="numMaxScore" ClientInstanceName="numMaxScore" runat="server" Number="0" AllowNull="false" NumberType="Integer">
                                    </dx:ASPxSpinEdit>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="required_numMaxScore" ControlToValidate="numMaxScore"
                                        InitialValue="" runat="server" ValidationGroup="Register"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"><span class="label">Kategorilerin Puanlarının Toplamı Yöntemiyle Hesaplama</span></td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td colspan="2">
                                    <input type="checkbox" onchange="CategoriesTotalChanged(this);" id="cbCategoriesTotal" runat="server" />
                                    <span class="label">Evet</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5"><span class="label">Form görünürlüğü aktif mi?</span></td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td colspan="2" title="Burayı tiklerseniz: bu form Admin ve Kalite yönetimi dışındaki kullanıcılarda (Takım lideri, Grup Lideri, Agent) gelmeyecektir">
                                    <input type="checkbox" id="chkFormAppearnce" runat="server"/>
                                    <span class="label">Hayır</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    <br />
                                    <br />
                                    <asp:Button ID="btnSave" Text="Kaydet" ValidationGroup="Register" runat="server" OnClick="btnSave_Click" PostBackUrl="~/Pages/FormManagement.aspx" />
                                    <input type="button" value="Temizle" onclick="javascript: ClearControls('pnlRegister');" />
                                    <asp:Button ID="btnCancel" Text="İptal" runat="server" OnClick="btnClear_Click" PostBackUrl="~/Pages/FormManagement.aspx" />
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
                <h4 class="widget_header_title wwIcon i_16_forms">Form Listesi</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewForms" runat="server" ClientInstanceName="gridviewForms" KeyFieldName="Id">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="60px">
                                    <DataItemTemplate>
                                        <asp:ImageButton ID="imgEdit"  style="width:16px; height:16px;" PostBackUrl='<%#Eval("Id", "/Pages/FormManagement.aspx?Id={0}") %>'
                                            ImageUrl="~/Contents/Images/Icons/16/i_16_edit.png" runat="server" />
                                        <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%#Eval("Name") %>', 'form', this, '/Pages/FormManagement.aspx/DeleteForm');"
                                            src="/Contents/Images/Icons/16/i_16_delete.png" />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataTextColumn Caption="Form" FieldName="Name">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Açıklama Zorunlu" Width="120px">
                                    <DataItemTemplate>
                                        <%#HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("RequiresComment"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
