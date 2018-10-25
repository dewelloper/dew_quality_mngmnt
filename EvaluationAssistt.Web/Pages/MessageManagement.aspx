<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MessageManagement.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.MessageManagement" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Import Namespace="EvaluationAssistt.Infrastructure.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Custom/EntryOperations.js"></script>
    <script type="text/javascript">
        function SendMessage() {
            var subject = $("#txtSubject").val();
            var content = $("#txtContent").text();
            var toList = lstboxUsers.GetSelectedValues();

            $.ajax({
                type: 'POST',
                url: "/Pages/MessageManagement.aspx/SendMessage",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"subject":"' + subject + '", "content":"' + content + '", "to":"' + toList + '"}',
                success: function (e) {
                    ClearControls("pnlRegister");
                    lstboxUsers.UnselectAll();

                    $.msgbox("<b>İşlem Başarılı</b><br /><br />Mesajınız başarıyla gönderilmiştir", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    });
                }
            })
        }

        function GetMessage(messageId, index, edit) {

            var title;
            var gridview;

            if (edit == true) {
                title = "Gönderen";
                gridview = gridviewMessagesReceived;
            }
            else {
                title = "Kime";
                gridview = gridviewMessagesSent;
            }

            var isRead = (gridview.GetRow(index).cells[0].innerHTML).indexOf("checked") != -1;
            var sender = gridview.GetRow(index).cells[2].innerText;
            var subject = gridview.GetRow(index).cells[3].innerText
            var date = gridview.GetRow(index).cells[4].innerText;

            var title = edit == true ? "Gönderen" : "Kime";

            $.ajax({
                type: 'POST',
                url: "/Pages/MessageManagement.aspx/GetMessage",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"messageId":"' + messageId + '"}',
                success: function (e) {
                    $.msgbox("<table cellpadding=\"5\" cellspacing=\"5\"><tr><td><span class=\"label\">Tarih</span></td><td><span class=\"label\">:</span></td><td><span class=\"label\">" + date + "</span></td></tr><tr><td><span class=\"label\">" + title + "</span></td><td><span class=\"label\">:</span></td><td><span class=\"label\"> " + sender + "</span></td></tr><tr><td><span class=\"label\">Konu</span></td><td><span class=\"label\">:</span></td><td><span class=\"label\">" + subject + "</span></td></tr><tr><td><span class=\"label\">Mesaj</span></td><td><span class=\"label\">:</span></td><td><div style=\"overflow-y:scroll;\"><span class=\"label\">" + e.d + "</span></div></td></tr></table>", {
                        type: "info",
                        buttons:
                            [
                                { type: "submit", value: "Tamam" }
                            ]
                    });

                    if (edit && !isRead)
                        MarkMessageAsRead(messageId);
                }
            })
        }

        function MarkMessageAsRead(messageId) {
            $.ajax({
                type: 'POST',
                url: "/Pages/MessageManagement.aspx/MarkMessageAsRead",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"messageId":"' + messageId + '"}',
                success: function (e) {
                    gridviewMessagesReceived.GetRow(0).cells[0].innerHTML = "<center><img src=\"/Contents/Images/Icons/16/i_16_checked.png\"></center>";
                    var count = $("#lblMessageCount").html();
                    var total = parseInt(count);
                    $("#lblMessageCount").html((total - 1).toString());
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Mesaj Yönetimi</h3>
    </div>
    <asp:Panel ID="pnlRegister" CssClass="pnlRegister" runat="server" Visible="false">
        <div class="g_12 separator">
            
        </div>
        <div class="g_12">
            <div class="widget_header">
                <h4 class="widget_header_title wwIcon i_16_forms">Yeni Mesaj</h4>
            </div>
            <div class="widget_contents noPadding">
                <div class="line_grid">
                    <div class="g_3">
                        <table cellpadding="5" cellspacing="5" width="100%">
                            <tr>
                                <td><span class="label">Konu</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <asp:TextBox ID="txtSubject" ClientIDMode="Static" runat="server" EnableTheming="false" Width="300px" CssClass="simple_field" /></td>
                                <td>
                                    <span class="label">Kime</span>
                                </td>
                                <td>
                                    <span class="label">:</span>
                                </td>
                                <td rowspan="2" valign="top">
                                    <dx:ASPxListBox ID="lstboxUsers" ClientInstanceName="lstboxUsers" SelectionMode="CheckColumn" runat="server"
                                        ValueType="System.Int32" Width="300px" Height="138px">
                                    </dx:ASPxListBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span class="label">Mesaj</span></td>
                                <td><span class="label">:</span></td>
                                <td>
                                    <textarea id="txtContent" rows="5" cols="1" class="simple_field" style="width: 300px; height: 100px"></textarea></td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <br />
                                    <br />
                                    <input type="button" value="Gönder" onclick="SendMessage();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Gelen Kutusu</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3">
                    <dx:ASPxGridView ID="gridviewMessagesReceived" ClientInstanceName="gridviewMessagesReceived" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Okundu" FieldName="IsRead" Width="50px">
                                <DataItemTemplate>
                                    <%#HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("IsRead"))) %>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Oku" Width="50px" FieldName="(None)">
                                <DataItemTemplate>
                                    <a href="javascript:void(0)" onclick='<%# String.Format("javascript:GetMessage({0}, {1}, true);", Eval("MessageId"), Container.VisibleIndex) %>'>
                                        <img src="../Contents/Images/Icons/32/i_32_inbox.png" width="24" height="24" alt="Oku" />
                                    </a>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Kimden" FieldName="Sender">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Konu" FieldName="Subject">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Tarih" FieldName="Date" PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm" Width="120px">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>
    <div class="g_12 separator">
        
    </div>
    <div class="g_12">
        <div class="widget_header">
            <h4 class="widget_header_title wwIcon i_16_forms">Giden Kutusu</h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <div class="g_3">
                    <dx:ASPxGridView ID="gridviewMessagesSent" ClientInstanceName="gridviewMessagesSent" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Okundu" FieldName="IsRead" Width="50px">
                                <DataItemTemplate>
                                    <%#HtmlHelper.TrueFalseIcon(Convert.ToBoolean(Eval("IsRead"))) %>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Oku" Width="50px" FieldName="(None)">
                                <DataItemTemplate>
                                    <a href="javascript:void(0)" onclick='<%# String.Format("javascript:GetMessage({0}, {1}, false);", Eval("MessageId"), Container.VisibleIndex) %>'>
                                        <img src="../Contents/Images/Icons/32/i_32_inbox.png" width="24" height="24" alt="Oku" />
                                    </a>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Kime" FieldName="To">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Konu" FieldName="Subject">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Tarih" FieldName="Date" PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm" Width="120px">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
