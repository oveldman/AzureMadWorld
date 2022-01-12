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
//# sourceMappingURL=application-html.js.map