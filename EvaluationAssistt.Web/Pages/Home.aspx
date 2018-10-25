<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.Home" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>
<%@ Import Namespace="EvaluationAssistt.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function GetCallSummary() {
            $.ajax({
                type: 'POST',
                url: "/Pages/Home.aspx/GetCallSummary",
                dataType: 'json',
                data: '{"dateMin":"' + dateMin.GetText() + '", "dateMax":"' + dateMax.GetText() + '"}',
                contentType: 'application/json;charset=utf-8',
                success: function (e) {
                    var count = e.d.split("-")[0];
                    var duration = e.d.split("-")[1];
                    $("#lblCallCount").text(count);
                    $("#lblAverageCallDuration").text(duration);
                }
            })
        }

        function GetTeamCallSummary() {
            $.ajax({
                type: 'POST',
                url: "/Pages/Home.aspx/GetTeamCallSummary",
                dataType: 'json',
                data: '{"dateMin":"' + dateMinTeam.GetText() + '", "dateMax":"' + dateMaxTeam.GetText() + '"}',
                contentType: 'application/json;charset=utf-8',
                success: function (e) {
                    $("#tableTeamCallSummary").html("");
                    $("#tableTeamCallSummary").html(e.d);
                }
            })
        }

        function GetTeamLeaderCallEvaluatedSummary() {
            $.ajax({
                type: 'POST',
                url: "/Pages/Home.aspx/GetTeamLeaderCallEvaluatedSummary",
                dataType: 'json',
                data: '{"dateMin":"' + dateMinTeamLeader.GetText() + '", "dateMax":"' + dateMaxTeamLeader.GetText() + '"}',
                contentType: 'application/json;charset=utf-8',
                success: function (e) {
                    $("#tableTeamLeaderCallEvaluatedSummary").html("");
                    $("#tableTeamLeaderCallEvaluatedSummary").html(e.d);
                }
            })
        }

        function GetGroupCallSummary() {
            $.ajax({
                type: 'POST',
                url: "/Pages/Home.aspx/GetGroupCallSummary",
                dataType: 'json',
                data: '{"dateMin":"' + dateMinGroup.GetText() + '", "dateMax":"' + dateMaxGroup.GetText() + '"}',
                contentType: 'application/json;charset=utf-8',
                success: function (e) {
                    $("#tableGroupCallSummary").html("");
                    $("#tableGroupCallSummary").html(e.d);
                }
            })
        }

        function GetTeamCallSummaryFromGroup(teamId) {
            $.ajax({
                type: 'POST',
                url: "/Pages/Home.aspx/GetGroupTeamCallSummary",
                dataType: 'json',
                data: '{"teamId":"' + teamId + '", "dateMin":"' + dateMinGroup.GetText() + '", "dateMax":"' + dateMaxGroup.GetText() + '"}',
                contentType: 'application/json;charset=utf-8',
                success: function (e) {
                    $("#tableGroupTeamCallSummary").html("");
                    $("#tableGroupTeamCallSummary").html(e.d);
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:Panel ID="pnlAgent" runat="server">
        <div class="g_6 contents_header">
            <h3 class="i_16_forms tab_label">Genel Bilgiler</h3>
        </div>
        <div class="g_12 separator">
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Çağrı Bilgilerim</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <table cellpadding="5" cellspacing="5">
                            <tr>
                                <td colspan="6"><span class="label"><b>Tarih Aralığı</b></span></td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Min
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dateMin" ClientInstanceName="dateMin" AllowNull="false" runat="server" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <span class="label">Max
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dateMax" ClientInstanceName="dateMax" runat="server" AllowNull="false" EditFormat="DateTime" DateOnError="Today"></dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <input type="button" value="Sorgula" onclick="GetCallSummary();" /></td>
                            </tr>
                        </table>
                        <table cellpadding="5" cellspacing="5" style="margin-top: 20px;">
                            <tr>
                                <td>
                                    <span class="label">Alınan çağrı sayısı
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <span class="label" id="lblCallCount" clientidmode="Static" runat="server"></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Ortalama çağrı süresi
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <span class="label" id="lblAverageCallDuration" clientidmode="Static" runat="server"></span>
                                    <span class="label">saniye
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Değerlendirilen Çağrılarım (Son 30 Gün)</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewCalls" runat="server">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Çağrı Tarihi" FieldName="CallDate">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Form" FieldName="FormName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Değerlendirilme Tarihi" FieldName="EvaluationDate">
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
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlTeamLeader" runat="server">

        <div class="g_12" style="display: none;">
            <div class="widget_header" style="display: none;">
                <h3 class="i_16_forms tab_label" style="display: none;">Genel Bilgiler</h3>
            </div>
            <div class="widget_contents noPadding">
                <div class="g_6 contents_options">
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
                </div>
                <div class="g_12 separator">
                </div>
                <div class="g_12" style="visibility: hidden;">
                    <div class="widget_header">
                        <h4 class="widget_header_title wwIcon i_16_forms"><%: UserHelper.TeamName %>&nbsp;Çağrı Bilgileri</h4>
                    </div>
                    <div class="widget_contents noPadding">
                        <div class="line_grid">
                            <div class="g_3" style="width: 100%">
                                <table cellpadding="5" cellspacing="5">
                                    <tr>
                                        <td colspan="6"><span class="label"><b>Tarih Aralığı</b></span></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="label">Min
                                            </span>
                                        </td>
                                        <td>
                                            <span class="label">:
                                            </span>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dateMinTeam" ClientInstanceName="dateMinTeam" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            <span class="label">Max
                                            </span>
                                        </td>
                                        <td>
                                            <span class="label">:
                                            </span>
                                        </td>
                                        <td>
                                            <dx:ASPxDateEdit ID="dateMaxTeam" ClientInstanceName="dateMaxTeam" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today"></dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            <input type="button" value="Sorgula" onclick="GetTeamCallSummary();" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                        <td colspan="4"></td>
                                    </tr>
                                </table>
                                <div style="float: left; width: 40%;">
                                    <asp:Repeater ID="repeaterTeamCallSummaries" runat="server">
                                        <HeaderTemplate>
                                            <table id="tableTeamCallSummary" class="light_table" cellpadding="5" cellspacing="5" style="margin-top: 20px;" border="1" width="100%">
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <span id="lblTeamCallSummaryDateRange" class="label"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left"><span class="label"><b>Asistan</b></span></td>
                                                    <td align="center"><span class="label"><b>Çağrı Sayısı</b></span></td>
                                                    <td align="center"><span class="label"><b>Görüşme Süresi</b></span></td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="left"><span class="label"><%#Eval("AgentName") %></span></td>
                                                <td align="center"><span class="label"><%#Eval("TotalCall", "{0:n0}") %></span></td>
                                                <td align="right"><span class="label"><%#Eval("TotalDuration", "{0:n0}") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <div style="float: left; width: 40%; margin-left: 10px;">
                                    <asp:Repeater ID="repeaterTeamCallEvaluatedSummaries" runat="server">
                                        <HeaderTemplate>
                                            <table id="tableTeamCallSummary" class="light_table" cellpadding="5" cellspacing="5" style="margin-top: 20px;" border="1" width="100%">
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <span class="label"><%:DateTime.Now.ToMonthName() %></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"><span class="label"><b>Değerlendirilen Çağrı Sayısı</b></span></td>
                                                    <td align="center"><span class="label"><b>Ortalama</b></span></td>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center"><span class="label"><%#Eval("TotalCallsEvaluated", "{0:n0}") %></span></td>
                                                <td align="center"><span class="label"><%#Eval("TotalCallsEvaluatedPercentage", "{0:n0}") %></span></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Benim Çağrı Değerlendirme Bilgilerim</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <table cellpadding="5" cellspacing="5">
                            <tr>
                                <td colspan="6"><span class="label"><b>Tarih Aralığı</b></span></td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Min
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dateMinTeamLeader" ClientInstanceName="dateMinTeamLeader" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <span class="label">Max
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="dateMaxTeamLeader" ClientInstanceName="dateMaxTeamLeader" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today"></dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rbListEvaluater" runat="server" TextAlign="Right" CssClass="radios" RepeatDirection="Horizontal" CellSpacing="30">
                                        <asp:ListItem Value="1">Ben</asp:ListItem>
                                        <asp:ListItem Value="2">Diğerleri</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Button ID="btnMyEvaluated" runat="server" Text="Değerlendirmeler" OnClick="btnMyEvaluated_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td colspan="4"></td>
                            </tr>
                        </table>
                        <div>
                            <div class="g_12">
                                <div class="widget_header">
                                    <h4 class="widget_header_title wwIcon i_16_forms">Değerlendirilmiş Çağrı Listesi</h4>
                                </div>
                                <div class="widget_contents noPadding">
                                    <div class="line_grid">
                                    </div>
                                </div>
                            </div>
                            <br />
                            <dx:ASPxGridView ID="grdmycalls" runat="server" OnAutoFilterCellEditorCreate="grdmycalls_AutoFilterCellEditorCreate" OnBeforeColumnSortingGrouping="grdmycalls_BeforeColumnSortingGrouping" OnPageIndexChanged="grdmycalls_PageIndexChanged">
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
                                    <dx:GridViewDataTextColumn Caption="Değerlendirilme Tarihi" FieldName="EvaluationDate">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Puan" FieldName="Score">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Anket Görüntüle">
                                        <DataItemTemplate>
                                            <a href='<%# String.Format("/Pages/QuestionnairesEvaluated.aspx?CallId={0}&FormId={1}&Fceid={2}", Eval("CallId"), Eval("FormId"), Eval("ID"))%>'>Anketi Görüntüle</a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <br />
            &nbsp;&nbsp;&nbsp;
            <input type="button" value="Sorgula" onclick="GetTeamLeaderCallEvaluatedSummary();" style="visibility: hidden;" />
            <asp:Repeater ID="repeaterTeamLeaderCallEvaluatedSummaries" runat="server">
                <HeaderTemplate>
                    <table id="tableTeamLeaderCallEvaluatedSummary" border="1" cellpadding="5" cellspacing="5" class="light_table" style="margin-top: 20px;" width="100%">
                        <tr>
                            <td align="center" colspan="3"><span id="lblTeamLeaderCallEvaluatedSummaryDateRange" class="label"></span></td>
                        </tr>
                        <tr>
                            <td align="left"><span class="label"><b>Form Adı</b></span></td>
                            <td align="center"><span class="label"><b>Değerlendirme Sayısı</b></span></td>
                            <td align="center"><span class="label"><b>Ortalama</b></span></td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="left"><span class="label"><%#Eval("FormName") %></span></td>
                        <td align="center"><span class="label"><%#Eval("TotalCallEvaluated", "{0:n0}") %></span></td>
                        <td align="center"><span class="label"><%#Eval("Percentage", "{0:P}") %></span></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yorum Yapılan Değerlendirmeler</h4>
                &nbsp;&nbsp;&nbsp;
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <dx:ASPxGridView ID="gridviewCallsEvaluated" runat="server" OnAutoFilterCellEditorCreate="gridviewCallsEvaluated_AutoFilterCellEditorCreate" OnBeforeColumnSortingGrouping="gridviewCallsEvaluated_BeforeColumnSortingGrouping" OnPageIndexChanged="gridviewCallsEvaluated_PageIndexChanged">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Okundu" FieldName="AgentNoteSeen" Width="60px">
                                    <DataItemTemplate>
                                        <%#HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("AgentNoteSeen"))) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Çağrı Tarihi" FieldName="CallDate" Width="90px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Asistan" FieldName="AgentName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Form" FieldName="FormName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Değerlendiren" FieldName="EvaluatorName">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Puan" FieldName="Score" Width="60px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Anket Görüntüle">
                                    <DataItemTemplate>
                                        <a href='<%# String.Format("/Pages/QuestionnairesEvaluated.aspx?CallId={0}&FormId={1}&CallState={2}&Fceid={3}", Eval("CallId"), Eval("FormId"), Eval("CallState"), Eval("Id"))%>'>Anketi Görüntüle</a>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Onaylandı" FieldName="CallState" Width="60px">
                                    <DataItemTemplate>
                                        <%#HtmlHelper.TrueFalseIcon(Eval("CallState").ToString() == "51" ? true : false) %>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <br />
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <asp:Panel ID="pnlGroupLeader" runat="server">
        <div class="g_6 contents_header">
            <h3 class="i_16_forms tab_label">Genel Bilgiler</h3>
        </div>

        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">&nbsp;</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3" style="width: 100%">
                        <table cellpadding="5" cellspacing="5" style="display: none;">
                            <tr>
                                <td colspan="6"><span class="label"><b>Tarih Aralığı</b></span></td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="label">Min
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <%--<dx:ASPxDateEdit ID="dateMinGroup" ClientInstanceName="dateMinGroup" runat="server">--%>
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <span class="label">Max
                                    </span>
                                </td>
                                <td>
                                    <span class="label">:
                                    </span>
                                </td>
                                <td>
                                    <%--<dx:ASPxDateEdit ID="dateMaxGroup" ClientInstanceName="dateMaxGroup" runat="server"></dx:ASPxDateEdit>--%>
                                </td>
                                <td>
                                    <%--<input type="button" value="Sorgula" onclick="GetGroupCallSummary();" /></td>--%>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                                <td colspan="4"></td>
                            </tr>
                        </table>
                        <div style="float: left; width: 40%;">
                            <asp:Repeater ID="repeaterGroupCallSummaries" runat="server">
                                <HeaderTemplate>
                                    <table id="tableGroupCallSummary" class="light_table" cellpadding="5" cellspacing="5" style="margin-top: 20px;" border="1" width="100%">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <span id="lblGroupCallSummaryDateRange" class="label"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left"><span class="label"><b>Takım</b></span></td>
                                            <td align="center"><span class="label"><b>Çağrı Sayısı</b></span></td>
                                            <td align="center"><span class="label"><b>Görüşme Süresi</b></span></td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="left"><span class="label"><a href="javascript:void(0)"
                                            onclick='<%#Eval("Id", "javascript:GetTeamCallSummaryFromGroup({0});")%>'><%#Eval("TeamName") %></a></span></td>
                                        <td align="center"><span class="label"><%#Eval("TotalCall", "{0:n0}") %></span></td>
                                        <td align="right"><span class="label"><%#Eval("TotalDuration", "{0:n0}") %></span></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div style="float: left; width: 40%; margin-left: 10px;">
                            <table id="tableGroupTeamCallSummary" class="light_table" cellpadding="5" cellspacing="5" style="margin-top: 20px;" border="1" width="100%">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {

            if (typeof dateMinTeam !== "undefined") {
                var teamCallSummaryDateRange = dateMinTeam.GetText() + " - " + dateMaxTeam.GetText();
                $("#lblTeamCallSummaryDateRange").html(teamCallSummaryDateRange);
            }

            if (typeof dateMinTeamLeader !== "undefined") {
                var teamLeaderCallEvaluatedSummaryDateRange = dateMinTeamLeader.GetText() + " - " + dateMaxTeamLeader.GetText();
                $("#lblTeamLeaderCallEvaluatedSummaryDateRange").html(teamLeaderCallEvaluatedSummaryDateRange);
            }

            if (typeof dateMinGroup !== "undefined") {
                var groupCallSummaryDateRange = dateMinGroup.GetText() + " - " + dateMaxGroup.GetText();
                $("#lblGroupCallSummaryDateRange").html(groupCallSummaryDateRange);
            }

        });
    </script>


</asp:Content>
