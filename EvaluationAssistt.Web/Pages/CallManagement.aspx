<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CallManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.CallManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/audio-player.js"></script>
    <script type="text/javascript">
        AudioPlayer.setup("http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/player.swf", {
        });
    </script>
    <script type="text/javascript" language="javascript">
        function PlayFile(callId) {
            $.ajax({
                type: 'POST',
                url: "/Pages/CallManagement.aspx/PlayFile",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"callId":"' + callId + '"}',
                success: function (e) {
                    $.msgbox("<b>Ses kaydi :</b> <br /><br /><br />" + e.d, {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    });
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Çagri Yonetimi</h3>
    </div>
    <div class="g_12 separator">
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Çagri Filtreleme</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div style="float: left;">
                    <table cellpadding="3" cellspacing="3">
                        <tr>
                            <td colspan="3"><span class="label"><b>Asistan</b></span>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><span class="label">Lokasyon</span></td>
                            <td><span class="label">:</span></td>
                            <td>
<%--                                <dx:ASPxComboBox ID="cmbLocations" ClientInstanceName="cmbLocations" runat="server" ValueType="System.Int32" >
                                    <ClientSideEvents SelectedIndexChanged="function(s,e){ cmbGroups.PerformCallback(cmbLocations.GetSelectedItem().value.toString()); }"
                                        BeginCallback="function(s,e){ cmbGroups.ClearItems(); cmbTeams.ClearItems(); cmbAgents.ClearItems(); }"
                                        EndCallback="function(s,e){cmbAgents.PerformCallback(cmbLocations.GetSelectedItem().value.toString()); }" />
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cmbLocations" ClientInstanceName="cmbLocations" runat="server" ValueType="System.Int32" SelectedIndex="0" >
                                    <Items>
                                        <dx:ListEditItem Text="Bahçelievler" Value="1" Selected="True" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td><span class="label">Gün</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbDaysCount" ClientInstanceName="cmbDaysCount" IncrementalFilteringMode="Contains" runat="server" ValueType="System.Int32" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="1" Value="1" />
                                        <dx:ListEditItem Selected="False" Text="2" Value="2" />
                                        <dx:ListEditItem Selected="False" Text="3" Value="3" />
                                        <dx:ListEditItem Selected="False" Text="4" Value="4" />
                                        <dx:ListEditItem Selected="False" Text="5" Value="5" />
                                        <dx:ListEditItem Selected="False" Text="6" Value="6" />
                                        <dx:ListEditItem Selected="False" Text="7" Value="7" />
                                        <dx:ListEditItem Selected="False" Text="8" Value="8" />
                                        <dx:ListEditItem Selected="False" Text="9" Value="9" />
                                        <dx:ListEditItem Selected="False" Text="10" Value="10" />
                                        <dx:ListEditItem Selected="False" Text="11" Value="11" />
                                        <dx:ListEditItem Selected="False" Text="12" Value="12" />
                                        <dx:ListEditItem Selected="False" Text="13" Value="13" />
                                        <dx:ListEditItem Selected="False" Text="14" Value="14" />
                                        <dx:ListEditItem Selected="False" Text="15" Value="15" />
                                        <dx:ListEditItem Selected="False" Text="16" Value="16" />
                                        <dx:ListEditItem Selected="False" Text="17" Value="17" />
                                        <dx:ListEditItem Selected="False" Text="18" Value="18" />
                                        <dx:ListEditItem Selected="False" Text="19" Value="19" />
                                        <dx:ListEditItem Selected="False" Text="20" Value="20" />
                                        <dx:ListEditItem Selected="False" Text="21" Value="21" />
                                        <dx:ListEditItem Selected="False" Text="22" Value="22" />
                                        <dx:ListEditItem Selected="False" Text="23" Value="23" />
                                        <dx:ListEditItem Selected="False" Text="24" Value="24" />
                                        <dx:ListEditItem Selected="False" Text="25" Value="25" />
                                        <dx:ListEditItem Selected="False" Text="26" Value="26" />
                                        <dx:ListEditItem Selected="False" Text="27" Value="27" />
                                        <dx:ListEditItem Selected="False" Text="28" Value="28" />
                                        <dx:ListEditItem Selected="False" Text="29" Value="29" />
                                        <dx:ListEditItem Selected="False" Text="30" Value="30" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td><span class="label">Grup</span></td>
                            <td><span class="label">:</span></td>
                            <td>
<%--                                <dx:ASPxComboBox ID="ASPxComboBox1" ClientInstanceName="cmbGroups" runat="server" ValueType="System.Int32" OnCallback="cmbGroups_Callback" OnSelectedIndexChanged="cmbGroups_SelectedIndexChanged" >
                                    <ClientSideEvents SelectedIndexChanged="function(s,e){ cmbTeams.PerformCallback(cmbGroups.GetSelectedItem().value.toString()); }"
                                        BeginCallback="function(s,e){ cmbTeams.ClearItems(); cmbAgents.ClearItems(); }"
                                        EndCallback="function(s,e){ cmbAgents.PerformCallback(cmbGroups.GetSelectedItem().value.toString()); }" />
                                    <Items>
                                        <dx:ListEditItem Selected="true" Text="Tüm Grup - Aslıhan Kalafatoğlu" Value="5" />
                                    </Items>
                                </dx:ASPxComboBox>--%>

                                <dx:ASPxComboBox ID="cmbGroups" ClientInstanceName="cmbGroups" runat="server" ValueType="System.Int32" OnCallback="cmbGroups_Callback" OnSelectedIndexChanged="cmbGroups_SelectedIndexChanged" >
                                    <Items>
                                        <dx:ListEditItem Selected="true" Text="Tüm Grup - Aslıhan Kalafatoğlu" Value="5" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                            <td>&nbsp;</td>
                            <td><span class="label">Adet</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbRandomCount" ClientInstanceName="cmbRandomCount" IncrementalFilteringMode="Contains" runat="server" ValueType="System.Int32" SelectedIndex="0">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="1" Value="1" />
                                        <dx:ListEditItem Selected="False" Text="2" Value="2" />
                                        <dx:ListEditItem Selected="False" Text="3" Value="3" />
                                        <dx:ListEditItem Selected="False" Text="4" Value="4" />
                                        <dx:ListEditItem Selected="False" Text="5" Value="5" />
                                        <dx:ListEditItem Selected="False" Text="6" Value="6" />
                                        <dx:ListEditItem Selected="False" Text="7" Value="7" />
                                        <dx:ListEditItem Selected="False" Text="8" Value="8" />
                                        <dx:ListEditItem Selected="False" Text="9" Value="9" />
                                        <dx:ListEditItem Selected="False" Text="10" Value="10" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td><span class="label">Takim</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbTeams" ClientInstanceName="cmbTeams" runat="server" ValueType="System.Int32" OnCallback="cmbTeams_Callback">
                                    <ClientSideEvents SelectedIndexChanged="function(s,e){ cmbAgents.ClearItems(); cmbAgents.PerformCallback(cmbTeams.GetSelectedItem().value.toString()); }" />
                                </dx:ASPxComboBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td><span class="label">Asistan</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxComboBox ID="cmbAgents" ClientInstanceName="cmbAgents" IncrementalFilteringMode="Contains" runat="server" ValueType="System.Int32"></dx:ASPxComboBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td rowspan="3" style="vertical-align:top;">
                                <table >
                                    <tr>
                                        <td>
                                <asp:Button ID="btnRandomRetrive" Text="Random" runat="server" OnClick="btnRandomRetrive_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                <asp:Button ID="btnExporter" Text="Export" runat="server" OnClick="btnExporter_Click" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                <asp:Button ID="btnClear" Text="Temizle" runat="server" OnClick="btnClear_Click" Visible="false" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnExecute" Text="Sorgula" runat="server" OnClick="btnExecute_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <dx:ASPxGridViewExporter ID="aspxGrdExporter" runat="server" GridViewID="gridviewCalls">
                                </dx:ASPxGridViewExporter>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <div style="float: right; padding-right:20px;">
                    <table cellpadding="3" cellspacing="3">
                        <tr>
                            <td colspan="6">
                                <span class="label"><b>Konusma Suresi Araligi              <span class="label"><b>Konusma Suresi Araligi</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td><span class="label">Min</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxSpinEdit ID="numMinDuration" runat="server" Number="20" AllowNull="false">
                                </dx:ASPxSpinEdit>
                            </td>
                            <td><span class="label">Max</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxSpinEdit ID="numMaxDuration" runat="server" Number="120" AllowNull="false">
                                </dx:ASPxSpinEdit>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <span class="label"><b>Tarih Araligi</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td><span class="label">Min</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxDateEdit ID="dateMin" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today" OnDateChanged="dateMin_DateChanged" AutoPostBack="True"
                                    ToolTip="AM Ante Meridiem (Öğlenden önce) PM Post meridiem (Öğlenden sonra)">
                                    <TimeSectionProperties>
                                        <TimeEditProperties EditFormatString="HH:mm:ss" />
                                    </TimeSectionProperties>
                                </dx:ASPxDateEdit>
                            </td>
                            <td><span class="label">Max</span></td>
                            <td><span class="label">:</span></td>
                            <td>
                                <dx:ASPxDateEdit ID="dateMax" runat="server" AllowNull="false" EditFormat="DateTime" DateOnError="Today" OnDateChanged="dateMax_DateChanged" AutoPostBack="True"
                                    ToolTip="AM Ante Meridiem (Öğlenden önce) PM Post meridiem (Öğlenden sonra)">
                                    <TimeSectionProperties>
                                        <TimeEditProperties EditFormatString="HH:mm:ss" />
                                    </TimeSectionProperties>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="label">TelefonNo</td>
                            <td class="label">:</td>
                            <td>
                                <asp:TextBox ID="txtCallingDeviceId" runat="server" /></td>
                            <td class="label">Remark</td>
                            <td class="label">:</td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="label">SicilNo </td>
                            <td class="label">:</td>
                            <td>
                                <asp:TextBox ID="txtScilNo" runat="server" /></td>
                            <td class="label">LoginId </td>
                            <td class="label">:</td>
                            <td>
                                <asp:TextBox ID="txtLoginId" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="label">Ucid</td>
                            <td class="label">:</td>
                            <td>
                                <asp:TextBox ID="txtUCID" runat="server" /></td>
                        </tr>
                    </table>
                </div>
                <div style="clear: both; padding-left: 68px;">
                </div>
            </div>
        </div>
    </div>
<%--    <div class="g_12 separator">
    </div>--%>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Çağrı Listesi</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <dx:ASPxGridView ID="gridviewCalls" runat="server" KeyFieldName="Id"
                    OnAutoFilterCellEditorCreate="gridviewCalls_AutoFilterCellEditorCreate"
                    OnBeforeColumnSortingGrouping="gridviewCalls_BeforeColumnSortingGrouping"
                    OnPageIndexChanged="gridviewCalls_PageIndexChanged">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Anket Duzenle" Width="90px">
                            <DataItemTemplate>
                                <a href='<%#Eval("Id", "Questionnaires.aspx?CallId={0}") %>'>Anket Duzenle</a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Lokasyon" FieldName="LocationName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Musteri Temsilcisi" FieldName="AgentName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Kayit Tarihi" FieldName="DateStarted" Width="150px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="UCID" FieldName="GloballyUniqueCallLinkageID" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cihaz No" FieldName="DeviceId" Width="100px" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Cevap Veren No" FieldName="AnsweringDeviceId" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Arayan No" FieldName="CallingDeviceId" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Aranan No" FieldName="CalledDeviceId" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Sure" FieldName="DurationFormat" Width="60px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="İndir" Width="50px" Visible="false">
                            <DataItemTemplate>
                                <a href='<%# FileHelper.GetFilePath(Eval("FileName").ToString()) %>' target="_blank">
                                    <img src="/Contents/Images/download.jpg" alt="play" width="24" height="24" /></a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>

                        <dx:GridViewDataTextColumn Caption="Dinle" CellStyle-VerticalAlign="Middle" Width="50px">
                            <DataItemTemplate>
                                <a runat="server" visible='<%# !IsListenable %>' href="javascript:void(0)" onclick='<%#Eval("Id", "javascript:PlayFile({0});") %>'>
                                    <img src="/Contents/Images/play.jpeg" alt="play" width="24" height="24" />
                                </a>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Kategori" FieldName="IsIncoming" Width="100px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="VDN Adi" FieldName="VdnName">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="VDN No" FieldName="VdnExtension" Width="60px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Acd Grup" FieldName="AcdGroup" Width="100px">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowHorizontalScrollBar="true" />
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
