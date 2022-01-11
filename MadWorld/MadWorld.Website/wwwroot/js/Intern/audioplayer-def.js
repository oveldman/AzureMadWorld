(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicationHTML = void 0;
var ApplicationHTML;
(function (ApplicationHTML) {
    var DocumentManager = /** @class */ (function () {
        function DocumentManager() {
        }
        DocumentManager.GetElementByID = function (name) {
            return document.getElementById(name);
        };
        return DocumentManager;
    }());
    ApplicationHTML.DocumentManager = DocumentManager;
})(ApplicationHTML = exports.ApplicationHTML || (exports.ApplicationHTML = {}));

},{}],2:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var application_html_1 = require("../base/application-html");
var AudioManager;
(function (AudioManager) {
    var AudioPlayer = /** @class */ (function () {
        function AudioPlayer() {
            this.Name = "";
            this.Player = null;
        }
        AudioPlayer.prototype.Create = function (name) {
            this.Name = name;
            this.Player = application_html_1.ApplicationHTML.DocumentManager.GetElementByID(this.Name);
        };
        AudioPlayer.prototype.Play = function () {
            this.Player.play();
        };
        return AudioPlayer;
    }());
    function Load() {
        window["AudioPlayer"] = new AudioPlayer();
    }
    AudioManager.Load = Load;
})(AudioManager || (AudioManager = {}));
AudioManager.Load();

},{"../base/application-html":1}]},{},[2]);
