<%@ Page Language="C#" AutoEventWireup="true"
    EnableSessionState="True"
    CodeBehind="AgentTeamByDates.aspx.cs"
    Inherits="EvaluationAssistt.Web.Pages.AgentTeamByDates" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxpc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/jQuery/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/jQueryUI/jquery-ui-1.8.21.min.js"></script>
    <script language="javascript" type="text/javascript">

        function OnGridSelectionComplete(values) {
            sessionStorage.setItem("Clicked", "yes");
            var sParam = "";
            for (var i = 0; i < values.length; i++) {
                sParam += values[i].toString() + ",";
            }

            document.getElementById('HiddenField2').value = sParam;
            //ShowReport(values[0]);
            //document.getElementById('btnRetriveTeamCalls').click();
            //reportViewer.Refresh();
        }

        //window.onload = function () {
        //    if (sessionStorage.getItem("Clicked") == null || sessionStorage.getItem("Clicked").toString() != "yes")
        //        ASPxPopupControl1.Hide();
        //    else ASPxPopupControl1.ShowAtPos(250, 50);
        //}

        //window.onunload = function () {
        //    ASPxPopupControl1.Hide();
        //}


    </script>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="5">
                        <asp:CheckBox ID="chkQualityAdmin" runat="server" Text="Kalite Uzmanı ve Admin Grubunda Filitrele" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxDateStart2" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxDateEnd2" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <asp:Button ID="btnTeamCalls" runat="server" Text="Sorgula" OnClick="btnTeamCalls_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <dx:ASPxGridView ID="ASPxGridView2" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView2"
                            Width="100%" DataSourceID="ods2" AutoGenerateColumns="False">
                            <ClientSideEvents CustomButtonClick="function(s, e) {
		                                gridView2.GetSelectedFieldValues('Id', OnGridSelectionComplete);
                                }" />               
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="0" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentName" Caption="Agent" VisibleIndex="1" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentIdIP" Caption="AgentId" VisibleIndex="2" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentId" VisibleIndex="2" CellStyle-Wrap="True" Visible="false">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AvarageScore" Caption="Ortalama Puanı" VisibleIndex="3" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TotalScore" Caption="Toplam Puanı" VisibleIndex="4" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CallCount" Caption="Çağrı Sayısı" VisibleIndex="5" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager AlwaysShowPager="true" />
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="ods2" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetPeopleCount" SelectMethod="GetTeamCallsByFilter" TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService" UpdateMethod="GetTeamCallsByFilter">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="" Name="startDate" Type="DateTime" />
                                <asp:Parameter DefaultValue="" Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="startDate" Type="DateTime" />
                                <asp:Parameter Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>

                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:right;">
                        Export:</td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Xlsx" />
                        <asp:Button ID="btnExportPdf" runat="server" OnClick="btnExportPdf_Click" Text="Pdf" />
                        <asp:Button ID="btnExportRtf" runat="server" OnClick="btnExportRtf_Click" Text="Rtf" />
                        <asp:Button ID="btnExportCsv" runat="server" OnClick="btnExportCsv_Click" Text="Csv" />
                    </td>
                </tr>
            </table>


        </div>
        <br />
        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
        </dx:ASPxGridViewExporter>
    </form>
</body>
</html>
