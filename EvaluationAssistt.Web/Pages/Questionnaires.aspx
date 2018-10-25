<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Questionnaires.aspx.cs" Inherits="EvaluationAssistt.Web.Pages.Questionnaires" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="../Scripts/jQuery/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        function ToggleCategoriesRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedcategory", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedcategory") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedcategory", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("categories").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#category_" + t).toggle();

                        var y = $("#category_" + t).find('input[name^="radio"], input[name^="check"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var categories = $(sender).attr("categories").split(",");
            for (var i = 0; i < categories.length; i++) {
                var id = categories[i];
                $("#category_" + id).toggle();

                var y = $("#category_" + t).find('input[name^="radio"], input[name^="check"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleSectionsRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedsection", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedsection") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedsection", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("sections").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#section_" + t).toggle();

                        var y = $("#section_" + t).find('input[name^="radio"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var sections = $(sender).attr("sections").split(",");
            for (var i = 0; i < sections.length; i++) {
                var id = sections[i];
                $("#section_" + id).toggle();

                var y = $("#section_" + t).find('input[name^="radio"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleQuestionsRadio(sender) {
            var radios = $(sender).parent().children('input[name^="radio"]');

            var isChecked = false;

            for (var i = 0; i < radios.length; i++) {
                if (radios[i] == sender) {
                    $(radios[i]).attr("markedquestion", "1");
                    continue;
                }

                if ($(radios[i]).attr("markedquestion") == "1") {
                    isChecked = true;
                    $(radios[i]).attr("markedquestion", "0");
                }
            }

            if (isChecked) {
                for (var i = 0; i < radios.length; i++) {

                    if (radios[i] == sender)
                        continue;

                    var disable = $(radios[i]).attr("questions").split(",");

                    for (var j = 0; j < disable.length; j++) {
                        var t = disable[j];
                        $("#question_" + t).toggle();

                        var y = $("#question_" + t).find('input[name^="radio"]');
                        for (var p = 0; p < y.length; p++) {
                            y[p].checked = false;
                        }
                    }
                }
            }

            var questions = $(sender).attr("questions").split(",");
            for (var i = 0; i < questions.length; i++) {
                var id = questions[i];
                $("#question_" + id).toggle();

                var y = $("#question_" + t).find('input[name^="radio"]');
                for (var j = 0; j < y.length; j++) {
                    y[j].checked = false;
                }
            }
        }

        function ToggleCategoriesCheck(sender) {
            var categories = $(sender).attr("categories").split(",");
            for (var i = 0; i < categories.length; i++) {
                var id = categories[i];
                $("#category_" + id).toggle();

                var y = $("#category_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        function ToggleSectionsCheck(sender) {
            var sections = $(sender).attr("sections").split(",");
            for (var i = 0; i < sections.length; i++) {
                var id = sections[i];
                $("#section_" + id).toggle();

                var y = $("#section_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        function ToggleQuestionsCheck(sender) {
            var questions = $(sender).attr("questions").split(",");
            for (var i = 0; i < questions.length; i++) {
                var id = questions[i];
                $("#question_" + id).toggle();

                var y = $("#question_" + id).find('input[name^="check"], input[name^="radio"]');
                for (var i = 0; i < y.length; i++) {
                    y[i].checked = false;
                }
            }
        }

        function CalculateScore() {
            var formId = $("#hiddenFormId").val();

            var answers_radio = $('input[name^="radio"]').filter(":checked");
            var answers_radio_string = "";

            for (var i = 0; i < answers_radio.length; i++) {
                answers_radio_string += $(answers_radio[i]).attr("answer") + "-";
            }

            var answers_check = $('input[name^="check"]').filter(":checked");
            var answers_check_string = "";

            for (var i = 0; i < answers_check.length; i++) {
                answers_check_string += $(answers_check[i]).attr("answer") + "-";
            }

            if (document.getElementById('content_hdnIsCalculated') != null)
                document.getElementById('content_hdnIsCalculated').value = "";
            else document.getElementById('hdnIsCalculated').value = "";

            $.ajax({
                type: 'POST',
                url: "/Pages/Questionnaires.aspx/IsAllReplied",
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: '{"radioScores":"' + answers_radio_string + '","cancelledParts":"' + canceledCatIds + '"}',
                success: function (e) {
                    if (e.d.trim() == "") {
                        document.getElementById('content_btnSave').disabled = false;
                        $.ajax({
                            type: 'POST',
                            url: "/Pages/Questionnaires.aspx/CalculateScoreOnCs",
                            dataType: 'json',
                            contentType: 'application/json;charset=utf-8',
                            data: '{"radioScores":"' + answers_radio_string + '", "checkScores":"' + answers_check_string + '", "formId":"' + formId + '"}',
                            success: function (e) {
                                var _totalScore = $("#hiddenTotalScore").val();

                                var totalScore = parseInt(_totalScore);
                                var calculated = parseInt(e.d);

                                var result = 0;
                                if (document.getElementById('hdnIsRised') != null && document.getElementById('hdnIsRised').value != 'Artan')
                                    result = totalScore - calculated;
                                else result = calculated;

                                if (result < 0)
                                    result = 0;

                                if (document.getElementById('content_hdnIsCalculated') != null)
                                    document.getElementById('content_hdnIsCalculated').value = 1;
                                else document.getElementById('hdnIsCalculated').value = 1;

                                $("#lblTotalScore").html(result);
                            }
                        })
                    }
                    else {
                        alert("Soruların bazılarına cevap vermediniz lütfen tüm soruları cevaplayınız?");
                    }
                }
            })


        }

        function IsCalculated() {
            if (document.getElementById('content_hdnIsCalculated') != null)
                return document.getElementById('content_hdnIsCalculated').value;
            else return document.getElementById('hdnIsCalculated').value;
        }

        $(document).ready(function () {
            document.getElementById('content_btnSave').disabled = true;
        });

        function SubmitForm() {
            var requestRunning = false;
            if (requestRunning) { // don't do anything if an AJAX request is pending
                return;
            }

            var all_answers = $('input[name^="radio"], input[name^="check"]').filter(":checked");

            var ids = "";

            for (var i = 0; i < all_answers.length; i++) {
                ids += $(all_answers[i]).attr("answer") + "-";
            }

            var _comments = $('input[id^="txtComment"]');
            var comments = "";

            for (var i = 0; i < _comments.length; i++) {
                var questionId = $(_comments[i]).attr("id").split("_")[3];
                comments += questionId + "_" + $(_comments[i]).val() + "-";
            }

            var formId = cmbForms.GetValue();
            var callId = getParameterByName("CallId");

            var score = parseInt($("#lblTotalScore").html());
            var evalutaionNote = document.getElementById('txtEvaluationNote').value.toString().replace(/"/g, "");

            if (document.getElementById('content_hdnIsSaved').value == '') {
                requestRunning = true;
                $.ajax({
                    type: 'POST',
                    url: "/Pages/Questionnaires.aspx/SubmitForm",
                    dataType: 'json',
                    contentType: 'application/json;charset=utf-8',
                    data: '{"ids":"' + ids + '", "formId":"' + formId + '", "callId":"' + callId + '", "comments":"' + comments + '", "score":"' + score + '","evalutaionNote":"' + evalutaionNote + '"}',
                    success: function (e) {
                        document.getElementById('content_hdnIsSaved').value = 'saved';
                        $("#btnSave").css("display", "none");
                        $.msgbox("Değerlendirme kaydedilmiştir...", {
                            type: "info",
                            buttons:
                                        [
                                            { type: "submit", value: "Tamam" }
                                        ]
                        })
                        window.location = "CallManagement.aspx";
                    },
                    error: function (e) {
                        $.msgbox("Formda eksik kalan veya doldurulmamış alanlar olabilir, kontrol edip tekrar dener misiniz... exception data: " + e.d.toString(), {
                            type: "info",
                            buttons:
                                        [
                                            { type: "submit", value: "Tamam" }
                                        ]
                        })
                    }
                })
            }
            else {
                $.msgbox("Çağrıyı yeniden değerlendirmek için ana sayfaya gidiniz...", {
                    type: "info",
                    buttons:
                                [
                                    { type: "submit", value: "Tamam" }
                                ]
                })
            }
        }

        function getParameterByName(name) {
            name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regexS = "[\\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.search);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, " "));
        }

        function AddComment(txtId) {
            var txt = $("#" + txtId);
            $.msgbox("<span class=\"label\">Açıklama : </span><br /><br /><textarea id=\"txtMboxComment\" class=\"simple_field\" cols=\"1\" rows=\"5\" style=\"width:100%; height:100px;\">" + $(txt).val() + "</textarea>",
                {
                    type: "info",
                    buttons:
                        [
                            { type: "submit", value: "Tamam" }
                        ]
                }, function (result) {
                    var comment = $("#txtMboxComment").text();
                    $(txt).val(comment);
                });
        }

        function UpdateScoreTexts() {
            $(".widget_header[type^='category']").each(function () {

                var totalScore = 0;

                var inputs = $(this).next().find('input[name^="radio"]').filter(":checked");

                for (var i = 0; i < inputs.length; i++) {
                    var score = $(inputs[i]).attr("score");
                    totalScore += parseInt(score);
                }

                var text = $(this).children("h4:first-child").text().split(" | ")[0];

                $(this).children("h4:first-child").text(text + " | " + totalScore + " puan");

            });

            $(".widget_header[type='section']").each(function () {

                var categories = $(this).next().find(".widget_header");

                var sectionScore = 0;

                for (var i = 0; i < categories.length; i++) {
                    var text = $(categories[i]).children("h4:first-child").text().split(" | ")[1];

                    var index = text.indexOf("-");
                    index += 1;

                    var index2 = text.indexOf(" puan");

                    var score = text.substring(index, index2);
                    score = parseInt(score);
                    sectionScore += score;
                }

                var text = $(this).children("h4:first-child").text().split(" | ")[0];

                $(this).children("h4:first-child").text(text + " | " + sectionScore + " puan");

            });

            if (document.getElementById('hdnIsRised') != null) {
                var isRaised = document.getElementById('hdnIsRised').value;
                var totalScore = 0;
                if (isRaised == 'Azalan') {
                    totalScore = $("#hiddenTotalScore").val();
                    $("#lblTotalScore").html(totalScore);
                }
                else {
                    $("#lblTotalScore").html('0');
                }
            }
        }

        var canceledCatIds = new Array();
        function IsThisChecked(e) {
            var cat = e.parentElement.parentElement.parentElement.id.split("_")[1];
            if ($.inArray(cat, canceledCatIds) == -1 && e.checked)
                canceledCatIds.push(cat);
            else canceledCatIds.splice(cat);
        }

        function markAllAsCompleted() {
            var relems = $('input[name^="radio"]');
            var thebigscore = 0;
            var selectedscore = 0;
            $('input[name^="radio"]')[0].checked = true;
            var questionname = "";
            var bigFinderIndex = 0;
            for (var k = 0; k < relems.length; k++) {
                if (thebigscore < parseInt($('input[name^="radio"]')[k].attributes[10].value)) {
                    thebigscore = parseInt($('input[name^="radio"]')[k].attributes[10].value);
                    bigFinderIndex = k;
                }

                if (questionname != $('input[name^="radio"]')[k].name || selectedscore < thebigscore) {
                    $('input[name^="radio"]')[bigFinderIndex].checked = true;
                    selectedscore = thebigscore;
                }
                thebigscore = 0;
                questionname = $('input[name^="radio"]')[k].name;
            }
        }

        function markAnyAsCompleted() {
            var relems = $('input[name^="radio"]');
            var thelitlescore = 100000;
            var selectedscore = 0;
            $('input[name^="radio"]')[0].checked = true;
            var questionname = "";
            var bigFinderIndex = 0;
            for (var k = 0; k < relems.length; k++) {
                if (thelitlescore > parseInt($('input[name^="radio"]')[k].attributes[10].value)) {
                    thelitlescore = parseInt($('input[name^="radio"]')[k].attributes[10].value);
                    bigFinderIndex = k;
                }

                if (questionname != $('input[name^="radio"]')[k].name || selectedscore > thelitlescore) {
                    $('input[name^="radio"]')[bigFinderIndex].checked = true;
                    selectedscore = thelitlescore;
                }
                thelitlescore = 100000;
                questionname = $('input[name^="radio"]')[k].name;
            }
        }

    </script>
    <script type="text/javascript" src="http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/audio-player.js"></script>
    <script type="text/javascript">
        AudioPlayer.setup("http://<%=ConfigurationManager.AppSettings["SoundFileIp"].ToString() %>/Scripts/player.swf", {
        });
    </script>
    <link href="/Contents/Css/sticky.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="g_6 contents_header">
        <h3 class="i_16_forms tab_label">Değerlendirme Formu</h3>
    </div>

    <asp:HiddenField ID="hdnIsCalculated" runat="server" Value="" />
    <asp:HiddenField ID="hdnIsSaved" runat="server" Value="" />
    <div class="g_12">
        <div class="g_3">
            <table cellpadding="3" cellspacing="5">
                <tr>
                    <td><span class="label">Müşteri Temsilcisi</span></td>
                    <td><span class="label">:</span> </td>
                    <td>
                        <asp:Label ID="lblAgentName" CssClass="label" Text="" runat="server" /></td>
                    <td>&nbsp;</td>
                    <td rowspan="7">
                        <div style="width: 400px; float: left; visibility: hidden;">
                            <fieldset>
                                <h5>Flags</h5>
                                <div>
                                    <asp:CheckBoxList ID="chklstStates" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="303px" CssClass="inputCheckbox">
                                    </asp:CheckBoxList>
                                </div>
                                <asp:Button ID="btnSaveFlags" runat="server" Width="70px" Height="26px" OnClick="btnSaveFlags_Click" Text="Flagle" Style="margin-top: 15px;" />
                            </fieldset>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td><span class="label">Kayıt Tarihi</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Label ID="lblDateStarted" CssClass="label" Text="" runat="server" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="label">Telefon
                    </span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" CssClass="label"></asp:Label></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="label">Çağrı Kaydı
                    </span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <asp:Literal ID="litPlayer" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="label">Form</span></td>
                    <td><span class="label">:</span></td>
                    <td>
                        <dx:ASPxComboBox ID="cmbForms" ClientInstanceName="cmbForms" runat="server" ValueType="System.Int32" AutoPostBack="true" OnSelectedIndexChanged="cmbForms_SelectedIndexChanged">
                        </dx:ASPxComboBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="label">Toplam Puan</span></td>
                    <td><span class="label">:</span></td>
                    <td><span class="label" id="lblTotalScore"></span></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpDetails" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="g_12 separator">
        <a style="font-family: Tahoma; font-size: smaller;">Değerlendirme Notu:</a><br />
        <textarea style="font-family: Tahoma; font-size: 10px;" id="txtEvaluationNote" rows="4" cols="100"></textarea>

        <table>
            <tr>
                <td>
                    <input id="btnCalculateScore" type="button" value="Puan Hesapla" onclick="    CalculateScore();" />
                </td>
                <td>
                    <input id="btnSave" runat="server" type="button" value="Kaydet" onclick="SubmitForm();" /></td>
                <td>
                    <input id="btnAutoOke" runat="server" type="button" value="Max Puanla" onclick="markAllAsCompleted();" />
                </td>
                <td>
                    <input id="Button1" runat="server" type="button" value="Min Puanla" onclick="markAnyAsCompleted();" />
                </td>
            </tr>
        </table>
    </div>


    <%
        List<EvaluationAssistt.Domain.Dto.SectionsDto> sections = this.Sections.ToList();


        foreach (EvaluationAssistt.Domain.Dto.SectionsDto section in sections)
        {
            if (section.IsDisabled)
                continue;
            
    %>

    <asp:HiddenField ID="hdnIsRised" runat="server" Value='<%:section.ScoreTypeName %>' />

    <div class="g_12" id='<%:"section_" + section.Id %>'>
        <div class="widget_header" type="section">
            <h4 class="widget_header_title wwIcon i_16_forms"><%:section.Name %>
            </h4>
        </div>
        <div class="widget_contents noPadding">
            <div class="line_grid">
                <%
            
            section.Categories = presenter.GetCategoriesBySectionId(section.Id).ToList();
            foreach (EvaluationAssistt.Domain.Dto.CategoriesDto category in section.Categories)
            {
                if (category.IsDisabled)
                    continue;
                
                %>
                <div class="g_12" id='<%:"category_" + category.Id %>'>
                    <div class="widget_header" type="category">
                        <h4 class="widget_header_title wwIcon i_16_forms"><%:category.Name %>
                        </h4>
                        <%--                        <div>
                            <input type="checkbox" class="passEvaluation" id="chkIsCanceled"
                                onchange="IsThisChecked(this);" value="Bu kategoriyi değerlendirmeden geç" />
                        </div>--%>
                    </div>

                    <div class="widget_contents noPadding">
                        <div class="line_grid">
                            <%
                category.Questions = presenter.GetQuestionsByCategoryId(category.Id).ToList();

                foreach (EvaluationAssistt.Domain.Dto.QuestionsDto question in category.Questions)
                {
                    if (EvaluationAssistt.Infrastructure.Helpers.UserHelper.Type.ToString() == "Agent")
                        btnSave.Visible = false;

                    question.Answers = presenter.GetAnswersByQuestionId(question.Id);
                    
                            %><div id='<%:"question_" + question.Id %>'>
                                <span class="label" style="color: red; font-weight: bold;">
                                    <%:String.Format("Soru {0}: {1}", category.Questions.IndexOf(question) + 1, question.QuestionText) %>
                                </span>
                                <br />
                                <div>
                                    <%foreach (EvaluationAssistt.Domain.Dto.AnswersDto answer in question.Answers)
                                      {
                                          answer.CategoriesToToggle = presenter.GetCategoriesToToggleByAnswerId(answer.Id);
                                          string JsParametersCategoriesToggle = String.Join(",", answer.CategoriesToToggle);
                                          answer.SectionsToToggle = presenter.GetSectionsToToggleByAnswerId(answer.Id);
                                          string JsParametersSectionsToggle = String.Join(",", answer.SectionsToToggle);
                                          answer.QuestionsToToggle = presenter.GetQuestionsToToggleByAnswerId(answer.Id);
                                          string JsParametersQuestionsToggle = String.Join(",", answer.QuestionsToToggle);
                                    %>
                                    <%if (question.HasMultipleAnswers)
                                      {%>
                                    <input type="checkbox" name='<%:String.Format("check_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:answer.IsDefault ? "checked='checked'" : "" %>
                                        answer='<%:String.Format("check_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                        onchange='ToggleCategoriesCheck(this); ToggleSectionsCheck(this); ToggleQuestionsCheck(this); UpdateScoreTexts();'
                                        categories='<%:JsParametersCategoriesToggle %>'
                                        sections='<%:JsParametersSectionsToggle %>'
                                        questions='<%:JsParametersQuestionsToggle %>'
                                        score='<%:answer.Score.ToString() %>' />
                                    <span class="label"><%: answer.AnswerText%></span>
                                    <br />
                                    <%}
                                      else
                                      {%>
                                    <input type="radio" name='<%:String.Format("radio_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>' <%:answer.IsDefault ? "checked='checked'" : "" %>
                                        answer='<%:String.Format("radio_{0}_{1}_{2}_{3}", section.Id, category.Id, question.Id, answer.Id) %>'
                                        onchange="ToggleCategoriesRadio(this); ToggleSectionsRadio(this); ToggleQuestionsRadio(this); UpdateScoreTexts();"
                                        markedcategory="0" markedsection="0" markedquestion="0"
                                        categories='<%:JsParametersCategoriesToggle %>'
                                        sections='<%:JsParametersSectionsToggle %>'
                                        questions='<%:JsParametersQuestionsToggle %>'
                                        score='<%:answer.Score.ToString() %>' />
                                    <span class="label"><%: answer.AnswerText %></span>
                                    <br />
                                    <%}
                                      } %>
                                </div>
                                <%
                    if (question.HasComment)
                    {%>
                                <br />
                                <span class="label" style="vertical-align: top; font-size: 12px;">Açıklama Gir</span>&nbsp;<img src="/Contents/Images/Icons/16/i_16_edit.png" alt="addComment" style="cursor: pointer;"
                                    onclick='<%:String.Format("AddComment('txtComment_{0}_{1}_{2}');", section.Id, category.Id, question.Id) %>' />
                                <input type="text" class="simple_field" id='<%:String.Format("txtComment_{0}_{1}_{2}", section.Id, category.Id, question.Id) %>'
                                    style="width: 100%; display: none;" />
                                <%}%>
                                <br />
                            </div>
                            <%
                }%>
                        </div>
                    </div>
                </div>
                <%  } %>
            </div>
        </div>
    </div>
    <%} %>
    <div class="g_12">
        <asp:HiddenField ID="hiddenFormId" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hiddenTotalScore" runat="server" ClientIDMode="Static" Value="" />
        <asp:HiddenField ID="hiddenMarked" runat="server" ClientIDMode="Static" Value="False" />


    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            $(".widget_header").click();
            UpdateScoreTexts();

            //var totalScore = $("#hiddenTotalScore").val();

            //$("#lblTotalScore").html(totalScore);

            //if (!totalScore) {
            //    $("#btnSave").hide();
            //    $("#btnCalculateScore").hide();
            //}
            //else {
            //    $("#btnSave").show();
            //    $("#btnCalculateScore").show();
            //}
        });
    </script>
</asp:Content>

