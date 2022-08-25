$(document).ready(function () {

    $(document).on('click', '#PrimaryImageLink', function () {
        event.preventDefault();
        $('#PrimaryImageLink').magnificPopup({
            type: 'image',
            closeBtnInside: false,
            closeOnContentClick: false,
            midClick: true,
            callbacks: {
                open: function () {
                    var isMagnifier = $("#zoom-magnifierSwitch").hasClass('rz-switch rz-switch-checked');
                    $(".mfp-figure figure img.mfp-img").css("cursor", "zoom-in");
                    $(".mfp-figure figure figcaption").hide();
                    if (isMagnifier) {
                        zoom(zoom_percent);
                    } else {
                        scrollImage();
                    }
                },
                close: function () {
                    // Will fire when popup is closed
                },
                beforeClose: function () {
                    this.wrap.off('click.pinhandler');
                    this.wrap.removeClass('mfp-force-scrollbars');
                },
                image: {
                    verticalFit: false
                }
            }
        });
    });
});

var zoom_percent = "100";
function zoom(zoom_percent) {
    $(".mfp-figure figure").click(function () {
        switch (zoom_percent) {
            case "100":
                zoom_percent = "120";
                break;
            case "120":
                zoom_percent = "150";
                break;
            case "150":
                zoom_percent = "200";
                break;
            case "200":
                zoom_percent = "225";
                $(".mfp-figure figure img.mfp-img").css("cursor", "zoom-out");
                break;
            case "225":
                zoom_percent = "100";
                $(".mfp-figure figure img.mfp-img").css("cursor", "zoom-in");
                break;
        }
        $(this).css("zoom", zoom_percent + "%");
    });
}

function scrollImage() {
    $(".mfp-figure figure img.mfp-img").css("cursor", "all-scroll");
    $(".mfp-figure figure figcaption").hide();
    const zoomElement = document.querySelector(".mfp-figure");
    let zoom = 1;
    const ZOOM_SPEED = 0.1;
    document.addEventListener("wheel", function (e) {

        if (e.deltaY > 0) {
            zoomElement.style.transform = `scale(${zoom += ZOOM_SPEED})`;
        }
        else if (zoom > 0.5) {
            zoomElement.style.transform = `scale(${zoom -= ZOOM_SPEED})`;
        }
    });
}

