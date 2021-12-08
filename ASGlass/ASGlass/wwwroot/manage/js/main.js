$(document).ready(function () {

    $('[data-toggle="tooltip"]').tooltip();


    $("select[name='DepartmentId']").change(function () {
        $(".parametrs").empty();
        $.getJSON("/manage/products/categories/" + $(this).val(), function (response) {
            if (response.status == 200) {
                $("select[name='CategoryId']").empty();
                $("select[name='CategoryId']").removeClass("disabled");

                // Secin add
                var opt = $("<option></option>");
                opt.text("Secin");
                opt.val(0);
                $("select[name='CategoryId']").append(opt);

                // List add
                $.each(response.data, function (key, value) {
                    var opt = $("<option></option>");
                    opt.text(value.Name);
                    opt.val(value.Id);
                    $("select[name='CategoryId']").append(opt);
                });
            }
        });
    });

    $("select[name='CategoryId']").change(function () {
        $.getJSON("/manage/products/categoryparamters/" + $(this).val(), function (response) {
            if (response.status == 200) {
                $(".parametrs").empty();
                $.each(response.data, function (key, value) {
                    var elem = `<div class="feature">
                                <div class="feature-heading">
                                    <p>`+ value.name + `</p>
                                </div>
                                `;
                    for (var i = 0; i < value.parametrs.length; i++) {
                        elem += `<div class="feature-item flexbox">
                                    <div class="item-title">
                                        <p>`+ value.parametrs[i].Name +`</p>
                                    </div>
                                    <div class="item-content">
                                         <input data-id="`+ value.parametrs[i].Id+`" type="text" class="form-control" placeholder="Dəyər" />
                                    </div>
                                </div>`
                    }
                                    
                    elem+=`</div>
                            </div>`;
                    $(".parametrs").append(elem);
                });
            }
        });
    });
    $('.select2').select2();

    if (document.querySelector('#Editor')) {
        ClassicEditor.create(document.querySelector('#Editor'));
    }


    // Upload
    $("#Upload").change(function () {
       
        var form_data = new FormData();
        var ins = this.files.length;
        console.log(ins);
        for (var x = 0; x < ins; x++) {
            form_data.append("files[]", this.files[x]);
        }
     
        $.ajax({
            url: "/manage/products/upload",
            type: "post",
            dataType: "json",
            data: form_data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                for (var i = 0; i < response.data.length; i++) {
                    var item = `<li>
                                    <img src="`+ response.data[i].url + `"/>
                                    <a class="remove" data-file='`+ response.data[i].filename + `' href="#"><i class="fa fa-times"></i></a>
                                </li>`;
                    $(".photos").append(item);
                }
            }
        })
    });

    $(document).on("click", ".photos .remove", function (ev) {
        ev.preventDefault();
        $this = $(this);
        var filename = $(this).data("file");
        $.ajax({
            url: "/manage/products/removefile?filename=" + filename,
            type: "get",
            dataType: "json",
            success: function (response) {
                if (response.status == 200) {
                    $this.parent().remove();
                }
            }
        });
    });

    // Submit Product
    $(".CreateProduct").click(function () {
        var info = $(".infoform").serializeArray();
        var data = {};
        for (var i = 0; i < info.length; i++) {
            data[info[i].name] = info[i].value;
        }
        data.ProductParametrs = [];

        $(".parametrs .feature-item").each(function () {
            var prm = {
                ParametrId: $(this).find("input").data("id"),
                Value : $(this).find("input").val(),
            }
            data.ProductParametrs.push(prm);
        });

        data.Photos = [];

        $(".photos li").each(function (index) {
            var pth = {
                OrderBy : index+1,
                Path : $(this).find("a").data("file"),
            }
            data.Photos.push(pth);
        });
        var tags = $('#Tags').select2('val');
        data.ProductTags = [];

        for (var i = 0; i < tags.length; i++) {
            var tg = {
                TagId: tags[i]
            }
            data.ProductTags.push(tg);
        }
        console.log(data);
        $.ajax({
            url: "/manage/products/create",
            type: "post",
            dataType: "json",
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    var getUrl = window.location;
                    var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
                    window.location.href = baseUrl + "/manage/products";
                } else {
                    toastr.error(response.message)
                }
            }
        })
    });

    // Toggle Status

    $(".StatusToggle").click(function () {
        $this = $(this);
        $.ajax({
            url: "/manage/products/togglestatus/" + $(this).parents("tr").data("id") + "?status=" + $(this).data("val"),
            type: "get",
            dataType: "json",
            success: function (response) {
                if ($this.data("val") == true) {
                    $this.data("val", false);
                    $this.removeClass("badge-warning").addClass("badge-success").text("Aktiv");
                } else {
                    $this.data("val", true);
                    $this.removeClass("badge-success").addClass("badge-warning").text("Deaktiv");
                }
            }
        })
    });

    // Edit Product

    $(".EditProduct").click(function () {
        var info = $(".infoform").serializeArray();
        var productId = $(".infoform").data("id");
        var data = {};
        
        data.Product = {};
        data.Product["Id"] = productId;
        for (var i = 0; i < info.length; i++) {
            data.Product[info[i].name] = info[i].value;
        }

        data.Parametrs = [];

        $(".parametrs .feature-item").each(function () {
            var prm = {
                ProductId : productId,
                ParametrId: $(this).find("input").data("id"),
                Value: $(this).find("input").val(),
            }
            data.Parametrs.push(prm);
        });

        data.Images = [];

        $(".photos li").each(function (index) {
            var pth = {
                ProductId : productId,
                OrderBy: index + 1,
                Path: $(this).find("a").data("file"),
            }
            data.Images.push(pth);
        });
        var tags = $('#Tags').select2('val');

        data.Tags = [];

        for (var i = 0; i < tags.length; i++) {
            var tg = {
                ProductId : productId,
                TagId: tags[i]
            }
            data.Tags.push(tg);
        }

        $.ajax({
            url: $(".infoform").attr("action"),
            type: "post",
            dataType: "json",
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    var getUrl = window.location;
                    var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
                    window.location.href = baseUrl + "/products";
                } else {
                    toastr.error(response.message)
                }
            },
            error: function (jqXHR, exception) {
                toastr.warning("Bilinmədik bi xəta baş verdi, təkrar sınayın")
            },
        })
    });
});