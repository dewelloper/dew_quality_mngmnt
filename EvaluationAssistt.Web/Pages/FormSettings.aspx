<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FormSettings.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.FormSettings" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Form Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_10" target="_blank"><span class="label">Yardım</span></a>
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
                </ul>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Form Seçimi</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <table class="simple_table" cellpadding="5" cellspacing="5">
                        <tr>
                            <td>
                                <span class="label">Form</span></td>
                            <td>
                                <span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbForms" ClientInstanceName="cmbForms" runat="server" ValueType="System.Int32" AutoPostBack="true" OnSelectedIndexChanged="cmbForms_SelectedIndexChanged"></dx:ASPxComboBox>
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
            <h4 class="widget_header_title wwIcon i_16_forms">Bölüm Ayarları</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <asp:Panel ID="pnlSection" runat="server">
                        <table class="simple_table" cellpadding="5" cellspacing="5">
                            <tr>
                                <td>
                                    <span class="label">Bölüm</span></td>
                                <td>
                                    <span class="label">:</span></td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbSections" ClientInstanceName="cmbSections" runat="server" ValueType="System.Int32" AutoPostBack="true" OnSelectedIndexChanged="cmbSections_SelectedIndexChanged"></dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Min Puan</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <asp:Label CssClass="label" ID="lblMinScoreSection" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Max Puan</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <asp:Label CssClass="label" ID="lblMaxScoreSection" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Kapalı</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <input type="checkbox" id="cbIsDisabledSection" runat="server" disabled="disabled" />
                                    <span class="label">Evet</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Puanlama</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbScoreTypesSection" runat="server" ValueType="System.Int32"></dx:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Kategori Ayarları</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <asp:Panel ID="pnlCategory" runat="server">
                        <table class="simple_table" cellpadding="5" cellspacing="5">
                            <tr>
                                <td>
                                    <span class="label">Kategori</span></td>
                                <td>
                                    <span class="label">:</span></td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbCategories" ClientInstanceName="cmbCategories" runat="server" ValueType="System.Int32" AutoPostBack="true" OnSelectedIndexChanged="cmbCategories_SelectedIndexChanged"></dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Min Puan</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <asp:Label CssClass="label" ID="lblMinScoreCategory" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Max Puan</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <asp:Label CssClass="label" ID="lblMaxScoreCategory" Text="" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Kapalı</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <input type="checkbox" id="cbIsDisabledCategory" runat="server" disabled="disabled" />
                                    <span class="label">Evet</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Puanlama</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbScoreTypesCategory" runat="server" ValueType="System.Int32"></dx:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Soru - Cevap Ayarları</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <asp:Panel ID="pnlQuestion" runat="server">
                        <table class="simple_table" cellpadding="5" cellspacing="5" style="width: 100%">
                            <tr>
                                <td>
                                    <span class="label">Soru :</span>
                                    <dx:ASPxComboBox ID="cmbQuestions" ClientInstanceName="cmbQuestions" runat="server" ValueType="System.Int32" AutoPostBack="true" OnSelectedIndexChanged="cmbQuestions_SelectedIndexChanged" Width="100%"></dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Cevaplar :</span>
                                    <dx:ASPxListBox ID="lstboxAnswers" ClientInstanceName="lstboxAnswers" runat="server" Width="100%" Border-BorderStyle="Dashed" AutoPostBack="true" ValueType="System.Int32" OnSelectedIndexChanged="lstboxAnswers_SelectedIndexChanged">
                                        <%--<ClientSideEvents SelectedIndexChanged="function(s,e){}" />--%>
                                        <ItemStyle Cursor="pointer" />
                                        <Border BorderStyle="None" />
                                    </dx:ASPxListBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Bölüm Ayarları :</span>
                                    <dx:ASPxGridView ID="gridviewSectionSettings" KeyFieldName="SectionId" SkinID="SimpleGridView" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Bölüm" FieldName="SectionName">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Aç / Kapat" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesDisable" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Puan Sıfırla" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesZeroize" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Visible="False">
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Kategori Ayarları :</span>
                                    <dx:ASPxGridView ID="gridviewCategorySettings" KeyFieldName="CategoryId" SkinID="SimpleGridView" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Bölüm" FieldName="CategoryName">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Aç / Kapat" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesDisable" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Puan Sıfırla" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesZeroize" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Visible="False">
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Soru Ayarları :</span>
                                    <dx:ASPxGridView ID="gridviewQuestionSettings" KeyFieldName="QuestionId" SkinID="SimpleGridView" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Soru" FieldName="QuestionText">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Aç / Kapat" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesDisable" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Puan Sıfırla" Width="100px">
                                                <DataItemTemplate>
                                                    <asp:CheckBox ID="cbDoesZeroize" runat="server" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Visible="False" Mode="ShowAllRecords">
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" Text="Kaydet" runat="server" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Tüm Ayarların Listesi</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <dx:ASPxGridView ID="gridviewFormSettings" SkinID="SimpleGridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Soru" FieldName="QuestionText">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Cevap" FieldName="AnswerText" Width="75px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Hedef" FieldName="Target" Width="75px">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Hedef Adı" FieldName="TargetName">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Aç / Kapat" Width="75px">
                                <DataItemTemplate>
                                    <asp:CheckBox ID="cbDoesDisable" Checked='<%#Eval("DoesDisable") %>' Enabled="false" runat="server" />
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Puan Sıfırla" Width="75px">
                                <DataItemTemplate>
                                    <asp:CheckBox ID="cbDoesZeroize" Checked='<%#Eval("DoesZeroize") %>' Enabled="false" runat="server" />
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPager Visible="False">
                        </SettingsPager>
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
