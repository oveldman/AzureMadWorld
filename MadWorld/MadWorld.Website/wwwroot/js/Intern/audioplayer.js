"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var documenthandler_1 = require("../base/documenthandler");
var AudioManager;
(function (AudioManager) {
    var AudioPlayer = /** @class */ (function () {
        function AudioPlayer() {
            this.Name = "";
            this.Player = null;
        }
        AudioPlayer.prototype.Init = function (name) {
            this.Name = name;
            this.Player = documenthandler_1.DocumentManager.GetElementByID(this.Name);
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