﻿newFunction();

function newFunction() {
    !function(n) {
    !function() {
    for (var n = 0, i = ["ms", "moz", "webkit", "o"], a = 0; a < i.length && !window.requestAnimationFrame; ++a)
        window.requestAnimationFrame = window[i[a] + "RequestAnimationFrame"], window.cancelAnimationFrame = window[i[a] + "CancelAnimationFrame"] || window[i[a] + "CancelRequestAnimationFrame"]; window.requestAnimationFrame || (window.requestAnimationFrame = function(i) { var a = (new Date).getTime(), t = Math.max(0, 16 - (a - n)), o = window.setTimeout(function() { i(a + t); }, t); return n = a + t, o; }), window.cancelAnimationFrame || (window.cancelAnimationFrame = function(n) { clearTimeout(n); });
    } (), n.fn.sakura = function(i) {
    function a(n, i) { return Math.floor(Math.random() * (i - n + 1)) + n; } function t(n, i, a) {
    for (var t = 0; e > t; t++)
        o[t] || (i = i.toLowerCase()), n.get(0).addEventListener(o[t] + i, a, !1);
    } var o = ["moz", "ms", "o", "webkit", ""], e = o.length, m = { blowAnimations: ["blow-soft-left", "blow-medium-left", "blow-hard-left", "blow-soft-right", "blow-medium-right", "blow-hard-right"], className: "sakura", fallSpeed: 1, maxSize: 14, minSize: 9, newOn: 300, swayAnimations: ["sway-0", "sway-1", "sway-2", "sway-3", "sway-4", "sway-5", "sway-6", "sway-7", "sway-8"] }, i = n.extend({}, m, i), r = n(document).height(), s = n(document).width(), w = n('<div class="' + i.className + '" />'); n("body").css({ "overflow-x": "hidden" }); var d = function() { setTimeout(function() { requestAnimationFrame(d); }, i.newOn); var o = i.blowAnimations[Math.floor(Math.random() * i.blowAnimations.length)], e = i.swayAnimations[Math.floor(Math.random() * i.swayAnimations.length)], m = (Math.round(.007 * r) + 5 * Math.random()) * i.fallSpeed, l = "fall " + m + "s linear 0s 1, " + o + " " + ((m > 30 ? m : 30) - 20 + a(0, 20)) + "s linear 0s infinite, " + e + " " + a(2, 4) + "s linear 0s infinite", u = w.clone(), c = a(i.minSize, i.maxSize), h = Math.random() * s - 100, f = -(20 * Math.random() + 15); t(u, "AnimationEnd", function() { n(this).remove(); }), t(u, "AnimationIteration", function(a) { -1 != n.inArray(a.animationName, i.blowAnimations) && n(this).remove(); }), u.css({ "-webkit-animation": l, "-o-animation": l, "-ms-animation": l, "-moz-animation": l, animation: l, height: c, left: h, "margin-top": f, width: c }).appendTo("body"); }; n(window).resize(function() { r = n(document).height(), s = n(document).width(); }), requestAnimationFrame(d);
    };
    } (jQuery);
}
