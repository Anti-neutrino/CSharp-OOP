function ClickOnButton(event, arguments) {
    var myWindow = window;
    var browser = myWindow.navigator.appCodeName;
    var check = (browser == "Mozilla");

    if(check) {
        alert("Yes");
    } 
    else {
        alert("No");
    }
}