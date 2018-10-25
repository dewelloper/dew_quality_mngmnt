<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SectionCategoriesManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.SectionCategoriesManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>







<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function AddSelectedItems() {
            MoveSelectedItems(lstboxCategories, lstboxSectionCategories);
            UpdateButtonState();
        }

        function RemoveSelectedItems() {
            MoveSelectedItems(lstboxSectionCategories, lstboxCategories);
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

            var disableAdd = lstboxCategories.GetSelectedItems().length > 0;
            var disableRemove = lstboxSectionCategories.GetSelectedItems().length > 0;

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
        <h3 class="i_16_forms tab_label">Bölüm - Kategori Yönetimi</h3>
    </div>
    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                <a href="Help.aspx#3_8" target="_blank"><span class="label">Yardım</span></a>
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
                    <li><a class="i_16_add" href="SectionManagement.aspx"  title="Yeni Bölüm Ekle">
                        <span class="label">Yeni Bölüm</span> </a></li>
                    <li><a class="i_16_add" href="CategoryManagement.aspx"  title="Yeni Kategori Ekle">
                        <span class="label">Yeni Kategori</span> </a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Bölüm - Kategori Eşleştirme</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3" style="width: 100%">
                    <table class="simple_table" cellpadding="5" cellspacing="5" style="width: 100%; table-layout: fixed">
                        <tr>
                            <td>
                                <span class="label">Bölüm :</span>
                                <dx:ASPxComboBox ID="cmbSections" runat="server" ClientInstanceName="cmbSections" ValueType="System.Int32" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="cmbSections_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                                <br />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="required_cmbSections" ValidationGroup="Register" runat="server" InitialValue="" ControlToValidate="cmbSections"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="label">Tüm Kategoriler :</span>
                                <dx:ASPxListBox ID="lstboxCategories" ClientInstanceName="lstboxCategories" runat="server" ValueType="System.Int32" Width="100%" Height="200px" SelectionMode="CheckColumn">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }" Init="function(s,e) { UpdateButtonState(); }" />
                                </dx:ASPxListBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <input type="button" id="btnAdd" value="Ekle" onclick="AddSelectedItems();" disabled="disabled" />
                                &nbsp;
                                <input type="button" id="btnRemove" value="Çıkart" onclick="RemoveSelectedItems();" disabled="disabled" />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span class="label">Bölüme Atanmış Kategoriler :</span>
                                <dx:ASPxListBox ID="lstboxSectionCategories" ClientInstanceName="lstboxSectionCategories" runat="server" ValueType="System.Int32" Width="100%" Height="200px" SelectionMode="CheckColumn">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { UpdateButtonState(); }" />
                                </dx:ASPxListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                                <asp:Button ID="btnSave" Text="Kaydet" runat="server" OnClick="btnSave_Click" ValidationGroup="Register" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
