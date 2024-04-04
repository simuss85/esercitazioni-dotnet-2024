﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// setta il value da placeholder (Pages/ModificaImmagine)
function setPlaceholderToValue(input) {
    if (input.placeholder && input.value === '') {
        input.value = input.placeholder;
    }
}

// // setta il placeholder da value (non mi serve)
// function setPlaceholderFromValue(input) {
//     if (input.value === input.placeholder) {
//         input.value = '';
//     }
// }