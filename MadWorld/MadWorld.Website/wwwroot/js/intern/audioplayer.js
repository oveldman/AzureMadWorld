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
//# sourceMappingURL=audioplayer.js.map