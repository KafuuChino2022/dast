window.onload = function ()
{
}
function postMsg(msg) 
{
    window.chrome.webview.postMessage(msg);
}