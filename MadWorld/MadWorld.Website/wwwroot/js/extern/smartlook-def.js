(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
var SmartLook;
(function (SmartLook) {
    var SmartLookAnalyser = /** @class */ (function () {
        function SmartLookAnalyser() {
        }
        SmartLookAnalyser.prototype.Init = function () {
            window.smartlook || (function (d) {
                var o = window.smartlook = function () { o.api.push(arguments); }, h = d.getElementsByTagName('head')[0];
                var c = d.createElement('script');
                o.api = new Array();
                c.async = true;
                c.type = 'text/javascript';
                c.charset = 'utf-8';
                c.src = 'https://rec.smartlook.com/recorder.js';
                h.appendChild(c);
            })(document);
            window.smartlook('init', 'f533ea7bf4b36e705beb1e784b939375e4655cd6');
        };
        return SmartLookAnalyser;
    }());
    function Load() {
        window["SmartLookAnalyser"] = new SmartLookAnalyser();
    }
    SmartLook.Load = Load;
})(SmartLook || (SmartLook = {}));
SmartLook.Load();

},{}]},{},[1]);
