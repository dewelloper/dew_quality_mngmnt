<%@ Page Language="C#" AutoEventWireup="true"
    EnableSessionState="True"
    CodeBehind="AgentCallByDates.aspx.cs"
    Inherits="EvaluationAssistt.Web.Pages.AgentCallByDates" %>

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

            document.getElementById('HiddenField1').value = sParam;
            //ShowReport(values[0]);
            document.getElementById('btnRetriveDetailSource').click();
            reportViewer.Refresh();
        }

        window.onload = function () {
            if (sessionStorage.getItem("Clicked") == null || sessionStorage.getItem("Clicked").toString() != "yes")
                ASPxPopupControl1.Hide();
            else ASPxPopupControl1.ShowAtPos(250, 50);
        }

        window.onunload = function () {
            ASPxPopupControl1.Hide();
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="5">
                        <asp:CheckBox ID="chkQualityAdminAgent" runat="server" Text="Kalite Uzmanı ve Admin Grubunda Filitrele" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <table>
                            <tr>
                                <td>Başlangıç Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxDateStart" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Bitiş Tarihi</td>
                                <td>
                                    <dx:ASPxDateEdit ID="aspxDateEnd" runat="server" AllowNull="False" EditFormat="DateTime" DateOnError="Today">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    <asp:Button ID="btnRetriveCalls" runat="server" OnClick="btnRetriveCalls_Click" Text="Sorgula" Style="cursor: pointer;" />
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
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css"
                            CssPostfix="BlackGlass" ClientInstanceName="gridView1"
                            Width="100%" DataSourceID="ods" AutoGenerateColumns="False"
                            KeyFieldName="Id" OnPageIndexChanged="ASPxGridView1_PageIndexChanged">
                            <ClientSideEvents CustomButtonClick="function(s, e) {
                                        gridView1.SelectRowOnPage(e.visibleIndex, true);
		                                gridView1.GetSelectedFieldValues('Id', OnGridSelectionComplete);
                                }" />
                            <Columns>
                                <dx:GridViewCommandColumn ButtonType="Button" Caption="Preview" VisibleIndex="0" CellStyle-Wrap="True">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="btnPrint" Text="...">
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" CellStyle-Wrap="True"
                                    VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FormID" VisibleIndex="1" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="FormName" Caption="Form Adı" VisibleIndex="2" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CallId" VisibleIndex="3" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EvaluationDate" Caption="Değerlendirilme Tarihi" VisibleIndex="4" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EvaluatorId" Caption="Değerlendiren Id" VisibleIndex="5" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EvaluatorName" Caption="Değerlendirici" VisibleIndex="6" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CalledNumber" Caption="Aranan No" VisibleIndex="6" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CalledDate" Caption="Aranma Tarihi" VisibleIndex="6" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentId" VisibleIndex="7" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="AgentName" Caption="Agent" VisibleIndex="8" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Score" Caption="Puan" VisibleIndex="9" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Duration" Caption="Süre" VisibleIndex="9" CellStyle-Wrap="True">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="10px" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Note" Caption="Not" VisibleIndex="10" CellStyle-Wrap="True" Width="10px">
                                    <HeaderStyle Border-BorderColor="Black" Border-BorderWidth="1px" BackColor="#0A0A2A" Paddings-PaddingTop="5px" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <Styles CssPostfix="BlackGlass" CssFilePath="~/App_Themes/BlackGlass/{0}/styles.css">
                                <Header SortingImageSpacing="5px" ImageSpacing="5px" />
                                <AlternatingRow BackColor="#EFF3FB" />
                            </Styles>
                            <Images ImageFolder="~/App_Themes/BlackGlass/{0}/" />
                            <SettingsPager AlwaysShowPager="true" />
                        </dx:ASPxGridView>

                        <asp:ObjectDataSource ID="ods" runat="server" SortParameterName="sortColumns" EnablePaging="True"
                            StartRowIndexParameterName="startRecord" MaximumRowsParameterName="maxRecords"
                            SelectCountMethod="GetFormCount" SelectMethod="GetFormCallsByFilter" UpdateMethod="GetFormCallsByFilter" TypeName="EvaluationAssistt.Service.Services.EvaluationReportingService">
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
                                <asp:Parameter DefaultValue="" Name="startDate" Type="DateTime" />
                                <asp:Parameter DefaultValue="" Name="endDate" Type="DateTime" />
                                <asp:Parameter Name="startRecord" Type="Int32" />
                                <asp:Parameter Name="maxRecords" Type="Int32" />
                                <asp:Parameter Name="sortColumns" Type="String" />
                                <asp:Parameter Name="reporterId" Type="String" />
                                <asp:Parameter Name="isAdmQ" Type="Boolean" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>

                        <dxpc:ASPxPopupControl ID="ASPxPopupControl1" ClientInstanceName="ASPxPopupControl1" runat="server" HeaderText="Report"
                            AllowDragging="true" AllowResize="true" ShowCloseButton="true" Height="400px" Width="600px" ShowSizeGrip="False">
                            <ContentCollection>
                                <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                                    <div style="background-color: Aqua; text-align: center; border: solid 1px; padding: 10px; min-width: 550px;">
                                        <dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%# ReportViewer1 %>"
                                            ShowDefaultButtons="False" Width="286px">
                                            <Styles>
                                                <LabelStyle>
                                                    <Margins MarginLeft="3px" MarginRight="3px" />
                                                </LabelStyle>
                                            </Styles>
                                            <Items>
                                                <dxxr:ReportToolbarButton ItemKind="Search" ToolTip="Display the search window" />
                                                <dxxr:ReportToolbarSeparator />
                                                <dxxr:ReportToolbarButton ItemKind="PrintReport" ToolTip="Print the report" />
                                                <dxxr:ReportToolbarButton ItemKind="PrintPage" ToolTip="Print the current page" />
                                                <dxxr:ReportToolbarSeparator />
                                                <dxxr:ReportToolbarButton Enabled="False" ItemKind="FirstPage" ToolTip="First Page" />
                                                <dxxr:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" ToolTip="Previous Page" />
                                                <dxxr:ReportToolbarLabel Text="Page" />
                                                <dxxr:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                                                </dxxr:ReportToolbarComboBox>
                                                <dxxr:ReportToolbarLabel Text="of" />
                                                <dxxr:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                                                <dxxr:ReportToolbarButton ItemKind="NextPage" ToolTip="Next Page" />
                                                <dxxr:ReportToolbarButton ItemKind="LastPage" ToolTip="Last Page" />
                                                <dxxr:ReportToolbarSeparator />
                                                <dxxr:ReportToolbarButton ItemKind="SaveToDisk" ToolTip="Export a report and save it to the disk" />
                                                <dxxr:ReportToolbarButton ItemKind="SaveToWindow" ToolTip="Export a report and show it in a new window" />
                                                <dxxr:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                                                    <Elements>
                                                        <dxxr:ListElement Text="Pdf" Value="pdf" />
                                                        <dxxr:ListElement Text="Xls" Value="xls" />
                                                        <dxxr:ListElement Text="Rtf" Value="rtf" />
                                                        <dxxr:ListElement Text="Mht" Value="mht" />
                                                        <dxxr:ListElement Text="Text" Value="txt" />
                                                        <dxxr:ListElement Text="Csv" Value="csv" />
                                                        <dxxr:ListElement Text="Image" Value="png" />
                                                    </Elements>
                                                </dxxr:ReportToolbarComboBox>
                                            </Items>
                                        </dxxr:ReportToolbar>
                                        <dxxr:ReportViewer Width="800" Height="640" ID="ReportViewer1" AutoSize="false" ClientInstanceName="reportViewer" runat="server" OnUnload="ReportViewer1_Unload">
                                        </dxxr:ReportViewer>


                                    </div>
                                </dxpc:PopupControlContentControl>
                            </ContentCollection>
                        </dxpc:ASPxPopupControl>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:Button ID="btnRetriveDetailSource" runat="server" Text="btnRetriveDetailSource" OnClick="btnRetriveDetailSource_Click" Style="visibility: hidden;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                    <td>
                        <asp:Button ID="btnExport1" runat="server" Text="Xlsx" OnClick="btnExport1_Click" />
                        <asp:Button ID="btnExportPdf1" runat="server" Text="Pdf" OnClick="btnExportPdf1_Click" />
                        <asp:Button ID="btnExportRtf1" runat="server" Text="Rtf" OnClick="btnExportRtf1_Click" />
                        <asp:Button ID="btnExportCsv1" runat="server" Text="Csv" OnClick="btnExportCsv1_Click" />
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter2" runat="server">
                        </dx:ASPxGridViewExporter>
                    </td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
