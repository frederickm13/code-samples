# Please note, this sample code is provided to the community as-is, and for learning/demonstration purposes only.  
# This code is not certified for production use without further review and testing by your organization.

# This code uses the "ADAL.PS" third-party component.
# More information, including LICENSE information for this component, may be found at the root directory of this repo in the LICENSE-THIRD-PARTY.txt file.
# Component URL: https://github.com/jasoth/ADAL.PS/blob/master/LICENSE

if(!(Get-Package adal.ps)) { Install-Package -Name adal.ps }

function Get-CrmContext ([string]$ClientId, [string]$RedirUri, [string]$CrmApiUrl)
{
    $CrmContext = @{
        client_id = $ClientId;
        redirect_uri = $RedirUri;
        resource = $CrmApiUrl + "/";
        Authorization = "null";
        authResult = "null";
    }
    
    $CrmContext = Get-CrmToken($CrmContext);

    return $CrmContext;
}

function Get-CrmToken ([Hashtable]$CrmContext)
{
    $Authority = "https://login.microsoftonline.com/common/oauth2/authorize";

    if ($CrmContext.Authorization -eq "null")
    {
        $CrmTokenResponse = Get-ADALToken -Resource $CrmContext.resource -ClientId $CrmContext.client_id -RedirectUri $CrmContext.redirect_uri -Authority $Authority -PromptBehavior:RefreshSession;
    }

    $CrmContext.Authorization = ("Bearer " + $CrmTokenResponse.AccessToken);
    $CrmContext.authResult = $CrmTokenResponse

    return $CrmContext;
}

function Get-GetCrmData ([Hashtable]$CrmContext, [string]$QueryString)
{    
    $header = @{
        "Authorization" = ($CrmContext.Authorization);
        "Accept" = "application/json";
        "Content-Type" = "application/json; charset=utf-8";
        "OData-MaxVersion" = "4.0";
        "OData-Version" = "4.0";
    };

    $response = Invoke-RestMethod -Uri ($CrmContext.resource + "api/data/v9.1/" + $QueryString) -Method Get -Headers $header;

    $responseObj = @{
        FullResp = $response;
        JsonObj = $response.value;
        JsonString = ConvertTo-Json $response.value;
    }

    return $responseObj;
}

function Get-PostCrmData ([Hashtable]$CrmContext, [string]$QueryString, [Hashtable]$Content)
{
    $header = @{
        "Authorization" = ($CrmContext.Authorization);
        "Accept" = "application/json";
        "Content-Type" = "application/json; charset=utf-8";
        "OData-MaxVersion" = "4.0";
        "OData-Version" = "4.0";
    };

    $jsonBody = ConvertTo-Json $Content

    $response = Invoke-RestMethod -Uri ($CrmContext.resource + "api/data/v9.1/" + $QueryString) -Method Post -Headers $header -Body $jsonBody;

    if (!$response)
    {
        $result = "`n" + $QueryString + " have been created!`n";
        return $result;
    }
}

function Get-DeleteCrmData ([Hashtable]$CrmContext, [string]$QueryString)
{
    $header = @{
        "Authorization" = ($CrmContext.Authorization);
        "Accept" = "application/json";
        "Content-Type" = "application/json; charset=utf-8";
        "OData-MaxVersion" = "4.0";
        "OData-Version" = "4.0";
    };

    $response = Invoke-RestMethod -Uri ($CrmContext.resource + "api/data/v9.1/" + $QueryString) -Method Delete -Headers $header;

    if (!$response)
    {
        $result = "`n" + $QueryString + " have been deleted!`n";
        return $result;
    }
}

function Get-PatchCrmData ([Hashtable]$CrmContext, [string]$QueryString, [Hashtable]$Content)
{
    $header = @{
        "Authorization" = ($CrmContext.Authorization);
        "Accept" = "application/json";
        "Content-Type" = "application/json; charset=utf-8";
        "OData-MaxVersion" = "4.0";
        "OData-Version" = "4.0";
    };

    $jsonBody = ConvertTo-Json $Content

    $response = Invoke-RestMethod -Uri ($CrmContext.resource + "api/data/v9.1/" + $QueryString) -Method Patch -Headers $header -Body $jsonBody;

    if (!$response)
    {
        $result = "`n" + $QueryString + " have been updated!`n";
        return $result;
    }
}
