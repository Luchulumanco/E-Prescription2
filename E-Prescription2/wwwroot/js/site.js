// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DynamicText() {
    var division = document.createElement('DIV');
    division.innerHTML = DynamictextBox("");
    document.getElementById("firstdiv").appendChild(division);
}
function DynamictextBox(value) {
    return '<div><input asp-for="Strength" type="text" name="dyntxt" /><input type="button" onclick="ReTextBox(this)" value="Remove"/></div>';
}
function ReTextBox(div) {
    document.getElementById("firstdiv").removeChild(div.parentNode.parentNode);
}
