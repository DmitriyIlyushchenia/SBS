$(document).ready(function () {
    loadPartial(1);
});

function loadPartial(id) {
    switch (id) {
        case 1:
            $("#content").load(fileUploadPartialUrl);
            $("#content_title").text("Source documents upload");
            break;
        case 2:
            $("#content").load(sourceDocumentsTablePartialUrl);
            $("#content_title").text("Source documents list");
            buildTable();
            break;
    }
}