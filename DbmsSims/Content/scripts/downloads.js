function CancelDownload()
{
    ResetDownloadTag();
    HideDownloadItemDiv();
    ShowExistingItemsDiv();
}

function DownloadItem(jquery, strRptDwnldId)
{

    if (strRptDwnldId.length > 0)
    {       
        if (jquery.isNumeric(strRptDwnldId))
        {
            ParseDownloadFile(strRptDwnldId);
        }
    }
    else
    {
        alert("Please reselect item for download");
    }
    

}

function ShowDownloadItem(strRptDwnldId)
{
    if (strRptDwnldId.length > 0)
    {
        if ($.isNumeric(strRptDwnldId))
        {
            ShowFile(strRptDwnldId);
        }
    }
    else
    {
        alert("Please reselect item to show");
    }

}




function CheckForDownloads(strRptDownloadId) {

    $('#hdeRptDwnldId').attr('value', strRptDownloadId);


    $.ajax({
        url: verifyFiles.file.VerifyFileExistsToDownloadUrl, // Controller: DownloadsController --- Action: VerifyFileExistsToDownload
        type: 'POST',
        datatype: 'json',
        data: { RptDwnldId: strRptDownloadId },
        success: function (result) {

            if (result.FileExists) {

                $('#hdeRptDwnldId').attr('value', strRptDownloadId);

                $('#spanName').html(result.Name);
                $('#spanType').html(result.Type);

                ShowDownloadReadyScreens();

            }
            else {
                ResetDownloadTag();
                HideDownloadItemDiv();
                alert("Download file not available")
            }

        },
        error: function (result) {
            ResetDownloadTag();
            HideDownloadItemDiv();
            alert("Unable to verify download item");
        }

    });

}

function ParseDownloadFile(strRptDwnldId)
{

    ShowDownloadInProgressDiv();

    $.ajax({
        url: downloadFiles.file.DownLoadFileUrl,
        type: 'POST',
        datatype: 'json',
        data: { RptDwnldId: strRptDwnldId },
        success: function (result) {

            if (result) {
                alert("Download complete");
                ShowDownloadCompleteScreens();
            }
            else {
                alert("Download failed");
                ShowDownloadCompleteScreens();
            }

        },
        error: function (result) {                
            alert("Unable to download file");
            ShowDownloadCompleteScreens();
        }
    });

}




function ShowFile(strRptDwnldId)
{

    try {


        var strRptDownloadId = $("#hdeRptDwnldId").attr('value');

        if (strRptDownloadId.length > 0 && $.isNumeric(strRptDownloadId)) {

            ShowDownloadInProgressDiv();

            $.ajax({
                url: showFiles.file.ShowFileUrl,
                type: 'POST',
                datatype: 'json',
                data: { RptDwnldId: strRptDownloadId },
                success: function (result) {

                    if (result.FileCanBeShown) {
                        
                        //**NEED TO ADD A COLUMN TO THE Report_Download_Admin (i.e. ftp_login_url) table THAT HOLDS "ftps.dbmshealth.com/EGP/Eligibility"
                        //**THE "ftp//" WILL BE HARDCODED, "dbmsadmin" and "DBMS$.2013!" WILL BE CONCATENATED USING THE RETURNED result
                        //**PARAMETER, "@" WILL BE HARDCODED AS WELL...
                        window.open('ftp://dbmsadmin:DBM$.2013!@ftps.dbmshealth.com/EGP/Eligibility', '_blank');

                    }
                    else {
                        alert("Cannot view file in FTP");
                        ShowDownloadCompleteScreens();
                    }

                },
                error: function (result) {
                    alert("Unable to access FTP");
                    ShowDownloadCompleteScreens();
                }
            });

        }
        else {
            alert("Please reselect download file");
            ShowDownloadCompleteScreens();
        }

    }
    catch (ex)
    {

    }

}






function ShowDownloadReadyScreens() {
    HideExistingItemsDiv();
    ShowDownloadItemDiv();
}

function ShowDownloadCompleteScreens() {
    ShowDownloadItemDiv();
}





function ShowExistingItemsDiv()
{
    $("#divExistingItems").css("display", " ");
    $("#divExistingItems").show();
}

function HideExistingItemsDiv()
{
    $("#divExistingItems").css("display", "none");
}

function ShowDownloadItemDiv() {
    $("#divDownloadItem").css("display", " ");
    $("#divDownloadItem").show();
}

function HideDownloadItemDiv()
{
    $("#divDownloadItem").css("display", "none");
}

function ShowDownloadInProgressDiv()
{
    $("#divDownloadItem").css("display", " ");
    $("#divDownloadItem").show();
}

function HideDownloadInProgressDiv()
{
    $("#divDownloadItem").css("display", "none");
}






function ResetDownloadTag() {
    $('#hdeRptDwnldId').attr('value', '');
    $('#spanName').html('');
    $('#spanType').html('');
}

