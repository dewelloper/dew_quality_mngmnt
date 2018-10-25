<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionnairesEvaluatedList.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.QuestionnairesEvaluatedList" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Çağrı Yönetimi</h3>
    </div>
<%--    <div class="g_6 contents_options">
        <div class="simple_buttons">
            <div class="bwIcon i_16_help">
                Yardım
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
    </div>--%>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Çağrı Filtreleme</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div style="float: left;">
                    <table cellpadding="3" cellspacing="3">
                        <tr>
                            <td class="label"><span class="label">Min Puan</span></td>
                            <td class="label"><span class="label">:</span></td>
                            <td>
                                <dx:ASPxSpinEdit ID="numMinDuration" runat="server" Number="0" AllowNull="true" ToolTip="Dikkat!! değerlendirilmiş çağrılar filitrelenirken bu alanlara bakacaktır, sıfırdan büyük değerlerde bazı itirazları göremeyebilirsiniz.">
                                </dx:ASPxSpinEdit>
                            </td>
                            <td class="label"><span class="label">Max Puan</span></td>
                            <td class="label"><span class="label">:</span></td>
                            <td>
                                <dx:ASPxSpinEdit ID="numMaxDuration" runat="server" Number="10000" AllowNull="true">
                                </dx:ASPxSpinEdit>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btnExecute" Text="Sorgula" runat="server" OnClick="btnExecute_Click" />
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
            <h4 class="widget_header_title wwIcon i_16_forms">Değerlendirilmiş Çağrı Listesi</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <dx:ASPxGridView ID="gridviewCalls" runat="server" 
                    OnBeforeColumnSortingGrouping="gridviewCalls_BeforeColumnSortingGrouping"
                    OnPageIndexChanged="gridviewCalls_PageIndexChanged"
                    OnAutoFilterCellEditorCreate="gridviewCalls_AutoFilterCellEditorCreate">
                    <Columns>
                        <dx:GridViewDataColumn Caption="" FixedStyle="Left" Width="60px">
                            <DataItemTemplate>
                                <img class="imgButton" alt="" onclick="javascript:EntryDelete('<%#Eval("Id") %>', '<%#Eval("FormName") %>', 'değerlendirme', this, '/Pages/QuestionnairesEvaluatedList.aspx/DeleteEvaluation');"
                                    src="/Contents/Images/Icons/16/i_16_delete.png" />
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataTextColumn Caption="ID" FieldName="Id">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Çağrı Tarihi" FieldName="CallDate" Width="75px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Form" FieldName="FormName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Müşteri Temsilcisi" FieldName="AgentName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Değerlendiren" FieldName="EvaluatorName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Değerlendirilme Tarihi" FieldName="EvaluationDate" >
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Puan" FieldName="Score">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Anket Görüntüle">
                            <DataItemTemplate>
                                <a href='<%# String.Format("/Pages/QuestionnairesEvaluated.aspx?CallId={0}&FormId={1}&Fceid={2}", Eval("CallId"), Eval("FormId"),Eval("Id"))%>'>Anketi Görüntüle</a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
