// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//import { data } from "jquery";

// Write your JavaScript code.
(function ($) {
    $.fn.serializeObject = function () {

        var self = this,
            json = {},
            push_counters = {},
            patterns = {
                "validate": /^[a-zA-Z][a-zA-Z0-9_]*(?:\[(?:\d*|[a-zA-Z0-9_]+)\])*$/,
                "key": /[a-zA-Z0-9_]+|(?=\[\])/g,
                "push": /^$/,
                "fixed": /^\d+$/,
                "named": /^[a-zA-Z0-9_]+$/
            };


        this.build = function (base, key, value) {
            base[key] = value;
            return base;
        };

        this.push_counter = function (key) {
            if (push_counters[key] === undefined) {
                push_counters[key] = 0;
            }
            return push_counters[key]++;
        };

        $.each($(this).serializeArray(), function () {

            // Skip invalid keys
            if (!patterns.validate.test(this.name)) {
                return;
            }

            var k,
                keys = this.name.match(patterns.key),
                merge = this.value,
                reverse_key = this.name;

            while ((k = keys.pop()) !== undefined) {

                // Adjust reverse_key
                reverse_key = reverse_key.replace(new RegExp("\\[" + k + "\\]$"), '');

                // Push
                if (k.match(patterns.push)) {
                    merge = self.build([], self.push_counter(reverse_key), merge);
                }

                // Fixed
                else if (k.match(patterns.fixed)) {
                    merge = self.build([], k, merge);
                }

                // Named
                else if (k.match(patterns.named)) {
                    merge = self.build({}, k, merge);
                }
            }

            json = $.extend(true, json, merge);
        });

        return json;
    };
})(jQuery);

PostCreate = function (url, data) {
    $.ajax({
        url: url,
        type: "POST",

        data: data,
        success: function (response) {
            swal("Your data has been created!", {
                icon: "success",
            });
        },
        error: function () {
            alert("error");
        }

    });
}

PostUpdate = function () {
    $.ajax({
        url: "/add.php ",
        type: "POST",

        data: {
            item_id: id,
        },
        success: function (response) {
            //document.getElementById("total_items").value=response;
            document.getElementById("disp").innerHTML = response;
        },
        error: function () {
            alert("error");
        }

    });
}

PostDelete = function (url,redirectUrl) {
    $.ajax({
        url: url,
        type: "DELETE",
        success: function (response) {
            swal({
                text: "Your data has been created!",
                icon: "success"
            })
                .then((isOk) => {
                    if (isOk) {
                        window.location = redirectUrl;
                    } 
                });
           
        },
        error: function () {
            alert("error");
        }

    });
}

