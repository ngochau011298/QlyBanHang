function PageLoad() {
    var tempListSelected = [];
    var listSelected = [];
    var TotalPrice = 0;
    registerEvent(tempListSelected, listSelected, TotalPrice);
}

function registerEvent(tempListSelected, listSelected, TotalPrice) {
    $('body').on('change', '#chkSelected', function () {
        if ($(this).is(":checked")) {
            Product = new Object();
            Product.TBId = $(this).val();
            Product.ProductName = $(this).parent('td').parent('tr').find('td:eq(1)').text();
            Product.Price = $(this).parent('td').parent('tr').find('td:eq(3)').text();
            Product.Qty = $(this).parent('td').parent('tr').find('td:eq(4)').text();
            Product.SelectedQty = 1;
            tempListSelected.push(Product);
        }
        else {
            index = tempListSelected.findIndex(x => x.TBId == $(this).val());
            tempListSelected.splice(index, 1);
        }
    })

    $('body').on('click', '#btnSelect', function () {
        var render = '';
        $.each(tempListSelected, function (i, item) {
            listSelected.push(item);
            render += '<tr value="'+ item.TBId +'">' +
                '<td>' + item.ProductName + '</td>' +
                '<td><input type="number" class="form-control" value="1" min="1" id="txtQty"/></td>' +
                '<td value="' + item.Price + '">' + item.Price + '</td>' +
                '<td id="btnDelRow"><a><i class="fa fa-trash"></i></a></td>' +
                '</tr>';
            TotalPrice += parseInt(item.Price);
        })
        $('#tblSelectedProduct').append(render);
        $('#frmProduct').trigger('reset');
        tempListSelected = [];
        $('#lblTotalPrice').text(TotalPrice);
    })

    $('body').on('click', '#btnDelRow', function () {
        var thisObj = $(this);
        var id = thisObj.parent('tr').attr('value');
        thisObj.parent('tr').remove();
        TotalPrice = TotalPrice - parseInt($(this).parent('tr').find('td:eq(2)').text());
        $('#lblTotalPrice').text(TotalPrice);
        index = listSelected.findIndex(x => x.TBId == id);
        listSelected.splice(index, 1);
    })

    $('body').on('change', '#txtQty', function () {
        var thisObj = $(this);
        var qty = thisObj.val();
        var price = thisObj.parent('td').parent('tr').find('td:eq(2)').attr('value');
        var id = thisObj.parent('td').parent('tr').attr('value');
        TotalPrice = TotalPrice - parseInt($(this).parent('td').parent('tr').find('td:eq(2)').text());
        $(this).parent('td').parent('tr').find('td:eq(2)').text(qty * price);
        TotalPrice = TotalPrice + qty * price;
        index = listSelected.findIndex(x => x.TBId == id);
        listSelected[index].SelectedQty = qty;
        $('#lblTotalPrice').text(TotalPrice);
    })


    /*
    $('body').on('click', '#btnLapHoaDon', function () {
        $('#MainContent_tblSlc > tbody').empty();
        render = "";
        render += '<tr>' +
            '<th colspan="4">Các sản phẩm đã chọn</th>' +
            '</tr>' +
            '<tr>' +
            '<th>STT</th><th>Tên sản phẩm</th><th>Số lượng</th><th>Thành tiền</th>' +
            '</tr>';
        $.each(listSelected, function (i, item) {
            render += '<tr>' +
                '<td>' + (i + 1) + '</td>' +
                '<td>' + item.ProductName + '</td>' +
                '<td>' + item.SelectedQty + '</td>' +
                '<td>' + item.SelectedQty * item.Price + '</td>' +
                '</tr>';
        })
        render += '<tr>' +
            '<td colspan="4" value="'+ TotalPrice +'"><h4>Tổng tiền: ' + TotalPrice + '</h4></td>' +
            '</tr>';
        //$('#MainContent_tblSlc > tbody').append(render);
        $(render).appendTo($('#MainContent_tblSlc > tbody'))
    })
    */
    $(document).ready(function () {
        function getSelected() {
            $('#tblSelectedProducts').empty();
            render = "";
            /*
            render += '<tr>' +
                '<th colspan="4">Các sản phẩm đã chọn</th>' +
                '</tr>' +
                '<tr>' +
                '<th>STT</th><th>Tên sản phẩm</th><th>Số lượng</th><th>Thành tiền</th>' +
                '</tr>';
            */
            $.each(listSelected, function (i, item) {
                render += '<tr value="' + item.TBId + '">' +
                    '<td>' + (i + 1) + '</td>' +
                    '<td>' + item.ProductName + '</td>' +
                    '<td>' + item.SelectedQty + '</td>' +
                    '<td>' + item.SelectedQty * item.Price + '</td>' +
                    '</tr>';
            })
            render += '<tr>' +
                '<td colspan="4"><h4>Tổng tiền:</h4><input type="text" id="txtTotalPrice" readonly value="'+ TotalPrice +'" runat"server"></td>' +
                '</tr>';
            $(render).appendTo($('#tblSelectedProducts'))
        }
        $('#btnLapHoaDon').click(getSelected);
    })
    /*
    $(document).ready(function () {
        $('#MainContent_btnFindKH').click(function () {
            return false;
        });
    });
    */
    /*
    $('body').on('click', '#btnLapHoaDon', function () {
        $('#MainContent_btnFindKH').removeAttr('onclick');
    })
    */

    $('body').on('click', '#MainContent_btnLap', function () {
        TotalPrice = 0;
        listSelected = [];
    })
}
function LoadKH() {
    var Contact = $('#MainContent_txtPhoneNumber').val();
    $.ajax({
        type: "POST",
        url: "Default.aspx/GetKH",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data:
        "{ contact: '"+Contact+"' }",
        error: function (XMLHttpRequest, textStatus, errorThrown) { 
            
        },
        success: function (result) {
            if (result.d == null) {
                alert("Sai số điện thoại hoặc số điện thoại chưa có");
            }
            else {
                console.log(result)
                $('#MainContent_txtCustomerID').val(result.d.Id);
                $('#MainContent_txtAddress').val(result.d.Address);
                $('#MainContent_txtCustomerName').val(result.d.Name);
            }
        }
    });

}
function SaveHoaDon(TotalPrice) {
    //var hdId = 0;
    var khId = parseInt($('#MainContent_txtCustomerID').val());
  //  var dateCreate = new Date();
    var totalPrice = parseInt($('#txtTotalPrice').val());
    $.ajax({
        type: "POST",
        url: "Default.aspx/SaveInvoice",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({ 'KhId':khId,'total':totalPrice,}),
       
        //{
        //    //mahd: hdid,
        //    khid: khid,
        //    total:  totalprice,
        //},
        error: function (e) {
            console.log(e);
        },
        success: function (result) {
            console.log('successSaveHD');
            $('#formMuahang').trigger('reset');
            $('#tblSelectedProducts').empty();
            $('#LapHoaDon').modal('hide');
            $('#tblSelectedProduct').empty();
            $('#lblTotalPrice').text(0);
            
        }
    });
}

PageLoad();