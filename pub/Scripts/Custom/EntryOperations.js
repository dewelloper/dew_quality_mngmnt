function EntryDelete(id, name, type, sender, url) {
    $.msgbox("<b>Kayıt Silme</b><br /><br /><b>" + name + "</b> isimli " + type + " silinecektir. Devam etmek istediğinize emin misiniz?",
                {
                    type: "confirm",
                    buttons: [
                                { type: "submit", value: "Evet" },
                                { type: "submit", value: "Hayır" }
                    ]
                }, function (result) {
                    if (result == "Evet") {
                        $.ajax({
                            type: 'POST',
                            url: url,
                            dataType: 'json',
                            contentType: 'application/json;charset=utf-8',
                            data: '{"id":"' + id + '"}',
                            success: function (e) {
                                $(sender).parent().parent().remove();
                                $.msgbox("<b>İşlem Başarılı</b><br /><br /><b>" + name + "</b> isimli " + type + " başarıyla silinmiştir",
                                {
                                    type: "info",
                                    buttons: [
                                                { type: "submit", value: "Tamam" }
                                    ]
                                });
                            },
                            error: function (xhr) {
                                $.msgbox("<b>İşlem Başarısız</b><br /><br /><b>" + name + "</b> isimli " + type + " başka bir kayıt ile bağlı olduğundan silinememiştir",
                                {
                                    type: "error",
                                    buttons: [
                                                { type: "submit", value: "Tamam" }
                                    ]
                                });
                            }
                        });
                    }
                });
}

function EntryResignation(id, name, type, sender, url) {
    $.msgbox("<b>Kayıt Güncelleme</b><br /><br /><b>" + name + "</b> isimli " + type + " güncellenecektir. Devam etmek istediğinize emin misiniz?",
                {
                    type: "confirm",
                    buttons: [
                                { type: "submit", value: "Evet" },
                                { type: "submit", value: "Hayır" }
                    ]
                }, function (result) {
                    if (result == "Evet") {
                        $.ajax({
                            type: 'POST',
                            url: url,
                            dataType: 'json',
                            contentType: 'application/json;charset=utf-8',
                            data: '{"id":"' + id + '"}',
                            success: function (e) {
                                $(sender).parent().parent().remove();
                                $.msgbox("<b>İşlem Başarılı</b><br /><br /><b>" + name + "</b> isimli " + type + " başarıyla güncellenmiştir",
                                {
                                    type: "info",
                                    buttons: [
                                                { type: "submit", value: "Tamam" }
                                    ]
                                });
                            },
                            error: function (xhr) {
                                $.msgbox("<b>İşlem Başarısız</b><br /><br /><b>" + name + "</b> isimli " + type + " başka bir kayıt ile bağlı olduğundan güncellenememiştir",
                                {
                                    type: "error",
                                    buttons: [
                                                { type: "submit", value: "Tamam" }
                                    ]
                                });
                            }
                        });
                    }
                });
}

function ClearControls(class_name) {
    jQuery("." + class_name).find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'text':
            case 'textarea':
            case 'file':
            case 'select-one':
            case 'select-multiple':
                jQuery(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}