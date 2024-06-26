﻿<script>
 
        //Add event handler.
        $("body").on("click", "#btnAdd", function () {
            var txtName = $("#txtName");
            var txtCountry = $("#txtCountry");
            $.ajax({
                type: "POST",
                url: "/AdminView/InsertCustomer",
                data: '{name: "' + txtName.val() + '", country: "' + txtCountry.val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var row = $("#WebGrid TBODY tr:last-child").clone();
                    if (row.find(".label").is(":empty")) {
                        $("#WebGrid TBODY tr:last-child").remove();
                    }
                    AppendRow(row, r.CustomerId, r.Name, r.Country);
                    txtName.val("");
                    txtCountry.val("");
                }
            });
        });
 
        //Edit event handler.
        $("body").on("click", "#WebGrid TBODY .Edit", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find(".text").length > 0) {
                    $(this).find(".text").show();
                    $(this).find(".label").hide();
                }
            });
            row.find(".Update").show();
            row.find(".Cancel").show();
            row.find(".Delete").hide();
            $(this).hide();
        });
 
        //Update event handler.
        $("body").on("click", "#WebGrid TBODY .Update", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find(".text").length > 0) {
                    var span = $(this).find(".label");
                    var input = $(this).find(".text");
                    span.html(input.val());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Cancel").hide();
            $(this).hide();
 
            var customer = {};
            customer.CustomerId = row.find(".CustomerId").find(".label").html();
            customer.Name = row.find(".Name").find(".label").html();
            customer.Country = row.find(".Country").find(".label").html();
            $.ajax({
                type: "POST",
                url: "/Home/UpdateCustomer",
                data: '{customer:' + JSON.stringify(customer) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            });
        });
 
        //Cancel event handler.
        $("body").on("click", "#WebGrid TBODY .Cancel", function () {
            var row = $(this).closest("tr");
            $("td", row).each(function () {
                if ($(this).find(".text").length > 0) {
                    var span = $(this).find(".label");
                    var input = $(this).find(".text");
                    input.val(span.html());
                    span.show();
                    input.hide();
                }
            });
            row.find(".Edit").show();
            row.find(".Delete").show();
            row.find(".Update").hide();
            $(this).hide();
        });
 
        //Delete event handler.
        $("body").on("click", "#WebGrid TBODY .Delete", function () {
            if (confirm("Do you want to delete this row?")) {
                var row = $(this).closest("tr");
                var customerId = row.find(".label").html();
                $.ajax({
                    type: "POST",
                    url: "/Home/DeleteCustomer",
                    data: '{customerId: ' + customerId + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if ($("#WebGrid TBODY tr").length == 1) {
                            row.find(".label").html("");
                            row.find(".text").val("");
                            row.find(".link").hide();
                        } else {
                            row.remove();
                        }
                    }
                });
            }
        });
    </script>