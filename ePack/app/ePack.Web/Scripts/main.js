$(document).ready(function() {

    $('#txtName').example('NOMBRE DE USUARIO');
    $('#txtPass').example('CONTRASEÑA');

    $(".firstTab").bind("mouseenter", function() {
        FirstTabHovered();
    }).bind("mouseleave", function() {
        $(this).css("background", "url(/img/tabLeftCorner.png) no-repeat");
        $(".firstTab a").css("background", "url(/img/tabBackGround.png) repeat-x");
    });

    $(".lastTab").bind("mouseenter", function() {
        LastTabHovered();
    }).bind("mouseleave", function() {
        $(this).css("background", "url(/img/tabRightCorner.png) no-repeat");
        $(this).css("background-position", "100% 0%");
        $(".lastTab a").css("background", "url(/img/tabBackGround.png) repeat-x");

    });

});

function MM_preloadImages() {
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
    }
}

function FirstTabHovered() {
    $(".firstTab").css("background", "url(/img/tabLeftCornerHover.png) no-repeat");
    $(".firstTab").css("cursor", "pointer");
    $(".firstTab a").css("background", "url(/img/tabHover.png) repeat-x");
}

function LastTabHovered() {
    $(".lastTab").css("background", "url(/img/tabRightCornerHover.png) no-repeat");
    $(".lastTab").css("background-position", "100% 0%");
    $(".lastTab").css("cursor", "pointer");
    $(".lastTab a").css("background", "url(/img/tabHover.png) repeat-x");
   
}

function postalCodeSuccess(isValid) {
    if (isValid) {
        $.get("/Register/FindByPostalCode/default.aspx?postalCode=" + $("#PostalCode").val(),
                function(data) {
                    $("#location").text(data);
                }
            );
    }
    else
        $("#location").text("");
}
